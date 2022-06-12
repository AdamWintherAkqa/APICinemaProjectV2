import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IMovie from 'src/app/interface/IMovie';
import { MovieService } from 'src/app/services/movie.service';



@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css']
})
export class CreateMovieComponent implements OnInit {
  movieList: IMovie[] = [];

  checked = false;

  constructor(private movieService : MovieService) { }

  ngOnInit(): void {
  }
  createMovie(): void {
    this.createForm.value.isAlive = this.checked;
    console.log(this.createForm.value);
    this.movieService.createMovie(this.createForm.value).subscribe();

    this.movieList = [...this.movieList, this.createForm.value];
  }

  createForm = new FormGroup({
    movieName: new FormControl(''),
    moviePlayTime: new FormControl(''),
    movieReleaseDate: new FormControl(''),
    movieAgeLimit: new FormControl(''),
    instructorID: new FormControl(''),
    movieIsChosen: new FormControl(''),
    movieImageURL: new FormControl(''),
    genre: new FormControl(''),
    actors: new FormControl(''),
    movieDescription: new FormControl('')


})
}
