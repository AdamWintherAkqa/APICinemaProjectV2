import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ICandyShop from '../interface/ICandyShop';

@Injectable({
  providedIn: 'root',
})
export class CandyShopService {
  baseUrl = 'https://localhost:44324/api/CandyShops';
  constructor(private http: HttpClient) {} //DI

  getAllCandyShops(): Observable<ICandyShop[]> {
    return this.http.get<ICandyShop[]>(this.baseUrl);
  }
  getCandyShopByID(id: number): Observable<ICandyShop> {
    return this.http.get<ICandyShop>(`${this.baseUrl}/${id}`);
  }
  GetCandyShopAndOrderByID(id: number): Observable<ICandyShop> {
    return this.http.get<ICandyShop>(
      `${this.baseUrl}/GetCandyShopAndOrderByID/${id}`
    );
  }
  putCandyShop(candyShop: ICandyShop): Observable<ICandyShop> {
    return this.http.put<ICandyShop>(`${this.baseUrl}`, candyShop);
  }
  postCandyShop(candyShop: ICandyShop): Observable<ICandyShop> {
    return this.http.post<ICandyShop>(`${this.baseUrl}`, candyShop);
  }
  deleteCandyShop(id: number): Observable<ICandyShop> {
    return this.http.delete<ICandyShop>(`${this.baseUrl}/${id}`);
  }
}
