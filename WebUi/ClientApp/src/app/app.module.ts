import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SidebarComponent } from './faq-components/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { QuestionComponent } from './question/question.component';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      FetchDataComponent,
      SidebarComponent,
      QuestionComponent
   ],
   imports: [
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      RouterModule.forRoot([
         { path: '', component: HomeComponent, pathMatch: 'full' },
         { path: 'fetch-data', component: FetchDataComponent },
         { path: 'question', component: QuestionComponent },
       ]),
   ],
   providers: [],
   bootstrap: [AppComponent]
 })
export class AppModule { }
