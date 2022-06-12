import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import IInstructor from '../interface/IInstructor';




const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})

export class InstructorService {
  baseUrl = 'https://localhost:44324/api/Instructors';
  constructor(private http: HttpClient) {} //DI

  getAllInstructors(): Observable<IInstructor[]> {
    return this.http.get<IInstructor[]>(this.baseUrl);
  }
  getInstructorByID(id: number): Observable<IInstructor> {
    return this.http.get<IInstructor>(`${this.baseUrl}/${id}`);
  }
  createInstructor(instructor: IInstructor): Observable<IInstructor> {
    return this.http.post<IInstructor>(this.baseUrl, instructor, httpOptions);
  }
  deleteInstructor(instructor: IInstructor): Observable<IInstructor> {
    return this.http.delete<IInstructor>
    (`${this.baseUrl}/${instructor.instructorID}`,
      httpOptions
    );
  }
  updateInstructor(instructor: IInstructor): Observable<IInstructor> {
    return this.http.put<IInstructor>(
      `${this.baseUrl}/${instructor.instructorID}`,
      httpOptions
    );
  }



}






