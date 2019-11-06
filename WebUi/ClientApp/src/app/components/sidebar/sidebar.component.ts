import { Component, OnInit } from '@angular/core';
import { SidebarApiService } from '../../sidebar-api/sidebar-api.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  categories: any;

  constructor(private sidebarApiService: SidebarApiService) { }

  ngOnInit() {
    this.sidebarApiService.getSidebarActions().subscribe((data) => {
      console.log(data);
      this.categories = data['articles'];
    });
  }

}
