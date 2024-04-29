import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../../models/book.interface';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrl: './books-list.component.scss'
})
export class BooksListComponent implements OnInit{
  constructor(private apiService: ApiService, private router: Router){}

  items: any = []

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.apiService.GetAllBooks().subscribe({
      next: (response) => {
        this.items = response;
      },
      error: (error) => console.error(error)
    })
  }

  create(){
    this.router.navigateByUrl("/books/new");
  }

  delete(id: number){
    this.apiService.DeleteBook(id).subscribe({complete: () => this.getAll() });
    
  }
}
