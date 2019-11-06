import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionDetailedComponent } from './question-detailed/question-detailed.component';
import { CategoryDetailedComponent } from './category-detailed/category-detailed.component';

const routes: Routes = [
    { path: '', component: QuestionListComponent, pathMatch: 'full' },
    { path: 'category/:id', component: CategoryDetailedComponent, pathMatch: 'full' },
    { path: 'question/:id', component: QuestionDetailedComponent, pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
export const RoutingComponents = [
    NavMenuComponent,
    SidebarComponent,
    QuestionListComponent,
    QuestionDetailedComponent,
    CategoryDetailedComponent,
];
