using BsdFinalProject.Data;
using BsdFinalProject.DTOs;
using BsdFinalProject.IServices;
using BsdFinalProject.Models;
using BsdFinalProject.Services;
using FinalProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BsdFinalProject.Controllers
{
        //[Authorize(Roles = "Manager")]
        [ApiController]
        [Route("api/[controller]")]
        public class WinnersController : ControllerBase
        {
            private readonly SaleContext _context;
            private readonly IWinnerService _WinnerService;
            private readonly IGiftService _giftService;
            private readonly ILogger<WinnersController> _logger;
            private readonly IUserService _userService;

            public WinnersController(IWinnerService winnerService, SaleContext context, ILogger<WinnersController> logger, IGiftService giftService, IUserService userService)
            {
                _WinnerService = winnerService;
                _context = context;
                _logger = logger;
                _giftService = giftService;
                _userService = userService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<WinnerDto>>> GetAllWinners()
            {
                try
                {
                    var winners = await _WinnerService.GetAllWinners();
                    return Ok(winners);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while getting all winners.");
                    return BadRequest(new { message = ex.Message });
                }
            }

        [HttpPost]
        public async Task<ActionResult<WinnerDto>> AddWinner(int giftId)
        {
            try
            {
                // create a new winner for the gift (service will validate existing winners)
                var winner = await _WinnerService.CreateNewWinner(giftId);

                // 3. �� �� ���� ���� �� ����, ������� �����
                if (winner == null)
                {
                    return NotFound(new { message = "No users found for this gift." });
                }

                // 4. ����� ����� �� �� �����
                var gift = await _giftService.GetGiftById(winner.IdGift);
                var user = await _userService.GetUserById(winner.IdUser);

                // ����� ����� �� �� �����
                gift.WinnerName = user.FullName;  // ����� ��� �� �����
                await _giftService.UpdateGift(gift);

                // 5. ���� �� ��� ��� ����� �����
                var updatedGift = await _giftService.GetGiftById(gift.Id);
                if (updatedGift.WinnerName != gift.WinnerName)
                {
                    _logger.LogWarning("Failed to update WinnerName for giftId: {GiftId}", gift.Id);
                }

                return Ok(new { winnerName = gift.WinnerName, giftId = gift.Id, userId = winner.IdUser });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Invalid argument provided while adding a new winner.");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new winner.");
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
            public async Task<ActionResult<bool>> DeleteAllWinners()
            {
                try
                {
                    var winners = await _WinnerService.GetAllWinners(); // �� ������ ������� ������ �� �� ������
                    if (winners == null || !winners.Any()) // �� ����� ���
                    {
                        return NotFound(new { message = "��� ����� �����." });
                    }
                    foreach (var winner in winners)
                    {
                        var gift = await _giftService.GetGiftById(winner.IdGift);
                        if (gift != null)
                        {
                            gift.WinnerName = " ";
                            await _giftService.UpdateGift(gift);
                        }
                    }
                    var sucsses = await _WinnerService.DeleteAllWinners();
                    return Ok(sucsses);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while deleting all winners.");
                    return BadRequest(new { message = ex.Message });
                }
            }
            
        }
    }
