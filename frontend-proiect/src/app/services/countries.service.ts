import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { concat, Observable } from 'rxjs';
import { Country } from '../interfaces/country';
import { LandmarksService } from './landmarks.service';

@Injectable({
  providedIn: 'root'
})
export class CountriesService {

  public url = 'https://localhost:44322/api/Countries';

  constructor(
    private http: HttpClient,
    private landmarksService: LandmarksService
  ) { }

  public getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.url);
  }

  public getCountriesById(id: number): Observable<Country> {
    return this.http.get<Country>(`${this.url}/${id}`);
  }

  // public deleteCountry(country: any): Observable<any> {
  //   const httpOptions = {
  //     headers: new HttpHeaders()
  //       .set('Content-Type', 'application/json'),
  //     body: country
  //   };
  //   return this.http.delete<any>(this.url, httpOptions);
  // }

  public deleteCountry(id: number): Observable<any> {
    return concat(this.landmarksService.deleteAllCountryLandmarks(id),
                  this.http.delete<any>(`${this.url}/${id}`));
  }

  public createCountry(country: Country): Observable<Country> {
    return this.http.post<Country>(this.url, country);
  }

  public editCountry(country: Country): Observable<any> {
    return this.http.put<any>(this.url, country);
  }

}

