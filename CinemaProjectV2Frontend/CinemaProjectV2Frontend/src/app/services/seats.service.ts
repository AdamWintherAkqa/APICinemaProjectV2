import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import ISeat from '../interface/ISeat';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class SeatsService {
  baseUrl = 'https://localhost:44324/api/Seats';
  constructor(private http: HttpClient) {} //DI

  getAllSeats(): Observable<ISeat[]> {
    return this.http.get<ISeat[]>(this.baseUrl);
  }
  getSeatByID(id: number): Observable<ISeat> {
    return this.http.get<ISeat>(`${this.baseUrl}/${id}`);
  }
  getEntireSeatByID(id: number): Observable<ISeat> {
    return this.http.get<ISeat>(`${this.baseUrl}/GetEntireSeatByID/${id}`);
  }
  putSeat(seat: ISeat): Observable<ISeat> {
    return this.http.put<ISeat>(`${this.baseUrl}`, seat);
  }
  postSeat(seat: ISeat): Observable<ISeat> {
    return this.http.post<ISeat>(`${this.baseUrl}`, seat);
  }
  deleteSeat(id: number): Observable<ISeat> {
    return this.http.delete<ISeat>(`${this.baseUrl}/${id}`);
  }
  getSeatsWhereHallID(id: number): Observable<ISeat[]> {
    return this.http.get<ISeat[]>(`${this.baseUrl}/GetSeatsWhereHallID/${id}`);
  }
}
