import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApartmentService } from 'src/app/service/apartment/apartment.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-all-apartment',
  templateUrl: './all-apartment.component.html',
  styleUrls: ['./all-apartment.component.scss']
})
export class AllApartmentComponent implements OnInit {

  apartData: any = []

  ngOnInit(): void {
    this.apartmentService.getAll().subscribe((res: any) => {
      if (res.length) {
        this.apartData = res;
      }
    }, (err: any) => {
      console.log(err)
    })
  }

  constructor(private apartmentService: ApartmentService,
    private router: Router,
  ) { }

  viewDetails(id: number) {
    this.router.navigate(['apartment/post-details', id]);
  }

  ImagePath(path: string) {
    if (path != null) {
      return `${environment.imgUrl}${path}`;
    }
    else {
      return "No Receipt";
    }
  }
}
