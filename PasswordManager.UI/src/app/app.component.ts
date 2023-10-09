import {Component, OnInit} from '@angular/core';
import {HttpService} from "./http.service";
import {Password} from "./password";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Password Manager';
  masterPassword: string = '';
  newPassword: any = {};
  encryptedPasswords: Password[] = [];
  decryptedPasswords: Password[] = [];

  constructor(private _httpService: HttpService) {
  }

  ngOnInit(): void {
  }

  addPassword() {
    if (this.newPassword.website && this.newPassword.username && this.newPassword.password) {
      this.decryptedPasswords.push({ ...this.newPassword });
      this.newPassword = {};
    }
  }

  getPasswords(masterPassword: string) {
    this._httpService.getPasswords().subscribe(value => {
      this.decryptedPasswords = value
    })
  }

  deletePassword(password: any) {
    const index = this.decryptedPasswords.indexOf(password);
    if (index !== -1) {
      this.decryptedPasswords.splice(index, 1);
    }
  }
}
