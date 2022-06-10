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
    private movieTimeService: MovieTimeService
  ) {}
  cart: IOrder;
  movieTime: IMovieTime;
  movie: IMovie;

  ngOnInit(): void {
    this.cart = this.cartService.getCart();
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
