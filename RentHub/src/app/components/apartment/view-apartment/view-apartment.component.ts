import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ApartmentService } from 'src/app/service/apartment/apartment.service';
import { environment } from 'src/environments/environment';
import { CommentsService } from './../../../service/apartment/comments.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-view-apartment',
  templateUrl: './view-apartment.component.html',
  styleUrls: ['./view-apartment.component.scss']
})
export class ViewApartmentComponent implements OnInit {

  apartment: any = []
  id: number = 0
  commentForm: FormGroup;
  comments: any = [];
  isAuthenticated: boolean = false;

  ngOnInit(): void {
    this.id = parseInt(this.router.snapshot.paramMap.get("id") || "");
    this.apartmentService.getDataById(this.id).subscribe((res: any) => {
      if (res) {
        this.apartment = res.apartmentModel;
      }
    },
      (err: any) => {
        console.log(err)
      })
    this.isAuthenticated = this.userService.isAuthenticated();
    this.loadAllComment();
  }

  constructor(private apartmentService: ApartmentService,
    private routerService: Router,
    private router: ActivatedRoute,
    private fb: FormBuilder,
    private commentsService: CommentsService,
    private userService: UserService
  ) {
    this.commentForm = this.fb.group({
      comment: ['', Validators.required]
    });
  }

  loadAllComment() {
    this.commentsService.getAllComment(this.id).subscribe((res) => {
      this.comments = res
    }, (err: any) => {
      console.log(err)
    })
  }

  ImagePath(path: string) {
    if (path != null) {
      return `${environment.imgUrl}${path}`;
    }
    else {
      return "No Images";
    }
  }

  LoadImg(url: string) {
    window.open(url, "_blank")
  }

  back() {
    if (this.isAuthenticated){
      this.routerService.navigate(['/user/your-posts']);
    } else {
      this.routerService.navigate(['/']);
    }
  }

  onSubmit() {
    if (this.commentForm.valid) {
      this.commentsService.postComment(this.commentForm.value.comment, this.id).subscribe((res: any) => {
        this.commentForm.reset();
        this.loadAllComment();
      },
        (err: any) => {
          console.log(err)
        });
    }
  }
}
