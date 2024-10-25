import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  baseUrl = environment.serverUrl;

  signup(userData: any) {
    const data: any = {
      fullName: userData.name,
      email: userData.email,
      password: userData.password
    }
    return this.http.post(`${this.baseUrl}UserModel/signup`, data)
  }

  loginUser(userData : any) {
    const data: any = {
      email: userData.email,
      password: userData.password
    }
    return this.http.post(`${this.baseUrl}UserModel/signup`,data);
  }

  setData(data: Array<String>) {
    //console.log(data)
    localStorage.setItem("data", JSON.stringify(data));
  }

  removeData() {
    localStorage.removeItem("data");
  }

  isAuthenticated(): boolean {
    if (JSON.parse(JSON.stringify(localStorage.getItem("data"))) != null) {
      return true;
    } else {
      return false;
    }
  }
}
