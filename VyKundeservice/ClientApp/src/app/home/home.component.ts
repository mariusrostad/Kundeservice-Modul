import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Observable, Subject } from 'rxjs';
import { Category } from '../models/category';
import { RatingService } from '../services/rating.service';
import { Question } from '../models/question';
import { retry, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  categories: Category[];
  allreadyVoted: Array<Number> = [];

  constructor(private categoryService: CategoryService, private ratingService: RatingService, private http: HttpClient) { }

  ngOnInit() {
    this.categoryService.getCategories().subscribe(users => this.categories = users);
    // this.categoryService.getCategories().subscribe((data) => {
    //   this.categories = this.categoryService.getCategories().subscribe(response => this.categories = response);
    // });
  }

  like(id: number) {
    let used = false;
    this.allreadyVoted.forEach(element => {
      if (element === id) {
        used = true;
        return;
      }
    });
    if (!used) {
      const returnFlag = this.ratingService.like(id);
      if (returnFlag) {
        this.changeRating(id, true);
      }
    }
  }

  dislike(id: number) {
    let used = false;
    this.allreadyVoted.forEach(element => {
      if (element === id) {
        used = true;
        return;
      }
    });
    if (!used) {
      const returnFlag = this.ratingService.dislike(id);
      if (returnFlag) {
        this.changeRating(id, false);
      }
    }
  }

  private changeRating(id: Number, increment: Boolean) {
    let question: any;

    if (increment) {
      question = document.getElementById('question-' + id + '-likes');
    } else {
      question = document.getElementById('question-' + id + '-dislikes');
    }

    let value = parseInt(question.innerText, 10);
    value++;
    question.innerText = value.toString();

    this.allreadyVoted.push(id);
  }
}
