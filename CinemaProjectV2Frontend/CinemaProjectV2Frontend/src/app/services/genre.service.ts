import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import IGenre from '../interface/IGenre';
import IInstructor from '../interface/IInstructor';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})

export class GenreService {
  baseUrl = 'https://localhost:44324/api/Genres';
  constructor(private http: HttpClient) {} //DI

  getAllGenres(): Observable<IGenre[]> {
    return this.http.get<IGenre[]>(this.baseUrl);
  }

  getGenreByID(id: number): Observable<IGenre> {
    return this.http.get<IGenre>(`${this.baseUrl}/${id}`);
  }

  getGenreAndMovieByID(id: number): Observable<IGenre> {
    return this.http.get<IGenre>(`${this.baseUrl}/GetGenreAndMovieByID/${id}`);
  }
  createGenre(genre: IGenre): Observable<IGenre> {
    return this.http.post<IGenre>(this.baseUrl, genre, httpOptions);
  }
  deleteGenre(genre: IGenre): Observable<IGenre> {
    return this.http.delete<IGenre>
    (`${this.baseUrl}/${genre.genreID}`,
      httpOptions
    )
  }


}


