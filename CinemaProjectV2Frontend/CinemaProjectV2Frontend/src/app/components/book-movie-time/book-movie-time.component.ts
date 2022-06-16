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
  filteredSeats: ISeat[] = [];
  cart: IOrder;

  ngOnInit(): void {
    this.cart = this.cartService.getCart(); //Får cart som objekt
    this.seatsService //Kalder seatservice
      .getSeatsWhereHallID(this.choosenMovieTime.hallID) //Kalder controller GetSetsWhereHallID
      .subscribe((data) => {
        this.seatsList = data; //Putter det over i en liste.
        this.orderService
          .getOrdersWhereMovieTimeID(this.choosenMovieTime.movieTimeID) //Ser hvilke sæder der er bestilt.
          .subscribe((data) => {
            this.reservedSeatsOrder = data; //Putter de reserverede sæder over i en liste.
            this.checkReservedSeats(); //kalder metoden checkReservedSeats.
            console.log('reserved seats: ', this.reservedSeats);
          });
        console.log('seatsList: ', this.seatsList);
      });
  }

  checkReservedSeats() {
    if (this.reservedSeatsOrder != null) {
      //Hvis der er orders med reservede sæder kører den de næste to metoder:
      this.pushReservedSeats();
      this.filterSeatsList();
    }
  }

  filterSeatsList() {
    console.log('seatsList before: ', this.seatsList);
    this.reservedSeats.forEach((seat) => {
      //For hvert sæde der er reserveret --
      this.seatsList = this.seatsList.filter((x) => x.seatID != seat.seatID); //Filtrer på de reserverede sæder via seatID så man ikke kan se dem.
      console.log('seatsList after: ', this.seatsList);
    });
    this.filteredSeats = this.seatsList; //Bruges ikke.
    console.log('filtered seats: ', this.filteredSeats);
  }

  pushReservedSeats() {
    this.reservedSeatsOrder.forEach((order) => {
      //For hvert sæde der er bestilt--
      order.seats.forEach((seat) => {
        //Putter det over i en liste af sæder så sæder og reserverede sæder kan sammenlignes.
        this.reservedSeats.push(seat);
      });
    });
    console.log('reserved seats: ', this.reservedSeats);
  }

  addSeatToChosen(seat: ISeat) {
    if (this.chosenSeats.includes(seat)) {
      //Hvis det valgte sæde er inkluderet, bliver den fjernet fra chosenseat.
      this.chosenSeats = this.chosenSeats.filter((x) => x != seat);
    } else {
      this.chosenSeats.push(seat); //Ellers bliver den pushet til chosenseat.
    }
    //this.status = !this.status;
    // this.chosenSeats.push(seat);
    console.log('Chosen seats:', this.chosenSeats);
  }

  addToCart() {
    console.log('movietimeID: ', this.choosenMovieTime.movieTimeID);
    this.cartService.addMovieTimeToOrder(this.choosenMovieTime.movieTimeID); //Kalder cartServices og en metode -- som er den movieTime der klikkes på.
    this.cartService.addSeatsToOrder(this.chosenSeats); //Kalder cartService og tilføjer de seats der er valgt.
  }

  removeSeatFromChosen(seat: ISeat) {
    this.chosenSeats = this.chosenSeats.filter((x) => x != seat); //Filterer det seat der klikkes på...
    console.log('Chosen seats:', this.chosenSeats);
  }
}
