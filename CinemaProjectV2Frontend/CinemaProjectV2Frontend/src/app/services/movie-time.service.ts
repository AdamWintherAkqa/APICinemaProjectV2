import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import IMovieTime from '../interface/IMovieTime';
import IMovie from '../interface/IMovie';
import { MovieService } from './movie.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class MovieTimeService {
  baseUrl = 'https://localhost:44324/api/MovieTimes';
  constructor(private http: HttpClient) {} //DI

  getAllMovieTimes(): Observable<IMovieTime[]> {
    return this.http.get<IMovieTime[]>(this.baseUrl);
  }

  getMovieTimeByID(id: number): Observable<IMovieTime> {
    return this.http.get<IMovieTime>(`${this.baseUrl}/${id}`);
  }

  getEntireMovieTimes(): Observable<IMovieTime[]> {
    return this.http.get<IMovieTime[]>(`${this.baseUrl}/GetEntireMovieTimes`);
  }

  createMovieTime(movieTime: IMovieTime): Observable<IMovieTime> {
    return this.http.post<IMovieTime>(this.baseUrl, movieTime, httpOptions);
  }

  updateMovieTime(movieTime: IMovieTime): Observable<IMovieTime> {
    return this.http.put<IMovieTime>(
      `${this.baseUrl}/${movieTime.movieTimeID}`,
      movieTime,
      httpOptions
    );
  }

  deleteMovieTime(id: number): Observable<IMovieTime> {
    return this.http.delete<IMovieTime>(`${this.baseUrl}/${id}`, httpOptions);
  }
}
