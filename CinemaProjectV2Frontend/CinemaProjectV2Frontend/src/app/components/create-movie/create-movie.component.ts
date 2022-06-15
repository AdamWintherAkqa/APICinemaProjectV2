import { Component, OnInit } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IMovie from 'src/app/interface/IMovie';
import { MovieService } from 'src/app/services/movie.service';
import { InstructorService } from 'src/app/services/instructor.service';
import IInstructor from 'src/app/interface/IInstructor';
import IGenre from 'src/app/interface/IGenre';
import { GenreService } from 'src/app/services/genre.service';
import IActor from 'src/app/interface/IActor';
import { ActorService } from 'src/app/services/actor.service';

@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css'],
})
export class CreateMovieComponent implements OnInit {
  movieList: IMovie[] = [];
  instructorList: IInstructor[] = [];
  genreList: IGenre[] = [];
  actorList: IActor[] = [];
  checked = false;
  postMovie: IMovie;
  chosenGenre: IGenre;
  chosenActor: IActor;
  movieToBePosted: any;

  constructor(
    private movieService: MovieService,
    private genreService: GenreService,
    private instructorService: InstructorService,
    private actorService: ActorService
  ) {}

  ngOnInit(): void {
    this.getAllMovies();

    this.genreList = [];
    this.genreService.getAllGenres().subscribe((data) => {
      this.genreList = data;
    });

    this.instructorList = [];
    this.instructorService.getAllInstructors().subscribe((data) => {
      this.instructorList = data;
    });

    this.actorList = [];
    this.actorService.getAllActors().subscribe((data) => {
      this.actorList = data;
    });
  }

  // selected = "----"

  // update(e : any){
  //   this.selected = e.target.value
  // }

  createForm = new FormGroup({
    movieName: new FormControl(''),
    moviePlayTime: new FormControl(''),
    movieReleaseDate: new FormControl(''),
    movieAgeLimit: new FormControl(''),
    movieDescription: new FormControl(''),
    movieIsChosen: new FormControl(''),
    movieImageURL: new FormControl(''),
    genreID: new FormControl(''),
    actorID: new FormControl(''),
    instructorID: new FormControl(''),
  });

  getAllMovies(): void {
    this.movieList = [];
    this.movieService.getAllMovies().subscribe((data) => {
      console.log(data);
    });
    console.log(this.movieList);
  }

  createMovie(): void {
    console.log(this.createForm.value);
    this.postMovie = this.createForm.value;
    this.movieService.createMovie(this.postMovie).subscribe();
    // console.log(this.postMovie);
    // this.movieList = [...this.movieList, this.createForm.value];
    this.getAllMovies();
  }

  postAndPutMovie(): void {
    this.movieToBePosted = this.createForm.value;
    this.genreService
      .getGenreByID(this.movieToBePosted.genreID)
      .subscribe((data) => {
        this.chosenGenre = data;
        console.log(this.chosenGenre);
        this.postMovie.genre = this.chosenGenre;
        console.log('Her er movie', this.postMovie);
      });
    this.actorService
      .getActorByID(this.movieToBePosted.actorID)
      .subscribe((data) => {
        this.chosenActor = data;
        console.log(this.chosenActor);
        this.postMovie.actors = this.chosenActor;
        console.log('Her er movie', this.postMovie);
      });

    this.postMovie = {
      movieID: 0,
      movieName: this.movieToBePosted.movieName,
      movieAgeLimit: this.movieToBePosted.movieAgeLimit,
      movieImageURL: this.movieToBePosted.movieImageURL,
      movieIsChosen: this.movieToBePosted.movieIsChosen,
      moviePlayTime: this.movieToBePosted.moviePlayTime,
      movieReleaseDate: this.movieToBePosted.movieReleaseDate,
      instructorID: this.movieToBePosted.instructorID,

      actors: this.chosenActor,
      genre: this.chosenGenre,
    };

    // this.postMovie.actors = this.chosenActor;
    // this.postMovie.genre = this.chosenGenre;
    console.log('Her er movie', this.postMovie);

    this.movieService.postAndPutMovie(this.postMovie).subscribe((data) => {
      console.log('Output', this.postMovie);
    });
  }

  logForm(): void {
    console.log(this.createForm.value);
  }
}
