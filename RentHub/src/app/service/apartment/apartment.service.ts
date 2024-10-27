import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { UserService } from 'src/app/service/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {

  constructor(private http: HttpClient, private userService: UserService) { }

  baseUrl = environment.serverUrl;

  getAll(){
    return this.http.get(`${this.baseUrl}ApartmentModel/alldata`)
  }

  getDataByUserId(userId: string){
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;
    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.get(`${this.baseUrl}ApartmentModel/user/${userId}`, options)
  }

  createData(apartData: any, imgPath: any) {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;
    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }

    const data = {
      email: this.userService.getEmail(),
      apartName: apartData.apartName,
      isShared: apartData.isShared,
      apartLocation: apartData.apartLocation,
      apartDetails: apartData.apartDetails,
      stayType: apartData.stayType,
      expectedRent: apartData.expectedRent,
      isNegotiable: apartData.isNegotiable,
      isFurnished: apartData.isFurnished,
      descpTitle: apartData.descpTitle,
      descp: apartData.descp,
      createdBy: apartData.createdBy,
      contact: apartData.contact,
      amenities: apartData.amenities,
      createdAt: new Date || 'short',
      apartmentImagePath: imgPath.dbPath || null
    }
    return this.http.post(`${this.baseUrl}ApartmentModel/create`, data, options)
  }

  uploadImage(formData: any) {
    return this.http.post(`${environment.serverUrl}ApartmentModel/upload`, formData, { reportProgress: true, observe: 'events' })
  }

  getDataById(id: number) {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;

    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.get(`${this.baseUrl}ApartmentModel/${id}`, options);
  }

  updateDataById(id: number, data: any) {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;

    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.put(`${this.baseUrl}ApartmentModel/edit/${id}`, data, options)
  }

  deleteData(id: number) {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;

    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.delete(`${this.baseUrl}ApartmentModel/delete/${id}`, options);
  }
}
