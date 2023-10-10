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
  newPassword: Password = {id: 0, password: "", username: "", website: ""};
  encryptedPasswords: Password[] = [];
  decryptedPasswords: Password[] = [];

  constructor(private _httpService: HttpService) {
  }

  ngOnInit(): void {
  }

  addPassword(website: string, username: string, password: string) {
    this.newPassword.website = website
    this.newPassword.username = username
    this.newPassword.password = password
    this._httpService.addPassword(this.newPassword).subscribe(value => {
      this.decryptedPasswords.push(this.newPassword);
    })
  }

  getPasswords(masterPassword: string) {
    this._httpService.getPasswords().subscribe(value => {
      this.encryptedPasswords = value
    })
  }

  deletePassword(id: number) {
    this._httpService.deletePassword(id)
    
  }
}
