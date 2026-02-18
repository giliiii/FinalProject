
import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
// import { ProductService } from '@/service/productservice';
import { CardService } from '../../../Services/card-service';
import { CardModel } from '../../../Models/card';

import { SpeedDialModule } from 'primeng/speeddial';
import { MenuItem, MessageService } from 'primeng/api';
import { MenuModule } from 'primeng/menu';
import { ButtonModule } from 'primeng/button';

// import { Product } from '@/domain/product';

@Component({
  selector: 'app-card-manage',
  imports: [TableModule, ToastModule,SpeedDialModule,MenuModule,ButtonModule],
  providers: [MessageService],
  templateUrl: './card-manage.html',
  styleUrl: './card-manage.scss',
})
export class CardManage {
    //  private productService = inject(ProductService);
    private messageService = inject(MessageService);
    cardSrv:CardService=inject(CardService)
    cards:CardModel[]=[];
    // products!: Product[];
    selectedCard?: CardModel;
    cdr: ChangeDetectorRef = inject(ChangeDetectorRef); // הוספת ChangeDetectorRef
    items: MenuItem[] = [];
    ngOnInit() {
          try {
            this.cardSrv.getAllCardsWithBuyers().subscribe({       
                  next: (response: CardModel[]) => {
                      this.cards = response;
                      console.log("cards",this.cards);
                      this.cdr.markForCheck();
                    //   this.changeRef.markForCheck();
                   },
                  error: (err) => {
                    console.log('get caards error:', err);
                    this.messageService.add({ severity: 'error', summary: 'Error', detail:  'אינך מורשה לצפות ברשימת הכרטיסים' });
                 }  
                })
               }
                catch {
                 console.log('הבקשה נכשלה');
                 this.messageService.add({ severity: 'error', summary: 'Error', detail: 'הבקשה נכשלה' });
                }

            this.items = [
            {
                icon: 'pi pi-search',
                 label: 'מתנה נרכשת ביותר', 
                command: () => {
                      try {
                        this.cardSrv.getPopularPurchases().subscribe({       
                        next: (response: CardModel[]) => {
                            this.cards = response;
                            console.log("cards",this.cards);
                            this.cdr.markForCheck();
                            //   this.changeRef.markForCheck();
                            },
                         error: (err) => {
                            console.log('get caards error:', err);
                            this.messageService.add({ severity: 'error', summary: 'Error', detail:  'אינך מורשה לצפות ברשימת הכרטיסים' });
                            }  
                        })
                        }
                        
                    catch (error) {
                        console.log('הבקשה נכשלה', error);
                        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'הבקשה נכשלה' });
                         }
                        }
             },
            {
                icon: 'pi pi-search',               
                label: 'מתנה יקרה ביותר', 
                command: () => {                                       
                    try {
                        this.cardSrv.getAllPurchasesOrderedByCost().subscribe({       
                        next: (response: CardModel[]) => {
                            this.cards = response;
                            console.log("cards",this.cards);
                            this.cdr.markForCheck();
                            // this.ngOnInit();
                            //   this.changeRef.markForCheck();
                            },
                         error: (err) => {
                            console.log('get caards error:', err);
                            this.messageService.add({ severity: 'error', summary: 'Error', detail:  'אינך מורשה לצפות ברשימת הכרטיסים' });
                            }  
                        })
                        }
                    catch {
                        console.log('הבקשה נכשלה');
                        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'הבקשה נכשלה' });
                         }
                        }  
                },
                {
                icon: 'pi pi-search',              
                label: 'סדר הרכישה', 
                command: () => {       
                    this.ngOnInit()     
                     this.cdr.markForCheck();                           
                    // try {
                    //     this.cardSrv.getAllPurchasesOrderedByCost().subscribe({       
                    //     next: (response: CardModel[]) => {
                    //         this.cards = response;
                    //         console.log("cards",this.cards);
                    //         this.cdr.markForCheck();
                    //         //   this.changeRef.markForCheck();
                    //         },
                    //      error: (err) => {
                    //         console.log('get caards error:', err);
                    //         this.messageService.add({ severity: 'error', summary: 'Error', detail:  'אינך מורשה לצפות ברשימת הכרטיסים' });
                    //         }  
                    //     })
                    //     }
                    // catch {
                    //     console.log('הבקשה נכשלה');
                    //     this.messageService.add({ severity: 'error', summary: 'Error', detail: 'הבקשה נכשלה' });
                    //      }
                    //     }  
                }
            }
            
           ]      
               
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
