import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, NgForm, Validators } from '@angular/forms';
import { UserQuestion } from '../models/user-question';
import { Category } from '../models/category';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserQuestionService } from '../services/user-question.service';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.css']
})
export class QuestionFormComponent implements OnInit {
  submitted = false;
  userQuestionForm: FormGroup;
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private _http: HttpClient, private fb: FormBuilder, private userQuestionService: UserQuestionService) {
      this.userQuestionForm = fb.group({
          id: [''],
          firstname: [null, Validators.compose([Validators.required, Validators.pattern('[a-zA-ZøæåØÆÅ\\-. ]{2,30}')])],
          lastname: [null, Validators.compose([Validators.required, Validators.pattern('[a-zA-ZøæåØÆÅ\\-. ]{2,30}')])],
          question: [null, Validators.compose([Validators.required, Validators.pattern('[0-9a-zA-ZøæåØÆÅ\\-. ]{2,30}')])],
          category: [null, Validators.compose([Validators.required, Validators.pattern('[0-9]')])],
      });
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'api/UserQuestions/';
  }

  @Input() categories: Category[];

  ngOnInit() {
  }

  showForm() {
    this.submitted = false;
  }

  onSubmit() {
    const userQuestion = new UserQuestion();

    userQuestion.firstname = this.userQuestionForm.value.firstname;
    userQuestion.lastname = this.userQuestionForm.value.lastname;
    userQuestion.question = this.userQuestionForm.value.question;
    userQuestion.category = this.userQuestionForm.value.category;

    const body: string = JSON.stringify(userQuestion);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    this._http.post(this.myApiUrl + this.myAppUrl, body, { headers: headers })
        .subscribe(
          error => alert(error),
          () => console.log('ferdig post-api/kunde')
    );
    this.userQuestionForm.reset();
  }

  resetForm() {
    this.userQuestionForm.reset();
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.userQuestionForm.value); }

}
