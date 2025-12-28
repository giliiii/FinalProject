using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class SaleContectFactory
    {
        private const string ConnectionString = "Server=Srv2\\pupils;DataBase=ProjectDB0583255125;" +
          "Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";

        public static SaleContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SaleContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new SaleContext(optionsBuilder.Options);
        }
    }
}
