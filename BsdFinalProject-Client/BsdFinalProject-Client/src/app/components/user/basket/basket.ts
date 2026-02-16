import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../../Services/basket-service';
import { BasketModel } from '../../../Models/basket';
import { HttpHeaders } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { inject } from '@angular/core';
import { DialogModule } from 'primeng/dialog';  // ייבוא DialogModule לצורך הדיאלוגים
import { InputTextModule } from 'primeng/inputtext'; // ייבוא InputTextModule לשדות הקלט
import { MessageService } from 'primeng/api'; // ייבוא שירות הודעות
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-basket',
  imports: [CommonModule, TableModule, ButtonModule, DialogModule, InputTextModule, FormsModule],
  templateUrl: './basket.html',
  styleUrl: './basket.scss',
})
export class Basket implements OnInit {
  baskets: BasketModel[] = [];
  basketDialogVisible: boolean = false; // חלון צפייה בסל
  paymentDialogVisible: boolean = false; // חלון תשלום
  creditCardNumber: string = ''; // שדה למספר כרטיס אשראי
  expirationDate: string = ''; // שדה לתאריך תפוגה
  userId: number = 1; // זיהוי המשתמש (הערך יילקח מה-token)
  basketDrawerVisible: boolean = false;  // דגל לפתיחת חלון הסל
  basketSrv: BasketService = inject(BasketService);
  router = inject(Router);


  constructor(private basketService: BasketService, private messageService: MessageService) { }

  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    let userRole = '';
    if (token) {
      const decodedToken: any = jwtDecode(token);
      userRole = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || '';
    }
    return new HttpHeaders({
      'User-Role': userRole,
      'Authorization': token ? `Bearer ${token}` : ''
    });
  }

  ngOnInit(): void {
    this.getAllBaskets();
  }

  getAllBaskets() {
    const headers = this.getHeaders();
    this.basketService.getAllMyBasket(headers).subscribe(
      (data) => {
        this.baskets = data;
      },
      (error) => {
        console.error('Error fetching baskets:', error);
      }
    );
  }

  deleteBasket(id: number) {
    const headers = this.getHeaders();
    this.basketService.deleteOneBasket(id, headers).subscribe(
      (data) => {
        this.getAllBaskets(); // עדכון הסלים אחרי מחיקה
        this.messageService.add({ severity: 'success', summary: 'הסל נמחק בהצלחה' });
      },
      (error) => {
        console.error('Error deleting basket:', error);
      }
    );
  }

  // פונקציה לפתיחת דיאלוג הסל
  openBasketDialog() {
    this.basketDialogVisible = true;
  }

  // פונקציה לפתיחת דיאלוג התשלום
  openPaymentDialog() {
    if (this.baskets.length === 0) {
      this.messageService.add({ severity: 'warn', summary: 'לא ניתן לבצע תשלום', detail: 'הסל ריק' });
      return;
    }
    this.paymentDialogVisible = true;
  }

  // פונקציה לשליחה של פרטי האשראי
  submitPayment() {
    if (!this.creditCardNumber || !this.expirationDate) {
      this.messageService.add({ severity: 'error', summary: 'שגיאה', detail: 'יש למלא את כל פרטי האשראי' });
      return;
    }
    // כאן נוסיף את הלוגיקה של תשלום ותגובה בהתאם
    this.messageService.add({ severity: 'success', summary: 'תשלום בוצע בהצלחה' });
    this.paymentDialogVisible = false;
    this.basketDialogVisible = false;
    this.getAllBaskets(); // עדכון הסלים אחרי התשלום
  }
removeFromBasket(basketId: number) {
    const headers = this.getHeaders();
    this.basketService.deleteOneBasket(basketId, headers).subscribe(
      () => {
        this.getAllBaskets();
      },
      (error) => {
        console.error('Error deleting basket:', error);
      }
    );
  }
  goToShop() {
    this.router.navigate(['/user/home']);
  }
  formatCost(cost: number): string {
  return new Intl.NumberFormat('he-IL', {
    style: 'currency',
    currency: 'ILS'
  }).format(cost);
}
}
