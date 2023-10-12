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
  getPasswords(masterPassword: string): Observable<Password[]> {
    return this._http.post<Password[]>("http://localhost:8000/api/PasswordEntry/passwords", {masterPassword: masterPassword})
  }

  deletePassword(id: number): void {
    console.log(id)
    this._http.delete("http://localhost:8000/api/PasswordEntry/" + id)
  }
}
