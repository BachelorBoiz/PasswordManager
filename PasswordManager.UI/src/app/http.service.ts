import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Password} from "./password";

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }

  getPasswords(): Observable<Password[]> {
    return this._http.get<Password[]>("http://localhost:8000/api/PasswordEntry")
  }
}
