
import { MenuComponent } from './components/menu/menu.component';
import { MovieTableComponent } from './components/movie-table/movie-table.component';
import { HomeComponent } from './Views/home/home.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'movie-table', component: MovieTableComponent},
  { path: 'menu', component: MenuComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
