import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { Observable, Subject } from 'rxjs';
import { Category } from '../models/category';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  categories: Category[];

  constructor(private categoryService: CategoryService) { }

  ngOnInit() {
    this.categoryService.getCategories().subscribe(users => this.categories = users);
    // this.categoryService.getCategories().subscribe((data) => {
    //   this.categories = this.categoryService.getCategories().subscribe(response => this.categories = response);
    // });
  }

}
