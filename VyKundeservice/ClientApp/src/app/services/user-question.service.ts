import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserQuestion } from '../models/user-question';
import { Observable, throwError } from 'rxjs';
import { FormBuilder } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserQuestionService {
  myAppUrl: string;
  myApiUrl: string;

  constructor(private _http: HttpClient, private fb: FormBuilder) {
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/UserQuestions/';
  }

  getAllUserQuestions(): Observable<UserQuestion[]> {
    return this._http.get<UserQuestion[]>(this.myAppUrl + this.myApiUrl);
  }

  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
