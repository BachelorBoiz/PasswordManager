import {Component, OnInit} from '@angular/core';
import {HttpService} from "./http.service";
import {Password} from "./password";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {EncryptionService} from "./encryption.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Password Manager';
  masterPassword: string = "";
  newPassword: Password = {id: 0, password: "", username: "", website: ""};
  encryptedPasswords: Password[] = [];
  decryptedPasswords: Password[] = [];
  correctMasterPassword = false;
  showMasterPasswordField = true;

  constructor(private _httpService: HttpService, private _encryptionService: EncryptionService) {
  }

  ngOnInit(): void {
  }

  addPassword(website: string, username: string, password: string) {
    this.newPassword.website = website
    this.newPassword.username = username
    this.newPassword.password = this._encryptionService.encrypt(password, this.masterPassword)
    this._httpService.addPassword(this.newPassword).subscribe(value => {
      this.decryptedPasswords.push(this.newPassword);
    })
  }

  getPasswords(masterPassword: string) {
    if (masterPassword !== "") {
      this.showMasterPasswordField = false;
      this.correctMasterPassword = true;
      this.decryptedPasswords = [];
      this._httpService.getPasswords(masterPassword).subscribe(value => {
        value.forEach(p => {
          p.password = this._encryptionService.decrypt(p.password, masterPassword)
          this.decryptedPasswords.push(p)
        })
        this.masterPassword = masterPassword;
      })
    }
  }

  deletePassword(id: number) {
    this._httpService.deletePassword(id)
  }
}
