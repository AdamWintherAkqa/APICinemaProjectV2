import { Component, OnInit } from '@angular/core';
import IMovie from 'src/app/interface/IMovie';
import IMovieTime from 'src/app/interface/IMovieTime';
import ISeat from 'src/app/interface/ISeat';
import { SeatsService } from 'src/app/services/seats.service';
import { DataService } from 'src/app/services/data.service';
import { CartserviceService } from 'src/app/services/cartservice.service';

@Component({
  selector: 'app-book-movie-time',
  templateUrl: './book-movie-time.component.html',
  styleUrls: ['./book-movie-time.component.css'],
})
export class BookMovieTimeComponent implements OnInit {
  constructor(
    private seatsService: SeatsService,
    private dataService: DataService,
    private cartService: CartserviceService
  ) {}
  choosenMovieTime: IMovieTime = this.dataService.choosenMovieTime;
  seatsList: ISeat[] = [];
  chosenSeats: ISeat[] = [];

  ngOnInit(): void {
    this.seatsService
      .getSeatsWhereHallID(this.choosenMovieTime.hallID)
      .subscribe((data) => {
        this.seatsList = data;
        console.log('seatsList: ', this.seatsList);
      });
  }

  addSeatToChosen(seat: ISeat) {
    this.chosenSeats.push(seat);
    console.log('Chosen seats:', this.chosenSeats);
  }

  addToCart() {
    this.cartService.addMovieTimeToOrder(this.choosenMovieTime.movieTimeID);
    this.cartService.addSeatsToOrder(this.chosenSeats);
  }
}
