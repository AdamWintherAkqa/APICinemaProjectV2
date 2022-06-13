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
  order: IOrder = {
    orderID: 0,
    ageCheck: false,
    orderDate: new Date(),
    movieTimeID: 0,
    seats: [],
    candyShops: [],
    //merchandise: [],
    customerID: 0,
  };

  addMovieTimeToOrder(movieTimeID: number) {
    console.log(movieTimeID);
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
  removeSeatsFromOrder(seat: ISeat) {
    this.order.seats = this.order.seats.filter((x) => x != seat);
  }
  removeCandyShopFromOrder(candyShop: ICandyShop) {
    this.order.candyShops = this.order.candyShops.filter((x) => x != candyShop);
  }
  /* removeMerchandiseFromOrder(merchandise: IMerchandise) {
    this.order.merchandise = this.order.merchandise.filter(
      (x) => x != merchandise
    );
  } */

  clearCart() {
    this.order.movieTimeID = 0;
    this.order.seats = [];
    this.order.candyShops = [];
    //this.order.merchandise = [];
  }

  getCart() {
    return this.order;
  }
}
