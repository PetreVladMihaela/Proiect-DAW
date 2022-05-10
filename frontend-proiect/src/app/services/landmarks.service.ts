import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { mergeAll, Observable, mergeMap } from 'rxjs';
import { Landmark } from '../interfaces/landmark';
import { LandmarkInfo } from '../interfaces/landmark-info';
import { LandmarkVisitor } from '../interfaces/landmarkVisitor';

@Injectable({
  providedIn: 'root'
})
export class LandmarksService {

  //public url = 'http://localhost:3000/landmarks';
  public url = 'https://localhost:44322/api/landmarks';

  constructor(
    private http: HttpClient
  ) { }

  public getCountryLandmarks(CountryId: number): Observable<Landmark[]> {
    return this.http.get<Landmark[]>(`${this.url}/byCountryId/${CountryId}`);
  }

  public getCities(CountryId: number): Observable<string[]> {
    return this.http.get<string[]>(`${this.url}/Cities/${CountryId}`);
  }

  public deleteLandmark(id: number): Observable<any> {
    return this.http.delete<any>(`${this.url}/${id}`);
  }

  // public deleteAllCountryLandmarks(CountryId: number): any {
  //   this.getCountryLandmarks(CountryId).subscribe((result) => {
  //     for (let i = 0; i < result.length; i++) {
  //       this.deleteLandmark(result[i].Id).subscribe();
  //     }
  //   });
  // }

  public deleteAllCountryLandmarks(CountryId: number): Observable<any> {
    return this.getCountryLandmarks(CountryId).pipe(mergeAll(), // Flatten the array
      mergeMap(landmark => this.deleteLandmark(landmark.id)));
  }

  public createLandmark(landmark: Landmark): Observable<number> {
    return this.http.post<number>(this.url, landmark);
  }

  public editLandmark(landmark: Landmark): Observable<Landmark> {
    return this.http.put<Landmark>(this.url, landmark);
  }

  public createLocation(loc: Location): Observable<Location> {
    return this.http.post<Location>('https://localhost:44322/api/locations', loc);
  }

  public editLocation(loc: Location): Observable<Location> {
    return this.http.put<Location>('https://localhost:44322/api/locations/editByLandmark', loc);
  }

  public getLandmarkByIdWithLocation(landmarkId: number): Observable<LandmarkInfo> {
    return this.http.get<LandmarkInfo>(`${this.url}/${landmarkId}/withLocation`);
  }

  public addVisitorToLandmark(visitor: LandmarkVisitor): Observable<LandmarkVisitor> {
    return this.http.post<LandmarkVisitor>(this.url+"/addVisitor", visitor);
  }

}