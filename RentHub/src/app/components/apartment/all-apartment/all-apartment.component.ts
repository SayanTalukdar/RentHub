import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApartmentService } from 'src/app/service/apartment/apartment.service';
import { FavouriteService } from 'src/app/service/user/favourite.service';
import { UserService } from 'src/app/service/user/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-all-apartment',
  templateUrl: './all-apartment.component.html',
  styleUrls: ['./all-apartment.component.scss']
})
export class AllApartmentComponent implements OnInit {

  apartData: any = []
  isAuthenticated = false;
  favouritedApart: number[] = [];

  ngOnInit(): void {
    this.apartmentService.getAll().subscribe((res: any) => {
      if (res.length) {
        this.apartData = res;
      }
    }, (err: any) => {
      console.log(err)
    })
    this.isAuthenticated = this.userService.isAuthenticated();
    if (this.isAuthenticated) {
      this.getAllFavourites()
    }
  }

  constructor(private apartmentService: ApartmentService,
    private router: Router,
    private userService: UserService,
    private favouriteService: FavouriteService
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

  getAllFavourites() {
    this.favouriteService.getAllFavourites().subscribe((res: any) => {
      this.favouritedApart = [];
      if (res.length > 0) {
        res.forEach((element: any) => {
          this.favouritedApart.push(element["apartmentId"])
        });
      }
    }, (err: any) => {
      console.log(err)
    })
  }

  markAsFavorite(id: number) {
    if (this.isAuthenticated) {
      this.favouriteService.markFavourite(id).subscribe((res: any) => {
        console.log(res)
        if (res.message == "Success") {
          this.getAllFavourites();
        }
      }, (err: any) => {
        console.log(err)
      })
    } else {
      this.router.navigate(['user/login']);
    }
  }

  removeAsFavorite(id: number) {
    this.favouriteService.removeFavaourite(id).subscribe((res: any) => {
      this.getAllFavourites();
    }, (err: any) => {
      console.log(err)
    })
  }

  onSortChange(evt: any) {
    var sortBy = evt.target.value
    switch (sortBy) {
      case 'nameAsc':
        this.apartData.sort((a: any, b: any) => a.apartName.localeCompare(b.apartName));
        break;
      case 'nameAsc':
        this.apartData.sort((a: any, b: any) => b.apartName.localeCompare(a.apartName))
        break;
      case 'rentAsc':
        this.apartData.sort((a: any, b: any) => a.expectedRent - b.expectedRent);
        break;
      case 'rentAsc':
        this.apartData.sort((a: any, b: any) => a.expectedRent - b.expectedRent);
        break;
      case 'rentDesc':
        this.apartData.sort((a: any, b: any) => b.expectedRent - a.expectedRent);
        break;
      case 'locationAsc':
        this.apartData.sort((a: any, b: any) => a.apartLocation.localeCompare(b.apartLocation));
        break;
      case 'locationDesc':
        this.apartData.sort((a: any, b: any) => b.apartLocation.localeCompare(a.apartLocation));
        break;
      case 'none':
        break;
    }
  }
}
