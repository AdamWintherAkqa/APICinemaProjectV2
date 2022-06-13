import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import ICustomer from '../interface/ICustomer';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  baseUrl = 'https://localhost:44324/api/Customers';
  constructor(private http: HttpClient) {}

  getCustomerByEmail(email: string): Observable<ICustomer> {
    return this.http.get<ICustomer>(
      `${this.baseUrl}/getCustomerByEmail/${email}`
    );
  }
  createCustomer(customer: ICustomer): Observable<ICustomer> {
    console.log('customer: ', customer);
    return this.http.post<ICustomer>(this.baseUrl, customer, httpOptions);
  }
  updateCustomer(customer: ICustomer): Observable<ICustomer> {
    return this.http.put<ICustomer>(
      `${this.baseUrl}/${customer.customerID}`,
      customer,
      httpOptions
    );
  }
  deleteCustomer(id: number): Observable<ICustomer> {
    return this.http.delete<ICustomer>(`${this.baseUrl}/${id}`, httpOptions);
  }
  getCustomerByEmailAndPassword(
    email: string,
    password: string
  ): Observable<ICustomer> {
    return this.http.get<ICustomer>(
      `${this.baseUrl}/GetCustomerByEmailAndPassword/${email}/${password}`
    );
  }
}
