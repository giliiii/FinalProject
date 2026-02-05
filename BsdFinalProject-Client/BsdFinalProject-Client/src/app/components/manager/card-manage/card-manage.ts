
import { Component, OnInit, inject } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
// import { ProductService } from '@/service/productservice';
import { MessageService } from 'primeng/api';
// import { Product } from '@/domain/product';

@Component({
  selector: 'app-card-manage',
  imports: [TableModule, ToastModule],
  providers: [MessageService],
  templateUrl: './card-manage.html',
  styleUrl: './card-manage.scss',
})
export class CardManage {
    //  private productService = inject(ProductService);
    private messageService = inject(MessageService);
    // products!: Product[];
    // selectedProduct!: Product;

    ngOnInit() {
        // this.productService.getProductsMini().then((data) => {
        //     this.products = data;
        // });
    }

    onRowSelect(event: any) {
        this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: event.data.name });
    }

    onRowUnselect(event: any) {
        this.messageService.add({ severity: 'info', summary: 'Product Unselected', detail: event.data.name });
    }
}
