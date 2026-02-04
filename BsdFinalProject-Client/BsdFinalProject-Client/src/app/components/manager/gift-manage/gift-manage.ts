
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SelectModule } from 'primeng/select';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { RippleModule } from 'primeng/ripple';
import { SelectItem, MessageService } from 'primeng/api';
import { DataViewModule } from 'primeng/dataview';
import { SelectButtonModule } from 'primeng/selectbutton';
import { DialogModule } from 'primeng/dialog';
import { GiftModel } from '../../../Models/gift';
import { GiftService } from '../../../Services/gift-service';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { categoryModel } from '../../../Models/category';
import { CategoryService } from '../../../Services/category-service';
import { ToastModule } from 'primeng/toast';
import { HttpHeaders } from '@angular/common/http'
import { jwtDecode } from 'jwt-decode';

// import { ProductService } from '@/service/productservice';
// import { Product } from '@/domain/product';
// import { Product } from '@/domain/product';
@Component({
  selector: 'app-gift-manage',
  imports: [DataViewModule, SelectButtonModule, TagModule, ButtonModule, FormsModule, CommonModule, CurrencyPipe, DialogModule, SelectModule, InputTextModule,ToastModule],
  providers: [MessageService],
  templateUrl: './gift-manage.html',
  styleUrl: './gift-manage.scss',
})
export class GiftManage {

constructor(private cdr: ChangeDetectorRef, private messageService: MessageService) { }

    gifts:GiftModel[]=[];
    giftSrv:GiftService=inject(GiftService) ;
    cSrv:CategoryService=inject(CategoryService) ;
    id:Number=0;
    name:string="";
    description:string="";
    cost:Number=0;
    picture:string="";
    categoryId:Number=0;
    donorId:Number=0;
    winnerName:string="";
    layout: 'list' | 'grid' = 'list';
    options: SelectItem[] = [
    { label: 'List', value: 'list' },
    { label: 'Grid', value: 'grid' }
    ];
    displayDialog: boolean = false;
    newGiftName:string="";
    newGiftDescription:string="";
    newGiftCost:Number=0;
    newGiftPicture:string="";
    newGiftCategoryId:Number=0;
    categories: categoryModel[] = [];   
    categoryOptions: SelectItem[] = [];
    selectedCategory: Number = 0;
    // messageService: MessageService = inject(MessageService);

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
  
       ngOnInit() {
        console.log("Initializing");
            this.initializeCategories();
            try {
                 this.giftSrv.getAllGifts().subscribe({       
                 next: (response: GiftModel[]) => {
                   this.gifts=response;
                   console.log("gifts",this.gifts)
                  //  this.cdr.detectChanges(); 
                  },
                 error: (err) => {
                   console.log('Login error:', err);
             }  
               })
              } catch {
                alert('הבקשה נכשלה');
              }
      }

      initializeCategories() {
        console.log("Fetching categories");
        this.cSrv.getAllCategories().subscribe( {
          next: (categories: categoryModel[]) => {
            this.categories = categories;
            this.categoryOptions = this.categories.map(cat => ({
              label: cat.name,
              value: cat.id
            }));
         setTimeout(() => {
           this.cdr.detectChanges();  
           }, 0);
          },
          error: (err) => {
            console.log('Error fetching categories:', err);
          }
        });
      }
      
      
      closeDialog() {
        this.displayDialog = false;
        this.resetForm();
      }

      resetForm() {
        this.newGiftName = "";
        this.newGiftDescription = "";
        this.newGiftCost = 0;
        this.newGiftPicture = "";
        this.newGiftCategoryId = 0;
        this.selectedCategory = 0;
      }

       deleteGift (id:number){
          const headers = this.getHeaders(); 
         console.log("headers",headers) 
         this.giftSrv.deleteGift(id, headers).subscribe({
          next: (response: boolean) => {
            console.log("Deleted gift with id:",id);
            this.gifts = this.gifts.filter(gift => gift.id !== id);
            this.ngOnInit();
          },
          error: (err) => {
            console.log('Delete error:', err);
             this.messageService.add({ severity: 'error', summary: 'Error', detail: 'מחיקת המתנה נכשלה' });
          }  
        })  
      }

      openUpdateGiftDialog(item:GiftModel) {
       this.id = item.id;
       this.newGiftName = item.name;
       this.newGiftDescription = item.description || "";
       this.newGiftCost = item.cost;
       this.newGiftPicture = item.picture || "";
       this.newGiftCategoryId = item.categoryId;
       this.selectedCategory = Number(item.categoryId);
       this.donorId = item.donorId;
       this.winnerName = item.winnerName || "";
       console.log("categoies",this.categories)
       this.displayDialog = true;
     }

     updateGiftDetails() {
        const updatedGift: GiftModel = {
          id: this.id,
          name: this.newGiftName,
          description: this.newGiftDescription,
          cost: this.newGiftCost,
          picture: this.newGiftPicture,
          categoryId: this.selectedCategory,
          
          donorId: this.donorId,
          winnerName: this.winnerName
        };
      console.log("categoryid",this.categoryId)
      try{
        const headers = this.getHeaders(); 
        console.log("headers",headers) 
        this.giftSrv.updateGift(updatedGift, headers).subscribe({
        next: (response: GiftModel) => {
          console.log("Updated gift:", response);
          this.gifts = this.gifts.map(gift => gift.id === response.id ? response : gift);
          this.closeDialog();
          this.ngOnInit();
          // this.cdr.detectChanges();
          // setTimeout(() => {
          //   this.closeDialog();
          // }, 100);
        },
        error: (err) => {
          console.log('Error updating gift:', err);
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'עדכון המתנה נכשל' });
        }
        })
      }catch (error) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'עדכון המתנה נכשל' });
        }
      }
    

  
}
