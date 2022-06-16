import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import IActor from '../interface/IActor';




const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})

export class ActorService {
  baseUrl = 'https://localhost:44324/api/Actors';
  constructor(private http: HttpClient) {} //DI

  getAllActors(): Observable<IActor[]> {
    return this.http.get<IActor[]>(this.baseUrl);
  }
  getActorByID(id: number): Observable<IActor> {
    return this.http.get<IActor>(`${this.baseUrl}/${id}`);
  }
  createActor(actor: IActor): Observable<IActor> {
    return this.http.post<IActor>(this.baseUrl, actor, httpOptions);
  }
  deleteActor(actor: IActor): Observable<IActor> {
    return this.http.delete<IActor>
    (`${this.baseUrl}/${actor.actorID}`,
      httpOptions
    );
  }
  updateActor(actor: IActor): Observable<IActor> {
    return this.http.put<IActor>(
      `${this.baseUrl}/${actor.actorID}`,
      httpOptions
    );
  }



}






