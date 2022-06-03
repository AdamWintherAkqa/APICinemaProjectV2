import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { MovieTimeService } from 'src/app/services/movie-time.service';
import IMovie from 'src/app/interface/IMovie';
import IOrder from 'src/app/interface/IOrder';
import { OrderService } from '../../services/order.service';
import IMovieTime from 'src/app/interface/IMovieTime';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  constructor(
    private movieService: MovieService,
    private movieTimeService: MovieTimeService
  ) {}
  movieList: IMovie[] = [];
  movieTimeList: IMovieTime[] = [];

  ngOnInit(): void {
    this.movieService.getMoviesFrontPage().subscribe((data) => {
      this.movieList = data;
      //console.log(this.movieList);
    });

    this.movieTimeService.getAllMovieTimes().subscribe((data) => {
      this.movieTimeList = data;
      console.log(this.movieTimeList);
    });
  }
}
