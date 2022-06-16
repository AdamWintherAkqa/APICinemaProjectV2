import { Injectable } from '@angular/core';
import ICandyShop from '../interface/ICandyShop';
import IMovieTime from '../interface/IMovieTime';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public choosenMovieTime: IMovieTime;
  public choosenCandyShop: ICandyShop;

  constructor() {}
}
