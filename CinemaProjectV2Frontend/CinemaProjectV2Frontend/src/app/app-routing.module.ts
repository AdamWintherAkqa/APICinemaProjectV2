import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { AdminComponent } from './components/admin/admin.component';
import { CreateMovieComponent } from './components/create-movie/create-movie.component';
import { BookingComponent } from './components/booking/booking.component';
import { BookMovieTimeComponent } from './components/book-movie-time/book-movie-time.component';
import { CartComponent } from './components/cart/cart.component';
import { CheckoutComponent } from './components/checkout/checkout.component';
import { CandyShopComponent } from './components/candy-shop/candy-shop.component';
import { CreateCandyShopComponent } from './components/create-candy-shop/create-candy-shop.component';
import { EditCandyShopComponent } from './components/edit-candy-shop/edit-candy-shop.component';
import { GenreComponent } from './components/genre/genre.component';
import { ActorComponent } from './components/actor/actor.component';
import { InstructorComponent } from './components/create-instructor/create-instructor.component';

const routes: Routes = [
  { path: '', component: HomepageComponent },
  // { path: 'film', component: FilmComponent },
  { path: 'booking', component: BookingComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'create-movie', component: CreateMovieComponent },
  { path: 'booking/bookmovietime', component: BookMovieTimeComponent },
  { path: 'cart', component: CartComponent },
  { path: 'cart/checkout', component: CheckoutComponent },
  { path: 'candyshop', component: CandyShopComponent },
  { path: 'createcandyshop', component: CreateCandyShopComponent },
  { path: 'createcandyshop/editcandyshop', component: EditCandyShopComponent },
  { path: '**', redirectTo: '' },
  { path: 'create-genre', component: GenreComponent},
  { path: 'create-actor', component: ActorComponent},
  { path: 'create-instructor', component: InstructorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
