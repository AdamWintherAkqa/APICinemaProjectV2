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
  timeList: IMovieTime[] = [];

  ngOnInit(): void {
    this.movieService.getMoviesFrontPage().subscribe((data) => {
      this.movieList = data;
      console.log(this.movieTimeList);
      //console.log(this.movieList);
    });

    this.movieTimeService.getEntireMovieTimes().subscribe((data) => {
      this.movieTimeList = data;
      // console.log(this.movieTimeList);
    });
    /*     for (let movie in this.movieList) {
      let movieTime;
      movieTime = this.movieTimeList.filter(
        (x) => x.movie.movieID == movie.movieID
      );
    } */
  }

  findMovieTime(movieID: number) {
    console.log(this.movieTimeList);
    this.timeList = this.movieTimeList.filter(
      (x) => x.movie.movieID == movieID
    );
    console.log('timelist', this.timeList);
  }

  log(val: any) {
    console.log(val);
  }
}
