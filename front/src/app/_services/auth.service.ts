import { Injectable, EventEmitter } from '@angular/core';

import { Auth } from './../_models/auth';
import { CoreService } from './core.service';
import { UserService } from './user.service';

@Injectable()
export class AuthService extends CoreService<Auth>{

  public userIsAuthenticatedEmitter = new EventEmitter();
  public 

  constructor(private userService: UserService) {
    super();
  }

  login() {
    this.userIsAuthenticatedEmitter.emit(true);
  }

  logout() {
    this.userIsAuthenticatedEmitter.emit(false);
  }

}
