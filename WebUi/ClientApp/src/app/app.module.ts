import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule, RoutingComponents } from './app-routing.module';

@NgModule({
   declarations: [
      AppComponent,
      RoutingComponents,
   ],
   imports: [
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      AppRoutingModule,
      ReactiveFormsModule,
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
