import { Injectable } from '@angular/core';
import IMovieTime from '../interface/IMovieTime';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  constructor() {}

  public choosenMovieTime: IMovieTime;
}
