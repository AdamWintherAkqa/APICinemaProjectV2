import { Component, OnInit } from '@angular/core';
import IMovie from 'src/app/interface/IMovie';
import IActor from 'src/app/interface/IActor';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-film',
  templateUrl: './film.component.html',
  styleUrls: ['./film.component.css'],
})
export class FilmComponent implements OnInit {
  movieList: IMovie[] = [];

  checked = false;

  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.movieService.getEntireMovies().subscribe((data) => {
      console.log(data);
      this.movieList = data;
    });
  }
}
