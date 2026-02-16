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
                label: '🎁הגרלת מתנות',
                command: () => this.selectercomponent = 'rand'
            }
        ];
}


}