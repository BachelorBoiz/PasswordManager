import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';
@Injectable({
  providedIn: 'root'
})
export class EncryptionService {

  constructor() { }

  encrypt(data: string, key: string): string {
    return CryptoJS.AES.encrypt(data, key).toString();
  }

  decrypt(data: string, key: string): string {
    return CryptoJS.AES.decrypt(data, key).toString(CryptoJS.enc.Utf8);
  }
}
