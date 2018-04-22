import { AuthService } from './_services/auth.service';
import { Component, OnInit, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
  isAuthenticated = false;

  constructor(private authService: AuthService) {
  }
  public ngOnInit() {
    this.authService.userIsAuthenticatedEmitter.subscribe(c => {
      this.isAuthenticated = c;
    },
      (error) => console.log(error));
  }

}
