import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AuthService } from './../_services/auth.service';


@Component({
  moduleId: module.id,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit() {
    this.authService.userIsAuthenticatedEmitter.subscribe(s => {
      if (s) {
        if (this.returnUrl === undefined) {
          this.router.navigate(['/']);
          return;
        }
        this.router.navigate([this.returnUrl]);
        return;
      }
    });
    this.authService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login() {
    this.authService.userIsAuthenticatedEmitter.emit(true);
  }

  logout() {
    this.authService.logout();
  }

}
