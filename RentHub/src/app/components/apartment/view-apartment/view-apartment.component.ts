import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ApartmentService } from 'src/app/service/apartment/apartment.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-apartment',
  templateUrl: './view-apartment.component.html',
  styleUrls: ['./view-apartment.component.scss']
})
export class ViewApartmentComponent {

  apartment: any = []
  id: number = 0

  ngOnInit(): void {
    this.id = parseInt(this.router.snapshot.paramMap.get("id") || "");
    this.apartmentService.getDataById(this.id).subscribe((res: any) => {
      console.log(res)
      if (res) {
        this.apartment = res.apartmentModel;
      }
    }),
      (err: any) => {
        console.log(err)
      }
  }

  constructor(private apartmentService: ApartmentService,
    private routerService: Router,
    private router: ActivatedRoute
  ) { }

  ImagePath(path: string) {
    if (path != null) {
      return `${environment.imgUrl}${path}`;
    }
    else {
      return "No Receipt";
    }
  }

  LoadImg(url: string){
    window.open(url, "_blank")
  }

  back(){
    this.routerService.navigate(['/user/your-posts']);
  }
}
