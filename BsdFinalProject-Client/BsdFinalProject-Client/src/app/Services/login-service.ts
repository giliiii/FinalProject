import { Observable } from 'rxjs';
import { LoginModel } from '../Models/login';
import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root',
})
export class LoginService {
  BASE_URL = 'https://localhost:7097/api/Users';
  http: HttpClient = inject(HttpClient);
  constructor() { }

  login(item:LoginModel): Observable<string> {
    return this.http.post<string>(`${this.BASE_URL}/login`, item);
  }
}
