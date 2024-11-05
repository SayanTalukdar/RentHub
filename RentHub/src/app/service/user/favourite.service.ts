import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class FavouriteService {

  constructor(private http: HttpClient,
    private userService: UserService
  ) { }

  baseUrl = environment.serverUrl;

  getAllFavourites() {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;
    const userId = this.userService.getUserId();

    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.get(`${this.baseUrl}FavouriteModel/${userId}`, options);
  }

  markFavourite(id: number) {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;
    var email = this.userService.getEmail();
    var data = {
      email : email,
      apartmentId : id
    }
    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.post(`${this.baseUrl}FavouriteModel/markFavorite`, data, options);
  }

  removeFavaourite(id: number) {
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;
    const userId = this.userService.getUserId();

    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.delete(`${this.baseUrl}FavouriteModel/${userId}/${id}`, options);
  }
}
