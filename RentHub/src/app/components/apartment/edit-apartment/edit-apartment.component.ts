import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApartmentService } from 'src/app/service/apartment/apartment.service';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-edit-apartment',
  templateUrl: './edit-apartment.component.html',
  styleUrls: ['./edit-apartment.component.scss']
})
export class EditApartmentComponent implements OnInit {

  isUpdated: boolean = false;
  displayMsg: string = "";
  apartData: any = {};
  id: number = 0;
  editForm: FormGroup;

  amenitiesOptions: string[] = ['WiFi', 'Parking', 'Pool', 'Gym', 'Pet-Friendly'];
  stayTypeOptions = [
    { label: "Long Term (>6 months)", value: "Long Term" },
    { label: "Short Term (<6 months)", value: "Short Term" }
  ];

  constructor(private apartmentService: ApartmentService,
    private userService: UserService,
    private router: ActivatedRoute,
    private routerService: Router,
    private fb: FormBuilder) {
    this.editForm = this.fb.group({
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

  ngOnInit(): void {
    this.id = parseInt(this.router.snapshot.paramMap.get("id") || "");

    this.apartmentService.getDataById(this.id).subscribe((res: any) => {
      if (res) {
        this.apartData = res?.['apartmentModel'];
        this.onloadData();
      }
      else {
        this.routerService.navigate(["not-found"])
      }
    })
  }

  onloadData(): void {
    this.editForm.patchValue({
      apartName: this.apartData.apartName,
      isShared: this.apartData.isShared,
      apartLocation: this.apartData.apartLocation,
      apartDetails: this.apartData.apartDetails,
      stayType: this.apartData.stayType,
      expectedRent: this.apartData.expectedRent,
      isNegotiable: this.apartData.isNegotiable,
      isFurnished: this.apartData.isFurnished,
      descpTitle: this.apartData.descpTitle,
      descp: this.apartData.descp,
      createdBy: this.apartData.createdBy,
      contact: this.apartData.contact,
      amenities: this.apartData.amenities,
    })
  }

  onAmenityChange(event: Event) {
    const target = event.target as HTMLInputElement;
    const selectedAmenities = this.editForm.get('amenities')?.value || [];

    if (target.checked) {
      selectedAmenities.push(target.value);
    } else {
      const index = selectedAmenities.indexOf(target.value);
      if (index >= 0) selectedAmenities.splice(index, 1);
    }

    this.editForm.get('amenities')?.setValue(selectedAmenities);
  }

  onSubmit() {
    this.apartData = {
      Id : this.id,
      UserId : this.apartData.userId,
      Email: this.userService.getEmail(),
      ApartName: this.editForm.value.apartName,
      IsShared: this.editForm.value.isShared,
      ApartLocation: this.editForm.value.apartLocation,
      ApartDetails: this.editForm.value.apartDetails,
      StayType: this.editForm.value.stayType,
      ExpectedRent: this.editForm.value.expectedRent,
      IsNegotiable: this.editForm.value.isNegotiable,
      IsFurnished: this.editForm.value.isFurnished,
      DescpTitle: this.editForm.value.descpTitle,
      Descp: this.editForm.value.descp,
      CreatedBy: this.editForm.value.createdBy,
      Contact: this.editForm.value.contact,
      Amenities: this.editForm.value.amenities,
      CreatedAt: this.apartData.createdAt,
      ApartmentImagePath: this.apartData.apartmentImagePath
    }
    this.apartmentService.updateDataById(this.id, this.apartData).subscribe((res: any) => {
      
      if (res?.["message"] == "Updated Successfully") {
        this.isUpdated = true;
        this.displayMsg = "Data Updated Successfully";
        setTimeout(() => {
          this.routerService.navigate(['/apartment/post-details', this.id]);
        }, 1000)
      }
      else {
        this.displayMsg = res?.["message"]
      }
    })
  }
}
