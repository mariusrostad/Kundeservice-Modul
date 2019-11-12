import { Component, OnInit } from '@angular/core';
import { QuestionService } from '../services/question.service';
import { Observable } from 'rxjs';
import { Question } from '../models/question';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-question-detailed',
  templateUrl: './question-detailed.component.html',
  styleUrls: ['./question-detailed.component.css']
})
export class QuestionDetailedComponent implements OnInit {
  question$: Observable<Question>;
  id: string;
  questionId: number;

  constructor(
    private questionService: QuestionService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.route.queryParams.subscribe(queryParams => {
      const selectedId = +this.route.paramMap.pipe(switchMap(params => {
        return params.get('id');
      }));
      this.questionService.getQuestion(selectedId).subscribe((data) => {
        this.question$ = this.questionService.getQuestion(selectedId);
      });
    });
    this.route.params.subscribe(routeParams => {
      const selectedId = +this.route.paramMap.pipe(switchMap(params => {
        return params.get('id');
      }));
      this.questionService.getQuestion(selectedId).subscribe((data) => {
        this.question$ = this.questionService.getQuestion(selectedId);
      });
    });
    // this.question$ = this.route.paramMap.pipe(
    //   switchMap(params => {
    //     // (+) before `params.get()` turns the string into a number
    //     const selectedId = +params.get('id');
    //     return this.questionService.getQuestion(selectedId);
    //   })
    // );
  }
}
