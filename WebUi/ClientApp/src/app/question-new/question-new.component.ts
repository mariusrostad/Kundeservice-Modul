import { Component, OnInit } from '@angular/core';
import { Question } from '../models/question';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import { Observable } from 'rxjs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  // selector: 'app-question-new',
  templateUrl: './question-new.component.html',
  styleUrls: ['./question-new.component.css']
})
export class QuestionNewComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;

  categories: Observable<Category[]>;

  constructor(private formBuilder: FormBuilder, private sidebarApiService: CategoryService) {
  }

  ngOnInit() {
    this.sidebarApiService.getCategories().subscribe((data) => {
      this.categories = this.sidebarApiService.getCategories();
    });

    this.registerForm = this.formBuilder.group({
      category: ['', Validators.required],
      message: ['', Validators.required],
    });
  }

  onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value, null, 4));
  }

  get f() {
    return this.registerForm.controls;
  }

  onReset() {
    this.submitted = false;
    this.registerForm.reset();
  }

  // onClickSubmit(category, message) {
  //   alert('Your message is : ' + message);
  // }


  // onSubmit() {
  //   this.submitted = true;
  //   alert('Your Email is : ' + questionForm.message);
  // }

  // get diagnostic() {
  //   return JSON.stringify(this.model);
  // }

  // showFormControls(form: any) {
  //   return form && form.controls['name'] &&
  //   form.controls['name'].value; // Dr. IQ
  // }

  // submitQuestion() {
  //   return null;
  // }
}
