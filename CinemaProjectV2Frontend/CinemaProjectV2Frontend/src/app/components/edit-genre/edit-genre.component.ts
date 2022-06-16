import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import IGenre from 'src/app/interface/IGenre';
import { DataService } from 'src/app/services/data.service';
import { GenreService } from 'src/app/services/genre.service';

@Component({
  selector: 'app-edit-genre',
  templateUrl: './edit-genre.component.html',
  styleUrls: ['./edit-genre.component.css'],
})
export class EditGenreComponent implements OnInit {
  constructor(
    private dataService: DataService,
    private genreService: GenreService
  ) {}
  genre: IGenre;

  ngOnInit(): void {
    this.genre = this.dataService.choosenGenre;
  }

  editGenreForm = new FormGroup({
    genreName: new FormControl(this.dataService.choosenGenre.genreName),
  });

  updateGenre() {
    this.genre = this.editGenreForm.value;
    this.genre.genreID = this.dataService.choosenGenre.genreID;
    this.genreService.updateGenre(this.genre).subscribe();
  }
}
