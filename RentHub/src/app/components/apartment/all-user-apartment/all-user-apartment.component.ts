import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApartmentService } from 'src/app/service/apartment/apartment.service';
import { UserService } from 'src/app/service/user/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-all-user-apartment',
  templateUrl: './all-user-apartment.component.html',
  styleUrls: ['./all-user-apartment.component.scss']
})
export class AllUserApartmentComponent implements OnInit {

  userId: string = "";
  apartData: any = []

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    this.apartmentService.getDataByUserId(this.userId).subscribe((res: any) => {
      if (res.length) {
        this.apartData = res;
      }
    }),
      (err: any) => {
        console.log(err)
      }
  }

  constructor(private apartmentService: ApartmentService,
    private userService: UserService,
    private router: Router) { }

  viewDetails(id: number) {
    this.router.navigate(['apartment/post-details', id]);
  }

  editDetails(id: number){
    this.router.navigate(['apartment/edit-post', id]);
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
