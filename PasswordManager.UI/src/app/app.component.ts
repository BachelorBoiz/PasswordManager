import {Component, OnInit} from '@angular/core';
import {HttpService} from "./http.service";
import {Password} from "./password";
import * as secureRandomPassword from 'secure-random-password';
import {generate} from "rxjs";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {EncryptionService} from "./encryption.service";
import {digits, lower, randomPassword, symbols, upper} from "secure-random-password";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Password Manager';
  masterPassword: string = '';
  repeatedPassword: string = '';
  newPassword: Password = {id: 0, password: "", username: "", website: ""};
  decryptedPasswords: Password[] = [];
  passwordErrorMessage:string ='';
  correctMasterPassword = false;
  showMasterPasswordField = true;

  constructor(private _httpService: HttpService, private _encryptionService: EncryptionService) {
  }

  ngOnInit(): void {
  }

  addPassword(website: string, username: string, password: string, repeatPassword: string) {
    //this.checkNulls(website,username,password,repeatPassword);

    if (!website || !username || !password || !repeatPassword) {
      var errorMessage = "Error: All input fields must be filled.";

      this.passwordErrorMessage =errorMessage;
      console.log(errorMessage);
      return;
    }
    this.passwordErrorMessage ='';
    this.newPassword.website = website
    this.newPassword.username = username
    this.newPassword.password = password
    this.repeatedPassword = repeatPassword;

    this.newPassword.password = this._encryptionService.encrypt(password, this.masterPassword)

    if (password === repeatPassword) {
      this._httpService.addPassword(this.newPassword).subscribe(value => {
        this.decryptedPasswords.push(this.newPassword);
        this.passwordErrorMessage ='';
      });
    } else{
      var errorMessage= "Error: Passwords are not equal.";
      this.passwordErrorMessage = errorMessage;
      console.log(errorMessage);
    }
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
  generateSecurePassword(password: HTMLInputElement, repeatPassword: HTMLInputElement){
    var g = () => randomPassword({
      length: 14,
      characters:[
          upper,
          lower,
          digits,
          symbols
      ]
    });
    const generatedPassword = g();
    password.value = generatedPassword;
    repeatPassword.value = generatedPassword;
  }
  deletePassword(id: number) {
    this._httpService.deletePassword(id)
  }
}

