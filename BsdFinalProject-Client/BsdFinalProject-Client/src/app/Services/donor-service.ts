import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {DonorModel} from '../Models/donor'
import { HttpClient, HttpParams } from '@angular/common/http';
import { inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DonorService {
    BASE_URL = 'https://localhost:7097/api/Donors';
  http: HttpClient = inject(HttpClient);
  constructor() { }

  createDonor(item:DonorModel): Observable<DonorModel> {
    return this.http.post<DonorModel>(`${this.BASE_URL}`, item);
  }

  updateDonor(item: DonorModel): Observable<DonorModel> {
    return this.http.put<DonorModel>(`${this.BASE_URL}`, item);
  }

  getDonors(): Observable<DonorModel[]> {
     return this.http.get<DonorModel[]>(this.BASE_URL);
  }

  getOneDonor(id: number): Observable<DonorModel> {
     return this.http.get<DonorModel>(`${this.BASE_URL}/${id}`);
  }

  deleteDonor(id: Number): Observable<DonorModel> {
    return this.http.delete<DonorModel>(`${this.BASE_URL}/${id}`);
  }

  
}
