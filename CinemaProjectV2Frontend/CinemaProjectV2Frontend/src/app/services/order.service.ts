import { Injectable } from '@angular/core';
import { Observable, ObservedValuesFromArray } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import IOrder from '../interface/IOrder';
import IOrderNaked from '../interface/IOrderNaked';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  baseUrl = 'https://localhost:44324/api/Orders';
  constructor(private http: HttpClient) {} //DI

  getAllOrders(): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.baseUrl);
  }
  getOrderByID(id: number): Observable<IOrder> {
    return this.http.get<IOrder>(`${this.baseUrl}/${id}`);
  }
  getEntireOrderByID(id: number): Observable<IOrder> {
    return this.http.get<IOrder>(`${this.baseUrl}/GetEntireOrderByID/${id}`);
  }
  getOrdersWhereMovieTimeID(id: number): Observable<IOrder[]> {
    return this.http.get<IOrder[]>(
      `${this.baseUrl}/GetOrdersWhereMovieTimeID/${id}`
    );
  }
  putOrder(order: IOrder): Observable<IOrder> {
    return this.http.put<IOrder>(`${this.baseUrl}`, order);
  }
  postOrder(order: IOrder): Observable<IOrder> {
    return this.http.post<IOrder>(`${this.baseUrl}`, order);
  }
  postAndPutOrder(order: IOrderNaked): Observable<IOrderNaked> {
    return this.http.post<IOrderNaked>(
      `${this.baseUrl}/PostAndPutOrder/`,
      order
    );
  }
  deleteOrder(id: number): Observable<IOrder> {
    return this.http.delete<IOrder>(`${this.baseUrl}/${id}`);
  }
}
