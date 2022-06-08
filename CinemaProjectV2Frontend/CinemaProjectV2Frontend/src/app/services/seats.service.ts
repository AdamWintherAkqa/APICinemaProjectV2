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
  baseUrl = 'https://localhost:44324/api/Order';
  constructor(private http: HttpClient) {} //DI
}
