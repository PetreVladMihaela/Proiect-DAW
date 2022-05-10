import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { DataTransferService } from 'src/app/services/dataTransfer.service';
import { VisitorsService } from 'src/app/services/visitors.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    role: new FormControl('User')
  });

  constructor(
    public dialogRef: MatDialogRef<RegisterComponent>,
    private visitorsService: VisitorsService,
    private data: DataTransferService,
  ) { }

  get firstName(): AbstractControl {
    return this.registerForm.get('firstName')!;
  }

  get lastName(): AbstractControl {
    return this.registerForm.get('lastName')!;
  }

  get email(): AbstractControl {
    return this.registerForm.get('email')!;
  }

  get password(): AbstractControl {
    return this.registerForm.get('password')!;
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }

  public saveAndRegister(): void {
    this.visitorsService.createVisitor(this.registerForm.value).subscribe(() => {
      this.dialogRef.close(this.registerForm.value);
      if (this.registerForm.value.firstName) {
        this.data.changeMessage('Welcome ' + this.registerForm.value.firstName + '!');
      }
      else {
        this.data.changeMessage('Welcome ' + this.registerForm.value.role + '!');
      }
      this.data.setVisitorEmail(this.registerForm.value.email);
      localStorage.setItem('Role', this.registerForm.value.role);
    });
  }

  ngOnInit(): void {
  }

}
