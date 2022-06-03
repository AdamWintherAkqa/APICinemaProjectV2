import { Component, OnInit } from '@angular/core';
import IMovie from 'src/app/interface/IMovie';
import IActor from 'src/app/interface/IActor';
import { MovieService } from 'src/app/services/movie.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Injectable } from '@angular/core';




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

  postMovie(): void {
    this.movieForm.value.isAlive = this.checked;
    console.log(this.movieForm.value);
    this.movieService.createMovie(this.movieForm.value).subscribe();

    this.movieList = [...this.movieList, this.movieForm.value];
  }

  deleteMovie(id: number) {
    this.movieService.deleteMovie(id).subscribe((data: any) => {
      // console.log(data);
    });
    this.movieList = this.movieList.filter((movie) => movie.movieID != id);
    console.log(this.movieList);
  }

  movieForm = new FormGroup({
  MovieName: new FormControl(''),
  MoviePlayTime: new FormControl(''),
  MovieReleaseDate: new FormControl(''),
  MovieAgeLimit: new FormControl(''),
  InstructorID: new FormControl(''),
  MovieIsChosen: new FormControl(''),
  MovieImageURL: new FormControl(''),
  Genre: new FormControl(''),
  Actors: new FormControl('')








  })
}
