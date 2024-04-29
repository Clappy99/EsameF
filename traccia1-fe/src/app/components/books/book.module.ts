import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BooksListComponent } from './books-list/books-list.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { ApiService } from '../../services/api.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    BooksListComponent,
    BookDetailsComponent,
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    BooksListComponent,
    BookDetailsComponent
  ],
  providers: [ ApiService ]
})
export class BookModule { }