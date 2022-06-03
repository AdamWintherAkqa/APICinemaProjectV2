import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomepageComponent } from './components/homepage/homepage.component';
// import { FilmComponent } from './components/film/film.component';
import { AdminComponent } from './components/admin/admin.component';
import { CreateMovieComponent } from './components/create-movie/create-movie.component';


const routes: Routes = [
  { path: '', component: HomepageComponent },
  // { path: 'film', component: FilmComponent },
  { path: 'admin', component: AdminComponent},
  { path: 'create-movie', component: CreateMovieComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
