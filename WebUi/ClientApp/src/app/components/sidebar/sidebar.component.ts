import { Component, OnInit } from '@angular/core';
import { SidebarApiService } from '../../services/sidebar-api/sidebar-api.service';
import { Observable } from 'rxjs';
import { Category } from '../../models/category';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  categories$: Observable<Category[]>;

  constructor(private sidebarApiService: SidebarApiService) { }

  ngOnInit() {
    this.sidebarApiService.getCategories().subscribe((data) => {
      console.log(data);
      this.categories$ = this.sidebarApiService.getCategories();
    });
  }
}
