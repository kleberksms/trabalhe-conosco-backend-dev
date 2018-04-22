import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterializeModule } from "angular2-materialize";

import { AuthService } from './_services/auth.service';
import { CoreService } from './_services/core.service';
import { UserService } from './_services/user.service';

import { AppComponent } from './app.component';
import { DefaultComponent } from './default/default.component';
import { LoginComponent } from './login/login.component';
import { UsersComponent } from './users/users.component';

import { AuthGuard } from './_guards/auth.guard';
import { routing } from './app.routing';


@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    LoginComponent,
    DefaultComponent
  ],
  imports: [
    BrowserModule,
    MaterializeModule,
    routing
  ],
  providers: [
    AuthGuard,
    AuthService,
    CoreService,
    UserService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
