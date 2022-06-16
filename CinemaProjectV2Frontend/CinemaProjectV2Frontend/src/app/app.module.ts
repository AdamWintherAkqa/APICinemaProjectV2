import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminComponent } from './components/admin/admin.component';
import { CreateMovieComponent } from './components/create-movie/create-movie.component';
import { BookingComponent } from './components/booking/booking.component';
import { BookMovieTimeComponent } from './components/book-movie-time/book-movie-time.component';
import { GenreComponent } from './components/genre/genre.component';
import { ActorComponent } from './components/actor/actor.component';
import { InstructorComponent } from './components/create-instructor/create-instructor.component';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    BookingComponent,
    AdminComponent,
    CreateMovieComponent,
    BookMovieTimeComponent,
    GenreComponent,
    InstructorComponent,
    ActorComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],

  providers: [],

  bootstrap: [AppComponent],
})
export class AppModule {}
