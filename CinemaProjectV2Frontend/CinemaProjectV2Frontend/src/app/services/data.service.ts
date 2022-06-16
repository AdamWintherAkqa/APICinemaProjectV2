import { Injectable } from '@angular/core';
import IMovieTime from '../interface/IMovieTime';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public choosenMovieTime: IMovieTime;

  constructor() {}
}
