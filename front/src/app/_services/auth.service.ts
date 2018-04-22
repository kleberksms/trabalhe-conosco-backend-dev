import { Injectable, EventEmitter } from '@angular/core';

import { Auth } from './../_models/auth';
import { CoreService } from './core.service';
import { UserService } from './user.service';

@Injectable()
export class AuthService extends CoreService<Auth>{

  public userIsAuthenticatedEmitter = new EventEmitter();
  
  constructor(private userService:UserService) {
    super();
  }

  logout(){

  }

}
