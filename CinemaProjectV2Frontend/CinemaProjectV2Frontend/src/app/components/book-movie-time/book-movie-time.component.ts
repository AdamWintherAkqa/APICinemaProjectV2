import { Component, OnInit } from '@angular/core';
import IMovie from 'src/app/interface/IMovie';
import IMovieTime from 'src/app/interface/IMovieTime';
import ISeat from 'src/app/interface/ISeat';
import { SeatsService } from 'src/app/services/seats.service';
import { OrderService } from 'src/app/services/order.service';
import { DataService } from 'src/app/services/data.service';
import { CartserviceService } from 'src/app/services/cartservice.service';
import IOrder from 'src/app/interface/IOrder';

@Component({
  selector: 'app-book-movie-time',
  templateUrl: './book-movie-time.component.html',
  styleUrls: ['./book-movie-time.component.css'],
})
export class BookMovieTimeComponent implements OnInit {
  constructor(
    private seatsService: SeatsService,
    private dataService: DataService,
    private cartService: CartserviceService,
    private orderService: OrderService
  ) {}
  choosenMovieTime: IMovieTime = this.dataService.choosenMovieTime;
  seatsList: ISeat[] = [];
  reservedSeatsOrder: IOrder[] = [];
  reservedSeats: ISeat[] = [];
  chosenSeats: ISeat[] = [];
  status: boolean = false;

  ngOnInit(): void {
    this.seatsService
      .getSeatsWhereHallID(this.choosenMovieTime.hallID)
      .subscribe((data) => {
        this.seatsList = data;
        console.log('seatsList: ', this.seatsList);
      });
    this.orderService
      .getOrdersWhereMovieTimeID(this.choosenMovieTime.movieTimeID)
      .subscribe((data) => {
        this.reservedSeatsOrder = data;
        this.checkReservedSeats();
        console.log('reserved seats: ', this.reservedSeats);
      });
  }

  checkReservedSeats() {
    this.reservedSeatsOrder.forEach((order) => {
      order.seats.forEach((seat) => {
        this.reservedSeats.push(seat);
      });
    });
  }

  addSeatToChosen(seat: ISeat) {
    if (this.chosenSeats.includes(seat)) {
      this.chosenSeats = this.chosenSeats.filter((x) => x != seat);
    } else {
      this.chosenSeats.push(seat);
    }
    //this.status = !this.status;
    // this.chosenSeats.push(seat);
    console.log('Chosen seats:', this.chosenSeats);
  }

  addToCart() {
    console.log('movietimeID: ', this.choosenMovieTime.movieTimeID);
    this.cartService.addMovieTimeToOrder(this.choosenMovieTime.movieTimeID);
    this.cartService.addSeatsToOrder(this.chosenSeats);
  }

  removeSeatFromChosen(seat: ISeat) {
    this.chosenSeats = this.chosenSeats.filter((x) => x != seat);
    console.log('Chosen seats:', this.chosenSeats);
  }
}
