import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CountriesService } from 'src/app/services/countries.service';

@Component({
  selector: 'app-add-edit-country',
  templateUrl: './add-edit-country.component.html',
  styleUrls: ['./add-edit-country.component.scss']
})
export class AddEditCountryComponent implements OnInit {

  public title: string;

  public countryForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    //landmarks: new FormControl(null)
});

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<AddEditCountryComponent>,
    private countriesService: CountriesService
  ) { 
      if (this.data.country) {
        this.title = 'Edit Country';
        this.countryForm.patchValue(this.data.country);
      } else {
        this.title = 'Add Country';
      }
  }

  get id(): AbstractControl {
    return this.countryForm.get('id')!;
  }

  get name(): AbstractControl {
    return this.countryForm.get('name')!;
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }

  public saveFormData(): void {
    if(this.title=='Add Country') {
      
      console.log(this.countryForm.value)

      this.countriesService.createCountry(this.countryForm.value).subscribe(() => {
        this.dialogRef.close(this.countryForm.value);
      });
    } else { //this.title=='Edit Country'
        this.countriesService.editCountry(this.countryForm.value).subscribe(() => {
          this.dialogRef.close(this.countryForm.value);
        });
    }
  }

  ngOnInit(): void {
  }

}
