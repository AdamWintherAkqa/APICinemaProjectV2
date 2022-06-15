import { Component, OnInit } from '@angular/core';
import IOrder from 'src/app/interface/IOrder';
import { CartserviceService } from 'src/app/services/cartservice.service';
import { DataService } from 'src/app/services/data.service';
import { OrderService } from 'src/app/services/order.service';
import { SeatsService } from 'src/app/services/seats.service';
import ISeat from 'src/app/interface/ISeat';
import { MovieTimeService } from 'src/app/services/movie-time.service';
import IMovieTime from 'src/app/interface/IMovieTime';
import { MovieService } from 'src/app/services/movie.service';
import IMovie from 'src/app/interface/IMovie';
import ICustomer from 'src/app/interface/ICustomer';
import { FormGroup, FormControl } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import ICandyShop from 'src/app/interface/ICandyShop';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  constructor(
    private cartService: CartserviceService,
    private dataService: DataService,
    private movieService: MovieService,
    private movieTimeService: MovieTimeService,
    private customerService: CustomerService
  ) {}
  cart: IOrder;
  movieTime: IMovieTime;
  movie: IMovie;
  postCustomer: ICustomer;

  ngOnInit(): void {
    this.cart = this.cartService.getCart();
    if (this.cart.movieTimeID != 0) {
      console.log('cart: ', this.cart);

      this.movieTimeService
        .getMovieTimeByID(this.cart.movieTimeID)
        .subscribe((data) => {
          this.movieTime = data;
          console.log('movietime: ', this.movieTime);

          this.movieService
            .getMovieByID(this.movieTime.movie.movieID)
            .subscribe((data) => {
              this.movie = data;
              console.log('movie: ', this.movie);
            });
        });
    }
  }

  checkoutForm = new FormGroup({
    customerName: new FormControl(''),
    customerEmail: new FormControl(''),
    customerGender: new FormControl(''),
    customerPassword: new FormControl(''),
    customerIsVIP: new FormControl(''),
  });

  //not working
  createCustomer() {
    if (this.checkoutForm == null) {
      return console.log('checkoutForm is null');
    }
    this.postCustomer = this.checkoutForm.value;
    console.log('ICustomer: ', this.postCustomer);
    console.log('checkoutform: ', this.checkoutForm.value);
    this.customerService.createCustomer(this.postCustomer).subscribe();
  }

  removeSeat(seat: ISeat) {
    this.cartService.removeSeatsFromOrder(seat);
    this.cart = this.cartService.getCart();
  }

  removeCandy(candy: ICandyShop) {
    this.cartService.removeCandyShopFromOrder(candy);
    this.cart = this.cartService.getCart();
  }
}
