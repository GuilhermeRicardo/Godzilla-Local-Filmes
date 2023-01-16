import { movies } from './../../Models/movies';
import { MovieTableService } from './movie-table.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-table',
  templateUrl: './movie-table.component.html',
  styleUrls: ['./movie-table.component.scss'],
  providers: [MovieTableService]
})

export class MovieTableComponent implements OnInit {
  value!: string
  displayedColumns: string[] = ['id', 'titulo', 'diretor', 'estoque'];
  dataSource!: movies[]; 

  constructor (
    public movieTableService: MovieTableService

  ) {
      this.movieTableService.getAll().subscribe((data:movies[]) =>{
        console.log(data);
        this.dataSource = data
      })
  }

ngOnInit(): void {

}

filterDataSource () {

  if(this.value == '') {
    this.movieTableService.getAll().subscribe((data:movies[]) =>{
      console.log(data);
      this.dataSource = data
    })
  }

  this.movieTableService.getSearch(this.value).subscribe((data:movies[]) =>{
    console.log(this.value);
    console.log(data);
    this.dataSource = data
  })
}

clearFilter () {
  
  this.value = ""

  this.movieTableService.getAll().subscribe((data:movies[]) =>{
    console.log(data);
    this.dataSource = data
  })


}

}


