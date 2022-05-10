import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Landmark } from 'src/app/interfaces/landmark';
import { LandmarkInfo } from 'src/app/interfaces/landmark-info';
import { LandmarkVisitor } from 'src/app/interfaces/landmarkVisitor';
import { Location } from 'src/app/interfaces/location';
import { DataTransferService } from 'src/app/services/dataTransfer.service';
import { LandmarksService } from 'src/app/services/landmarks.service';
import { VisitorsService } from 'src/app/services/visitors.service';

@Component({
  selector: 'app-landmark-info',
  templateUrl: './landmark-info.component.html',
  styleUrls: ['./landmark-info.component.scss']
})
export class LandmarkInfoComponent implements OnInit, OnDestroy {

  private sub: any;
  public country: string = '';

  public visitorEmail: string = '';
  public subscription: Subscription = new Subscription;

  public visited = false;

  public loc: Location = {
    id: 0,
    city: '',
    address: '',
    landmarkId: 0
  }
  public info: LandmarkInfo = {
    id: 0,
    name: '',
    description: '',
    countryId: 0,
    location: this.loc
  };

  constructor(
    private route: ActivatedRoute,
    private landmarksService: LandmarksService,
    private visitorsService: VisitorsService,
    private data: DataTransferService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.subscription = this.data.visitorEmail.subscribe((email: string) => {
      this.visitorEmail = email;
      if(this.visitorEmail=='') {
        this.visitorEmail=localStorage.getItem('Email')!;
      }
      else {
        localStorage.setItem('Email', this.visitorEmail);
      }
      this.sub = this.route.params.subscribe(params => {
        this.loc.landmarkId = params['id'];
        this.country = params['country'];
        if (this.loc.landmarkId) {
          this.getLandmarkInfo();
        }
      });
    });
  }

  public getLandmarkInfo(): void {
    this.landmarksService.getLandmarkByIdWithLocation(this.loc.landmarkId).subscribe((result: LandmarkInfo) => {
      this.loc = result.location;
      this.info = result
      this.visitorsService.getVisitedLandmarks(this.visitorEmail).subscribe((result: Landmark[]) => {
        let landmarksID = result.map(a => a.id);
        if (landmarksID.includes(this.loc.landmarkId)) {
          this.visited = true;
        }
      });
    });
  }

  public ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public addVisitor(): void {
    let landmarkVisitor: LandmarkVisitor = {
      landmarkId: this.loc.landmarkId,
      visitorEmail: this.visitorEmail
    }
    this.landmarksService.addVisitorToLandmark(landmarkVisitor).subscribe(() => {});
    this.visited = true;
  }

  public goToCountries(): void {
    this.router.navigate(['/countries']);
  }

}
