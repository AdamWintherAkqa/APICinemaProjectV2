import { Component, OnInit } from '@angular/core';
import { GenreService } from 'src/app/services/genre.service';
import { FormGroup, NgForm } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IGenre from 'src/app/interface/IGenre';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css'],
})
export class GenreComponent implements OnInit {
  constructor(private genreService: GenreService, private dataService: DataService) {}

  genreList: IGenre[];
  checked = false;
  updatedGenre: IGenre;

  ngOnInit(): void {
    this.getGenres();
  }

  genreForm = new FormGroup({
    genreName: new FormControl(''),
  });

  updateForm = new FormGroup({
    updateGenre: new FormControl(''),
  });

  getGenres(): void {
    this.genreList = [];
    this.genreService.getAllGenres().subscribe((data) => {
      this.genreList = data;
    });
  }

  createGenre(): void {
    this.genreForm.value.isAlive = this.checked;
    console.log(this.genreForm.value);
    this.genreService.createGenre(this.genreForm.value).subscribe();

    this.genreList = [...this.genreList, this.genreForm.value];
    this.getGenres();
  }

  isEditEnable: boolean = false;
  onEdit() {
    this.isEditEnable = !this.isEditEnable;
  }

  updateGenre(genre: IGenre) {
    console.log('her er genre', genre);
    this.updatedGenre.genreID = genre.genreID;
    this.updatedGenre.genreName = this.updateForm.value;
    this.genreService.updateGenre(this.updatedGenre).subscribe((response) => {
      console.log(Response);
    });
  }

  deleteGenre(genre: IGenre) {
    this.genreService.deleteGenre(genre).subscribe((response) => {
      this.genreList = this.genreList.filter(
        (item) => item.genreID !== genre.genreID
      );
    });
  }

  passGenre(genre: IGenre) {
    this.dataService.choosenGenre = genre;
  }
}
