import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UserQuestion } from '../models/user-question';
import { Category } from '../models/category';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.css']
})
export class QuestionFormComponent implements OnInit {
  form: FormGroup;
  submitted = false;

  model = new UserQuestion('', 0);

  constructor(
    public formGroup: FormBuilder,
    private http: HttpClient,
  ) {
    this.form = this.formGroup.group({
      question: [''],
      category: [null]
    });
  }

  @Input() categories: Category[];

  ngOnInit() {
  }

  newQuestion() {
    this.model = new UserQuestion('', null);
  }

  onSubmit() {
    // this.submitted = true;

    const formData: any = new FormData();
    formData.append('question', this.form.get('question').value);
    formData.append('category', this.form.get('question').value);

    this.http.post('http://localhost:5000/api/userquestion', formData).subscribe(
      (response) => console.log(response),
      (error) => console.log(error)
    );
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }

}
