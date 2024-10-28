import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment'
import { UserService } from 'src/app/service/user/user.service';

@Injectable({
  providedIn: 'root'
})

export class CommentsService {

  constructor(private http: HttpClient, private userService: UserService) { }

  baseUrl = environment.serverUrl;

  getAllComment(id: number) {
    return this.http.get(`${this.baseUrl}CommentModel/${id}`)
  }

  postComment(comment: string, id: number) {

    var data = {
      email : this.userService.getEmail(),
      date : new Date,
      commentMade: comment,
      apartmentId: id
    }
    var token = "Bearer " + JSON.parse(localStorage.getItem("data") || '').token;
    var header = new HttpHeaders({
      "ContentType": "application/json",
      "Authorization": token,
      "ResponseType": "text"
    });

    const options = {
      headers: header
    }
    return this.http.post(`${this.baseUrl}CommentModel`, data, options)
  }
}
