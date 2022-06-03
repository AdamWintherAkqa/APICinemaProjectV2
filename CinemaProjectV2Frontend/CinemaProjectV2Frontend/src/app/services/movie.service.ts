import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import IMovie from '../interface/IMovie';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  //Husk at tjekke swaggers url
  baseUrl = 'https://localhost:44324/api/Movies';
  constructor(private http: HttpClient) {} //DI

  getAllMovies(): Observable<IMovie[]> {
    return this.http.get<IMovie[]>(this.baseUrl);
  }
  getMovieByID(id: number): Observable<IMovie> {
    return this.http.get<IMovie>(`${this.baseUrl}/${id}`);
  }
  getMoviesAndActors(): Observable<IMovie[]> {
    return this.http.get<IMovie[]>(`${this.baseUrl}/GetMoviesAndActors`);
  }
  getMoviesFrontPage(): Observable<IMovie[]> {
    return this.http.get<IMovie[]>(`${this.baseUrl}/GetMoviesFrontPage`);
  }
  getEntireMovies(): Observable<IMovie[]> {
    return this.http.get<IMovie[]>(`${this.baseUrl}/GetEntireMovies`);
  }
  createMovie(movie: IMovie): Observable<IMovie> {
    return this.http.post<IMovie>(this.baseUrl, movie, httpOptions);
  }
  updateMovie(movie: IMovie): Observable<IMovie> {
    return this.http.put<IMovie>(
      `${this.baseUrl}/${movie.MovieID}`,
      movie,
      httpOptions
    );
  }
  deleteMovie(id: number): Observable<IMovie> {
    return this.http.delete<IMovie>(`${this.baseUrl}/${id}`, httpOptions);
  }
}
