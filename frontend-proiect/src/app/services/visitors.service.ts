import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Visitor } from '../interfaces/visitor';
import { Landmark } from '../interfaces/landmark';


@Injectable({
  providedIn: 'root'
})
export class VisitorsService {

  public url = 'https://localhost:44322/api/visitors';

  constructor(
    private http: HttpClient
  ) { }

  public getVisitors(): Observable<Visitor[]> {
    return this.http.get<Visitor[]>(this.url);
  }

  public getVisitedLandmarks(email: string): Observable<Landmark[]> {
    return this.http.get<Landmark[]>(`${this.url}/${email}/visitedLandmarks`);
  }

  public getVisitorByEmail(email: string): Observable<Visitor> {
    return this.http.get<Visitor>(`${this.url}/${email}`);
  }

  public createVisitor(visitor: Visitor): Observable<Visitor> {
    return this.http.post<Visitor>(this.url, visitor)
  }
}
