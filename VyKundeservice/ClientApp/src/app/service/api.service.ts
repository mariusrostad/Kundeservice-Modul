import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Category } from '../models/category';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  url: string;
  uri: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) {
    this.url = environment.appUrl;
    this.uri = 'api/Faq/';
  }

  getFaq(): Observable<Category[]> {
    return this.http.get<Category[]>(this.url + this.uri)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
