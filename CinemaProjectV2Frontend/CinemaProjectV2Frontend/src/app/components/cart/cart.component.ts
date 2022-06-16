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
    this.cart = this.cartService.getCart(); //Kører getCart metoden ved startup.
    if (this.cart.movieTimeID != 0) {
      //Hvis der er et movieTimeID i kurven:
      console.log('cart: ', this.cart);

      this.movieTimeService
        .getMovieTimeByID(this.cart.movieTimeID) //får movieTime via ID for at kunne vise ting...
        .subscribe((data) => {
          this.movieTime = data;
          console.log('movietime: ', this.movieTime);

          this.movieService
            .getMovieByID(this.movieTime.movie.movieID) //får movie via ID for at kunne vise f.eks. billede...
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

  createCustomer() {
    //Opret bruger
    if (this.checkoutForm == null) {
      //hvis checkoutForm er null...
      return console.log('checkoutForm is null');
    }
    this.postCustomer = this.checkoutForm.value; //ellers lægger den value af checkoutForm over i postCustomer objektet.
    console.log('ICustomer: ', this.postCustomer);
    console.log('checkoutform: ', this.checkoutForm.value);
    this.customerService.createCustomer(this.postCustomer).subscribe(); //bruger createCustomer fra customerService til at post Customer.
  }

  removeSeat(seat: ISeat) {
    this.cartService.removeSeatsFromOrder(seat); //remove Seat fra kurven
    this.cart = this.cartService.getCart();
  }

  removeCandy(candy: ICandyShop) {
    this.cartService.removeCandyShopFromOrder(candy); //fjerner slik fra kurven.
    this.cart = this.cartService.getCart(); //
  }
}
