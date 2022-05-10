import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Landmark } from 'src/app/interfaces/landmark';
import { CountriesService } from 'src/app/services/countries.service';
import { LandmarksService } from 'src/app/services/landmarks.service';
import { AddEditLandmarkComponent } from '../../forms/add-edit-landmark/add-edit-landmark.component';

@Component({
  selector: 'app-landmarks',
  templateUrl: './landmarks.component.html',
  styleUrls: ['./landmarks.component.scss']
})
export class LandmarksComponent implements OnInit, OnDestroy {

  public countryId!: number;
  public countryName: string | undefined;
  public landmarks: Landmark[] = [];
  public displayedColumns: string[] = ['id', 'name', 'city', 'info','edit', 'delete'];
  private sub: any;

  public isAdmin = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private landmarksService: LandmarksService,
    private countriesService: CountriesService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.countryId = +params['id'];
      //console.log(this.route);
      if (this.countryId) {
        this.getCountryLandmarks(this.countryId);
        this.countriesService.getCountriesById(this.countryId).subscribe(result => {
          this.countryName = result.name;
        })
      }
    });
    const role = localStorage.getItem('Role');
    if (role=="Admin") { 
      this.isAdmin = true;
    }
    else {
      this.displayedColumns = ['id', 'name', 'city', 'info'];
    }
  }

  public getCountryLandmarks(CountryId: number): void {
    this.landmarksService.getCountryLandmarks(CountryId).subscribe((result1) => {
      this.landmarks = result1;
      this.landmarksService.getCities(CountryId).subscribe((result2) => {
        for (let i = 0; i < result2.length; i++) {
          //Object.assign(this.landmarks[i], {'city': result2[i]})
          this.landmarks[i].city = result2[i];
        }
      });
    });
  }

  public deleteLandmark(id: number): void {
    // this.landmarksService.deleteLandmark(id).subscribe((result: any) => {
    //   console.log(result)
    //   //this.landmarks = result;
    // });
    this.landmarksService.deleteLandmark(id).subscribe(() => {
      if (this.countryId) {
        this.getCountryLandmarks(this.countryId);
      }
    });
  }

  public addLandmark(countryId :number, landmark?: Landmark): void {
    const data = {
      landmark
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '400px';
    dialogConfig.height = '550px';
    if (countryId > 0) {
      dialogConfig.data = countryId;
    } else {
      dialogConfig.data = data;
    }
    //delete data.landmark!.city;
    //console.log('data', dialogConfig.data)
    const dialogRef = this.dialog.open(AddEditLandmarkComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      //console.log(result)
      if (result) {
        this.getCountryLandmarks(this.countryId!);
      }
    });
  }

  public editLandmark(landmark: Landmark): void {
    this.addLandmark(0, landmark);
  }

  public goToLandmarkInfo(id: number): void {
    this.router.navigate(['/info', this.countryName, id,]);
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
