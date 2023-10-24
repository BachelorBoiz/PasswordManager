import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable, of, take, tap} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {TokenDto} from "./token.dto";
import {LoginDto} from "./login.dto";

const jwtToken = 'jwtToken';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  isLoggedIn$ = new BehaviorSubject<string | null>(this.getToken());
  constructor(private _http: HttpClient) { }

  getToken(): string | null {
    return localStorage.getItem(jwtToken);
  }

  login(loginDto: LoginDto): Observable<TokenDto>{
    return this._http.post<TokenDto>('http://localhost:8000/api/User/Login', loginDto)
      .pipe(
        tap(token => {
          if(token && token.jwt) {
            localStorage.setItem(jwtToken, token.jwt);
            this.isLoggedIn$.next(token.jwt);
          } else {
            this.logout();
          }
        })
      )
  }

  createUser(loginDto: LoginDto): Observable<TokenDto>{
    return this._http.post<TokenDto>('http://localhost:8000/api/User/create/user', loginDto)
      .pipe(
        tap(token => {
          if(token && token.jwt) {
            localStorage.setItem(jwtToken, token.jwt);
            this.isLoggedIn$.next(token.jwt);
          } else {
            this.logout();
          }
        })
      )
  }

  logout():Observable<boolean> {
    localStorage.removeItem(jwtToken)
    this.isLoggedIn$.next(null);
    return of(true).pipe(take(1));
  }
}
