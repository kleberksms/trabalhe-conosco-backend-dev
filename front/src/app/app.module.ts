import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterializeModule } from "angular2-materialize";

import { AppComponent } from './app.component';

import { UserService } from './_services/user.service';
import { CoreService } from './_services/core.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    MaterializeModule
  ],
  providers: [
    CoreService,
    UserService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
