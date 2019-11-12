import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuestionDetailedComponent } from './question-detailed/question-detailed.component';
import { CategoryDetailedComponent } from './category-detailed/category-detailed.component';
import { QuestionNewComponent } from './question-new/question-new.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'category/:id', component: CategoryDetailedComponent, pathMatch: 'full' },
    { path: 'question/new', component: QuestionNewComponent, pathMatch: 'full' },
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
    QuestionNewComponent,
    HomeComponent,
];
