import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ICoreService } from './../_interfaces/icore.service';


@Injectable()
export class CoreService<T> implements ICoreService<T> {

  private headers: Headers;

  constructor() { }

  create(obj: T): Observable<any> {
    throw new Error("Method not implemented.");
  }
  read(id: any): Observable<T> {
    throw new Error("Method not implemented.");
  }
  update(obj: T): Observable<any> {
    throw new Error("Method not implemented.");
  }
  delete(id: any): Observable<any> {
    throw new Error("Method not implemented.");
  }
  getAll(): Observable<T[]> {
    throw new Error("Method not implemented.");
  }
  readSingle(): Observable<T> {
    throw new Error("Method not implemented.");
  }
  getAllById(id: any): Observable<T[]> {
    throw new Error("Method not implemented.");
  }
  count(): Observable<number> {
    throw new Error("Method not implemented.");
  }

  protected handleError(error: any) {
    const errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    return Observable.throw(errMsg);
  }

}
