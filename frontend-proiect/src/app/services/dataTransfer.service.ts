import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {

  private messageSource = new BehaviorSubject('Hello!');
  public currentMessage = this.messageSource.asObservable();

  private visitorEmailSource = new BehaviorSubject('');
  public visitorEmail = this.visitorEmailSource.asObservable();

  constructor() { }

  public changeMessage(message: string) {
    this.messageSource.next(message);
  }

  public setVisitorEmail(email: string) {
    this.visitorEmailSource.next(email);
  }
  
}
