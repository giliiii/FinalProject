import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SelectModule } from 'primeng/select';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { RippleModule } from 'primeng/ripple';
import { SelectItem, MessageService } from 'primeng/api';
import { DonorModel } from '../../../Models/donor';
import { DonorService } from '../../../Services/donor-service';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
// // import { Product } from '@/domain/product';


@Component({
  selector: 'app-donor-manage',
   imports: [SelectModule, TableModule, TagModule, ToastModule, ButtonModule, InputTextModule, RippleModule, FormsModule,CommonModule],
  templateUrl: './donor-manage.html',
  styleUrl: './donor-manage.scss',
})
export class DonorManage {
    // private productService = inject(ProductService);
    // private messageService = inject(MessageService);
    // products!: Product[];
    // statuses!: SelectItem[];
     donorSrv: DonorService = inject(DonorService );
     id:Number=0;
     name: string = "";
     email: string = "";
     donors:DonorModel[]=[];

    ngOnInit():void {
        // alert(1)
     //הבאת רשימת התורמים מהשרת
     try {
        //  alert(2)
         this.donorSrv.getDonors().subscribe({       
          next: (response: DonorModel[]) => {
            // alert(3)
            this.donors=response;
            console.log(this.donors)
           },
          error: (err) => {
            // alert(4)
            console.log('Login error:', err);
            //alert(err?.error?.message || 'שגיאת התחברות');
      }  
        })
       } catch {
         alert('הבקשה נכשלה');
       }
    }

// ngOnInit(): void {
//     alert(1);
//     this.donorSrv.getDonors().subscribe({
//       next: (response: DonorModel[]) => {
//         alert(3);
//         this.donors = response;
//       }
//     });
//   }


    a(){
       try {
         alert(1)
         this.donorSrv.getDonors().subscribe({
           next: (response: DonorModel[]) => {
            this.donors=response;
        }})
       } catch {
         alert('הבקשה נכשלה');
       }
    }

    // onRowEditInit(product: Product) {
    //     this.clonedProducts[product.id as string] = { ...product };
    // }

    // onRowEditSave(product: Product) {
    //     if (product.price > 0) {
    //         delete this.clonedProducts[product.id as string];
    //         this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Product is updated' });
    //     } else {
    //         this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Invalid Price' });
    //     }
    // }

    // onRowEditCancel(product: Product, index: number) {
    //     this.products[index] = this.clonedProducts[product.id as string];
    //     delete this.clonedProducts[product.id as string];
    // }

    // getSeverity(status: string) {
    //     switch (status) {
    //         case 'INSTOCK':
    //             return 'success';
    //         case 'LOWSTOCK':
    //             return 'warn';
    //         case 'OUTOFSTOCK':
    //             return 'danger';
    //     }
    // }

}
