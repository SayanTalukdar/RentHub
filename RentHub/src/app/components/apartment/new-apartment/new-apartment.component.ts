import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ApartmentService } from './../../../service/apartment/apartment.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-new-apartment',
  templateUrl: './new-apartment.component.html',
  styleUrls: ['./new-apartment.component.scss']
})
export class NewApartmentComponent {

  displayMsg: string ="";
  isCreated: boolean= false;
  apartmentForm: FormGroup;
  imgPath : { dbPath: ""; } | undefined;

  amenitiesOptions: string[] = ['WiFi', 'Parking', 'Pool', 'Gym', 'Pet-Friendly'];
  stayTypeOptions = [
    { label: "Long Term (>6 months)", value: "Long Term" },
    { label: "Short Term (<6 months)", value: "Short Term" }
  ];

  constructor(private apartmentService: ApartmentService,
    private userService: UserService,
    private router: Router, 
    private fb: FormBuilder) {
    this.apartmentForm = this.fb.group({
      apartName: ['', Validators.required],
      isShared: [false],
      apartLocation: ['', Validators.required],
      apartDetails: [''],
      stayType: [''],
      expectedRent: ['', Validators.required],
      isNegotiable: [false],
      isFurnished: [false],
      descpTitle: ['', Validators.required],
      descp: [''],
      createdBy: ['', Validators.required],
      contact: ['', Validators.required],
      amenities: [[]],
    });
  }

  onAmenityChange(event: Event) {
    const target = event.target as HTMLInputElement;
    const selectedAmenities = this.apartmentForm.get('amenities')?.value || [];

    if (target.checked) {
      selectedAmenities.push(target.value);
    } else {
      const index = selectedAmenities.indexOf(target.value);
      if (index >= 0) selectedAmenities.splice(index, 1);
    }

    this.apartmentForm.get('amenities')?.setValue(selectedAmenities);
  }

  uploadFinished = (event: any) => { 
    this.imgPath = event; 
  }

  onSubmit() {
    this.apartmentService.createData(this.apartmentForm.value, this.imgPath).subscribe( 
      (res: any) => {
        if (res.message == "Added Successfully"){
          this.router.navigate(["user/your-posts", this.userService.getUserId()])
        }
      },
      (err: any) =>{
        console.log(err)
      }
    )
  }

  back(){
    this.router.navigate(['/user/your-posts']);
  }
}
