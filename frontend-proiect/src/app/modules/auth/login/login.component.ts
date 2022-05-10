import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Visitor } from 'src/app/interfaces/visitor';
import { DataTransferService } from 'src/app/services/dataTransfer.service';
import { VisitorsService } from 'src/app/services/visitors.service';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  // public visitor: Visitor = {
  //   email: '',
  //   password: '',
  //   role: ''
  // }

  public message!: string;
  public subscription: Subscription = new Subscription;

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });
  public hideWarning: boolean = true;
  
  constructor(
    private router: Router,
    private data: DataTransferService,
    private visitorsService: VisitorsService,
    private dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.subscription = this.data.currentMessage.subscribe(message => this.message = message);
    localStorage.setItem('Role', 'Unknown');
  }

  public login(): void {
    this.visitorsService.getVisitorByEmail(this.loginForm.value.email).subscribe((result: Visitor) => {
      if(!result) {
        this.router.navigate(['login']);
        this.hideWarning = false;
      }
      else if (this.loginForm.value.password != result.password) {
        this.router.navigate(['login']);
        this.hideWarning = false;
      }
      else {
        if (result.firstName) {
          this.data.changeMessage('Welcome ' + result.firstName + '!');
        }
        else {
          this.data.changeMessage('Welcome ' + result.role + '!');
        }
        this.data.setVisitorEmail(result.email);
        localStorage.setItem('Role', result.role);
        this.router.navigate(['/countries']);
      }
    });

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  get email(): AbstractControl {
    return this.loginForm.get('email')!;
  }
  get password(): AbstractControl {
    return this.loginForm.get('password')!;
  }

  public register(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '600px';
    const dialogRef = this.dialog.open(RegisterComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(() => {
      this.router.navigate(['/countries']);
    });
  }

}
