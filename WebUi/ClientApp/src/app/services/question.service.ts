import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { Question } from '../models/question';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/Questions/';
  }

  getQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getQuestion(categoryId: Number): Observable<Question> {
      return this.http.get<Question>(this.myAppUrl + this.myApiUrl + categoryId)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );
  }

  getQuestionsFromCategory(categoryId: Number): Observable<Question[]> {
    return this.http.get<Question[]>('http://localhost:5000/api/CategoryQuestions/' + categoryId)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  saveQuestion(category: any): Observable<Question> {
      return this.http.post<Question>(this.myAppUrl + this.myApiUrl, JSON.stringify(category), this.httpOptions)
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
