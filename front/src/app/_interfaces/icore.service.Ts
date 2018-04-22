import { Observable } from 'rxjs/Rx';
export interface ICoreService<T> {
    create(obj: T): Observable<any>;
    read(id: any): Observable<T>;
    update(obj: T): Observable<any>;
    delete(id: any): Observable<any>;
    getAll(): Observable<Array<T>>;
    readSingle(): Observable<T>;
    getAllById(id: any): Observable<Array<T>>;
    count(): Observable<number>;
}