import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { share } from 'rxjs';
import IMovieTime from '../interface/IMovieTime';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  // choosenMovieTime$: Observable<IMovieTime>;

  public choosenMovieTime: IMovieTime;

  constructor() {
    // this.choosenMovieTime$ = new Observable<IMovieTime>(
    //   (x) => (this.listObserver = x)
    // ).share();
  }
}
