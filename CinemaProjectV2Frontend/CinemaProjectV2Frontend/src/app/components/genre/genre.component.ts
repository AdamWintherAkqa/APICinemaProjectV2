import { Component, OnInit } from '@angular/core';
import { GenreService } from 'src/app/services/genre.service';
import { FormGroup, NgForm } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IGenre from 'src/app/interface/IGenre';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {

  constructor(private genreService : GenreService) { }

  genreList: IGenre[];
  checked = false;


  ngOnInit(): void {
   this.getGenres();


    }




    genreForm = new FormGroup({
    genreName: new FormControl('')
  })
  getGenres(): void {
    this.genreList = [];
    this.genreService.getAllGenres().subscribe((data) => { this.genreList = data; });
  }
  isEditEnable: boolean = false;
  updateGenre() {
  this.isEditEnable = !this.isEditEnable;
  }


  createGenre(): void {
    this.genreForm.value.isAlive = this.checked;
    console.log(this.genreForm.value);
    this.genreService.createGenre(this.genreForm.value).subscribe();

    this.genreList = [...this.genreList, this.genreForm.value];
    this.getGenres();
  }

  deleteGenre(genre: IGenre)
  {
    this.genreService.deleteGenre(genre)
      .subscribe(response =>
        {
        this.genreList = this.genreList.filter(item => item.genreID !== genre.genreID);
        }

        );



  }






}



