import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, NgForm } from '@angular/forms';
import { UserQuestion } from '../models/user-question';
import { Category } from '../models/category';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.css']
})
export class QuestionFormComponent implements OnInit {
  submitted = false;

  model = new UserQuestion('', null);

  constructor(
    // public formGroup: FormBuilder,
    private http: HttpClient
  ) {
  }

  @Input() categories: Category[];

  ngOnInit() {
  }

  showForm() {
    this.submitted = false;
  }

  newQuestion() {
    this.model = new UserQuestion('', null);
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.submitted = true;
    } else {
      return;
    }

    const formData: any = new FormData();
    formData.append('question', form.form.get('question').value);
    formData.append('category', form.form.get('category').value);

    this.http.post(environment.appUrl + 'api/userquestions', formData).subscribe(
      (response) => console.log(response),
      (error) => console.log(error)
    );
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

}
