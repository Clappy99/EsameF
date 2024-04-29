import { Injectable } from '@angular/core';
import { environment } from '../../enviroments/enviroment';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Book } from '../models/book.interface';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  GetBook(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.baseUrl}/book/GetBook?id=${id}`);
  }
  GetAllBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseUrl}/book/GetAllBooks`).pipe(
      map((response: Book[]) => {
        return response;
      })
    );
  }
  CreateBook(data: Book): Observable<void> {
    console.log(data)
    return this.http.post<void>(`${this.baseUrl}/book/CreateBook`, data);
  }
  DeleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/book/DeleteBook?id=${id}`);
  }
  UpdateBook(data: Book): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/book/UpdateBook`, data);
  }

}
