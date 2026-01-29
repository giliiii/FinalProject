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
// // import { Product } from '@/domain/product';


@Component({
  selector: 'app-donor-manage',
   imports: [SelectModule, TableModule, TagModule, ToastModule, ButtonModule, InputTextModule, RippleModule, FormsModule],
  templateUrl: './donor-manage.html',
  styleUrl: './donor-manage.scss',
})
export class DonorManage {
    // private productService = inject(ProductService);
    // private messageService = inject(MessageService);
    // products!: Product[];
    // statuses!: SelectItem[];

    ngOnInit() {
     //הבאת רשימת התורמים מהשרת
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

    getSeverity(status: string) {
        switch (status) {
            case 'INSTOCK':
                return 'success';
            case 'LOWSTOCK':
                return 'warn';
            case 'OUTOFSTOCK':
                return 'danger';
        }
    }

}
