import { Usuario } from './../_models/Usuario';
import { Injectable } from '@angular/core';

import { CoreService } from './core.service';

/**
 * Neste caso passei any porque tenho dois objetos que podem ser usados aqui,
 * Objeto para Usuario
 * Objeto para Lista de usuário
 * 
 * Isso por causa do Hal
 * 
 * Então, o certo seria ajustar para o Hal
 */
@Injectable()
export class UserService extends CoreService<any> {

  constructor() {
    super();
  }

}
