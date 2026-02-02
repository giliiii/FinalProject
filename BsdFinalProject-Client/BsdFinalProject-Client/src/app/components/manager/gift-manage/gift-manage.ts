
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
import { DataViewModule } from 'primeng/dataview';
import { SelectButtonModule } from 'primeng/selectbutton';
import { GiftModel } from '../../../Models/gift';
import { GiftService } from '../../../Services/gift-service';
import { CommonModule, CurrencyPipe } from '@angular/common';

// import { ProductService } from '@/service/productservice';
// import { Product } from '@/domain/product';
// import { Product } from '@/domain/product';

@Component({
  selector: 'app-gift-manage',
  imports: [DataViewModule, SelectButtonModule, TagModule, ButtonModule, FormsModule, CommonModule, CurrencyPipe,],
   
  templateUrl: './gift-manage.html',
  styleUrl: './gift-manage.scss',
})
export class GiftManage {

    gifts:GiftModel[]=[];
    giftSrv:GiftService=inject(GiftService) ;
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

  
     ngOnInit() {
            try {
                this.giftSrv.getAllGifts().subscribe({       
                 next: (response: GiftModel[]) => {
                   this.gifts=response;
                   console.log(this.gifts)
                  },
                 error: (err) => {
                   console.log('Login error:', err);
             }  
               })
              } catch {
                alert('הבקשה נכשלה');
              }
    }
}
