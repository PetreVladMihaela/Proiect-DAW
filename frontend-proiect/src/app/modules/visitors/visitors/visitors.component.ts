import { Component, OnInit } from '@angular/core';
import { Landmark } from 'src/app/interfaces/landmark';
import { Visitor } from 'src/app/interfaces/visitor';
import { VisitorsWithLandmarks } from 'src/app/interfaces/visitorsWithLandmarks';
import { VisitorsService } from 'src/app/services/visitors.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-visitors',
  templateUrl: './visitors.component.html',
  styleUrls: ['./visitors.component.scss']
})
export class VisitorsComponent implements OnInit {

  public visitors: Visitor[] = [];
  
  public visitorsList: VisitorsWithLandmarks[] = []

  constructor(
    private visitorsService: VisitorsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getVisitors();
  }

  public getVisitors(): void {
    this.visitorsService.getVisitors().subscribe((result: Visitor[]) => {
      this.visitors = result;
      this.getVisitedLandmarks();
    });
  }

  public getVisitedLandmarks(): void {
    for (let v of this.visitors) {
      this.visitorsService.getVisitedLandmarks(v.email).subscribe((result: Landmark[]) => {
        let vl: VisitorsWithLandmarks = {
          visitor: v,
          landmarks: result
        }
        this.visitorsList.push(vl)
      });
    }
  }

  public goToCountries(): void {
    this.router.navigate(['/countries']);
  }

}
