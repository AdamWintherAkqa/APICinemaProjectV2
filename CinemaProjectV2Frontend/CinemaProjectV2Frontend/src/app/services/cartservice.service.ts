import { Injectable } from '@angular/core';
import IOrder from '../interface/IOrder';
import ISeat from '../interface/ISeat';
import IMovieTime from '../interface/IMovieTime';
import ICandyShop from '../interface/ICandyShop';

@Injectable({
  providedIn: 'root',
})
export class CartserviceService {
  constructor() {}
  order: IOrder;

  addMovieTimeToOrder(movieTimeID: number) {
    this.order.movieTimeID = movieTimeID;
  }
  addSeatsToOrder(seat: ISeat[]) {
    seat.forEach((seat) => this.order.seats.push(seat));
  }
  addCandyShopToOrder(candyShop: ICandyShop[]) {
    candyShop.forEach((candyShop) => this.order.candyShops.push(candyShop));
  }
  /* addMerchandiseToOrder(merchandise: IMerchandise[]) {
    merchandise.forEach((merchandise) =>
      this.order.merchandise.push(merchandise)
    );
  } */
  addCustomerToOrder(customerID: number) {
    this.order.customerID = customerID;
  }

  getOrder() {
    return this.order;
  }
}
