import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class HomeComponent implements OnInit {
  categories$: Observable<Category[]>;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getFaq().subscribe((data) => {
      this.categories$ = this.apiService.getFaq();
    });
  }
}
