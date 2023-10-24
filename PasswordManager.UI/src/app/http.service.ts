import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Password} from "./password";

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }

  addPassword(password: Password): Observable<Password> {
    return this._http.post<Password>("http://localhost:8000/api/PasswordEntry", password)
  }
  getPasswords(): Observable<Password[]> {
    return this._http.get<Password[]>("http://localhost:8000/api/PasswordEntry")
  }

  deletePassword(id: number): Observable<void> {
    return this._http.delete<void>("http://localhost:8000/api/PasswordEntry/" + id)
  }
}
