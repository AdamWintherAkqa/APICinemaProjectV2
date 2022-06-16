import { Injectable } from '@angular/core';
import ICandyShop from '../interface/ICandyShop';
import IGenre from '../interface/IGenre';
import IMovieTime from '../interface/IMovieTime';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public choosenMovieTime: IMovieTime;
  public choosenCandyShop: ICandyShop;
  public choosenGenre: IGenre;

  constructor() {}
}
