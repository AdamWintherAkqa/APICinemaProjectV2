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
import IActor from 'src/app/interface/IActor'
import { ActorService } from 'src/app/services/actor.service';



@Component({
  selector: 'app-create-movie',
  templateUrl: './create-movie.component.html',
  styleUrls: ['./create-movie.component.css']
})
export class CreateMovieComponent implements OnInit {
  movieList: IMovie[] = [];
  instructorList: IInstructor[] = [];
  genreList: IGenre[] = [];
  actorList:IActor[];
  checked = false;
  postMovie: IMovie;



  constructor(private movieService : MovieService, private genreService : GenreService, private instructorService : InstructorService, private actorService : ActorService) { }

  ngOnInit(): void {
    this.getAllMovies();

      this.genreList = [];
      this.genreService.getAllGenres().subscribe((data) => { this.genreList = data; });
      this.instructorList = [];
      this.instructorService.getAllInstructors().subscribe((data) => { this.instructorList = data; });
      this.actorList = [];
      this.actorService.getAllActors().subscribe((data) => { this.actorList = data; });



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
    // genre: new FormControl(''),
    // actors: new FormControl(''),
    instructorID: new FormControl('')

})

getAllMovies(): void {
  this.movieList = [];
  this.movieService.getAllMovies().subscribe((data) => { console.log(data) });
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



logForm(): void {
console.log(this.createForm.value)
}


}

