import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LandmarksService } from 'src/app/services/landmarks.service';

@Component({
  selector: 'app-add-edit-landmark',
  templateUrl: './add-edit-landmark.component.html',
  styleUrls: ['./add-edit-landmark.component.scss']
})
export class AddEditLandmarkComponent implements OnInit {

  public title: string;
  public IDcountry: number = 0;

  public landmarkForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    description: new FormControl(''),
    //City: new FormControl(''),
    countryId: new FormControl(0)
  });

  public locationForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    city: new FormControl(''),
    address: new FormControl(''),
    //City: new FormControl(''),
    landmarkId: new FormControl(0)
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<AddEditLandmarkComponent>,
    private landmarksService: LandmarksService,
  ) { 
    //console.log('constr',this.data);
      if (Number.isInteger(this.data)) {
        this.title = 'Add Landmark';
        this.IDcountry = this.data;
      } else {
        this.title = 'Edit Landmark';
        this.landmarkForm.patchValue(this.data.landmark);
        this.locationForm.patchValue(this.data.landmark);
        //console.log(this.data)
      }
  }

  // get id(): AbstractControl {
  //   return this.landmarkForm.get('id')!;
  // }

  get name(): AbstractControl {
    return this.landmarkForm.get('name')!;
  }

  get description(): AbstractControl {
    return this.landmarkForm.get('description')!;
  }

  // get countryId(): AbstractControl {
  //   return this.landmarkForm.get('countryId')!;
  // }

  get city(): AbstractControl {
    return this.locationForm.get('city')!;
  }

  get address(): AbstractControl {
    return this.locationForm.get('address')!;
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }

  public saveFormData(): void {
    //console.log(this.locationForm.value);
    if(this.title=='Add Landmark') {
      this.landmarkForm.value.countryId = this.IDcountry;
      this.landmarksService.createLandmark(this.landmarkForm.value).subscribe((result) => {
          //console.log(result)
          this.locationForm.value.landmarkId = result;
          this.landmarksService.createLocation(this.locationForm.value).subscribe(() => {
            this.dialogRef.close(this.landmarkForm.value);
          });
      });
    } else { //this.title=='Edit Landmark'
        this.locationForm.value.landmarkId =  this.landmarkForm.value.id;
        this.landmarksService.editLandmark(this.landmarkForm.value).subscribe(() => {
          this.landmarksService.editLocation(this.locationForm.value).subscribe(() => {
            this.dialogRef.close(this.landmarkForm.value);
        });
      });
    }
  }

  ngOnInit(): void {
  }

}
