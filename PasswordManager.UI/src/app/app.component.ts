import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Password Manager';

  newPassword: any = {};
  passwords: any[] = [];

  addPassword() {
    if (this.newPassword.website && this.newPassword.username && this.newPassword.password) {
      this.passwords.push({ ...this.newPassword });
      this.newPassword = {};
    }
  }

  deletePassword(password: any) {
    const index = this.passwords.indexOf(password);
    if (index !== -1) {
      this.passwords.splice(index, 1);
    }
  }
}
