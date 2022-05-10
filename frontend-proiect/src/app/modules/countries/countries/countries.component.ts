import { Component, OnDestroy, OnInit } from '@angular/core';
import { CountriesService } from '../../../services/countries.service';
import { Country } from '../../../interfaces/country';
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AddEditCountryComponent } from '../../forms/add-edit-country/add-edit-country.component';
import { DataTransferService } from 'src/app/services/dataTransfer.service';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})
export class CountriesComponent implements OnInit, OnDestroy {

  todayDate : Date = new Date();
  public countries: Country[] = [];
  public displayedColumns: string[] = ['id', 'name', 'landmarks', 'edit','delete'];
  public message!: string;
  public subscription: Subscription = new Subscription;

  public visitorEmail: string = '';

  public isAdmin = false;

  constructor(
    private countriesService: CountriesService,
    private router: Router,
    private dialog: MatDialog,
    private data: DataTransferService,
  ) { }

  ngOnInit(): void {
    this.subscription = this.data.currentMessage.subscribe(message => this.message = message);
    const role = localStorage.getItem('Role');
    if (role=="Admin") { 
      this.isAdmin = true;
    }
    else {
      this.displayedColumns = ['id', 'name', 'landmarks'];
    }
    this.getCountries();

    this.subscription = this.data.visitorEmail.subscribe((email: string) => {
      this.visitorEmail = email;
      if(this.visitorEmail=='') {
        this.visitorEmail=localStorage.getItem('Email')!;
      }
      else {
        localStorage.setItem('Email', this.visitorEmail);
      }
  });

}

  public getCountries(): void {
    this.countriesService.getCountries().subscribe((result: Country[]) => {
      this.countries = result;
      //console.log(this.countries)
    });
  }

  public goToLandmarks(id: number, name:string): void {
    //this.router.navigate(['/countries/landmarks', id, name]);
    this.router.navigate(['/countries',id]);
  }

  public deleteCountry(id: number): void {
    if (window.confirm("Do you really want to delete this country?")) {
      this.countriesService.deleteCountry(id).subscribe((result: any) => {
        //console.log(result)
        //this.countries = result;
        this.getCountries();
      });
    }
  }

  public addCountry(country?: Country): void {
    const data = {
      country
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '350px';
    dialogConfig.height = '350px';
    dialogConfig.data = data;
    //console.log('data',dialogConfig.data)
    const dialogRef = this.dialog.open(AddEditCountryComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      //console.log(result)
      if (result) {
        this.getCountries();
      }
    });
  }

  public editCountry(country: Country): void {
    this.addCountry(country);
  }

  public logout(): void {
    localStorage.setItem('Role', 'Unknown');
    this.router.navigate(['/login']);
    this.data.changeMessage('Hello! Please login:');
  }

  public seeVisitors(): void {
    this.router.navigate(['/visitors']);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
