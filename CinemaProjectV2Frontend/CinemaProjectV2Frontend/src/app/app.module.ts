import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { FilmComponent } from './components/film/film.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './components/admin/admin.component';
import { CreateMovieComponent } from './components/create-movie/create-movie.component';


@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    FilmComponent,
    AdminComponent,
    CreateMovieComponent,

  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],

  providers: [],

  bootstrap: [
    AppComponent
  ],
})




export class AppModule {}
