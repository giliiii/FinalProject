import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import path from 'path';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {  DonorManage  } from '../donor-manage/donor-manage';
import { GiftManage} from '../gift-manage/gift-manage';
import { CardManage } from '../card-manage/card-manage';
import { RandManage } from '../rand-manage/rand-manage';
import { HttpHeaders } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';
import { BasketService } from '../../../Services/basket-service';
import { Router } from '@angular/router';
import {  inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SelectModule } from 'primeng/select';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { RippleModule } from 'primeng/ripple';
import { SelectItem } from 'primeng/api';
import { DataViewModule } from 'primeng/dataview';
import { SelectButtonModule } from 'primeng/selectbutton';
import { PanelModule } from 'primeng/panel';
import { GiftModel } from '../../../Models/gift';
import { GiftService } from '../../../Services/gift-service';
import { DonorService } from '../../../Services/donor-service';
import { DonorModel } from '../../../Models/donor';
import {  CurrencyPipe } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { HttpClient} from '@angular/common/http';

import { DialogModule } from 'primeng/dialog';
import { categoryModel } from '../../../Models/category';
import { CategoryService } from '../../../Services/category-service';
import { error, log } from 'console';

import { CardService } from '../../../Services/card-service';
import { BasketModel } from '../../../Models/basket';

import { DrawerModule } from 'primeng/drawer';  // הוסף את היבוא הזה


const routes: Routes = [
  { path: '', redirectTo: '/manager/home', pathMatch: 'full' },
  { path: 'manager/donors', component: DonorManage },
  { path: 'manager/gifts', component: GiftManage },
  { path: 'manager/cards', component: CardManage },

];

@Component({
  selector: 'app-manager-home',
  standalone: true,
  imports: [CommonModule, MenubarModule,GiftManage,DonorManage,CardManage,RandManage],
  templateUrl: './home.html',
  styleUrls: ['./home.scss'],
})
export class Home implements OnInit {  
items: MenuItem[] = [];
selectercomponent: string = 'home';
  router = inject(Router);
ngOnInit() {
        this.items = [
            {
                label: 'דף הבית',
                icon: 'pi pi-fw pi-home',
                command: () => this.selectercomponent = 'home'
            },
            {
                label: 'ניהול תורמים',
                icon: 'pi pi-fw pi-users',
                command: () => this.selectercomponent = 'donors'
            },
            {
                label: 'ניהול מתנות',
                icon: 'pi pi-fw pi-gift',
                command: () => this.selectercomponent = 'gifts'
            },
            {
                label: 'ניהול כרטיסים',
                icon: 'pi pi-fw pi-ticket',
                command: () => this.selectercomponent = 'cards'
            },
            {
                label: 'הגרלת מתנות',
                icon: 'pi pi-fw pi-random',
                command: () => this.selectercomponent = 'rand'
            }
        ];
}


}