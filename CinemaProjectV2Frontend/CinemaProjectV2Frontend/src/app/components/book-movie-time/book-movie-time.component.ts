import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-book-movie-time',
  templateUrl: './book-movie-time.component.html',
  styleUrls: ['./book-movie-time.component.css'],
})
export class BookMovieTimeComponent implements OnInit {
  constructor(private dataService: DataService) {}
  choosenMovieTime = this.dataService.choosenMovieTime;

  ngOnInit(): void {}
}
