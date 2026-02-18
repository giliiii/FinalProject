import { Observable } from 'rxjs';
import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../Models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  BASE_URL = 'https://localhost:7097/api/Users';
  http: HttpClient = inject(HttpClient);

  getUserById(id: number, headers?: HttpHeaders): Observable<UserModel> {
    return this.http.get<UserModel>(`${this.BASE_URL}/${id}`, { headers });
  }
}
