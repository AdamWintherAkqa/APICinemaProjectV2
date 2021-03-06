import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../services/movie.service';
import { MovieTimeService } from 'src/app/services/movie-time.service';
import IMovie from 'src/app/interface/IMovie';
import IOrder from 'src/app/interface/IOrder';
import { OrderService } from '../../services/order.service';
import IMovieTime from 'src/app/interface/IMovieTime';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css'],
})
export class BookingComponent implements OnInit {
  constructor(
    private movieService: MovieService,
    private movieTimeService: MovieTimeService,
    private dataService: DataService
  ) {}

  movieList: IMovie[] = [];
  movieTimeList: IMovieTime[] = [];
  timeList: IMovieTime[] = [];
  isEditEnable: boolean = false;

  ngOnInit(): void {
    this.movieService.getMoviesFrontPage().subscribe((data) => {
      //På startup laver den en getMoviesFrontPage (title, spilletid, actors, id osv)
      this.movieList = data;
      console.log(this.movieTimeList);
      //console.log(this.movieList);
    });

    this.movieTimeService.getEntireMovieTimes().subscribe((data) => {
      //Getter alle Movietimes på startup.
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
    //Filtrer MovieTimes for at vise den specifikke movietime på den specifikke movie.
    console.log(this.movieTimeList);
    this.timeList = this.movieTimeList.filter(
      (x) => x.movie.movieID == movieID
    );
    console.log('timelist', this.timeList);
  }

  passMovieTime(movieTime: IMovieTime) {
    this.dataService.choosenMovieTime = movieTime;
    console.log('choosen movietime: ', this.dataService.choosenMovieTime); // Lægger ID over i en variabel som ligger i en service som hedder DataService (ChoosenMovieTime)
  }

  log(val: any) {
    console.log(val);
  }
}
