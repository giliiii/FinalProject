
import { Observable } from 'rxjs';
import { GiftModel } from '../Models/gift';
import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GiftService {
     BASE_URL = 'https://localhost:7097/api/Gifts'; 
      http: HttpClient = inject(HttpClient);

  constructor() {}

  getAllGifts(): Observable<GiftModel[]> {
    return this.http.get<GiftModel[]>(this.BASE_URL);
  }

  getGiftById(id: number): Observable<GiftModel> {
    return this.http.get<GiftModel>(`${this.BASE_URL}/${id}`);
  }

  createGift(gift: GiftModel): Observable<GiftModel> {
    return this.http.post<GiftModel>(this.BASE_URL, gift);
  }

  updateGift(gift: GiftModel): Observable<GiftModel> {
    return this.http.put<GiftModel>(`${this.BASE_URL}/${gift.id}`, gift);
  }

  deleteGift(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.BASE_URL}/${id}`);
  }

  getGiftsByCategory(categoryId: number): Observable<GiftModel[]> {
    return this.http.get<GiftModel[]>(
      `${this.BASE_URL}/category/${categoryId}`
    );
  }

  getGiftsByCost(price1: number, price2: number): Observable<GiftModel[]> {
    return this.http.get<GiftModel[]>(
      `${this.BASE_URL}/cost/${price1}/${price2}`
    );
  }
}
