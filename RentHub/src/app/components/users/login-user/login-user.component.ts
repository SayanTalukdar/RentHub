import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.scss']
})
export class LoginUserComponent {
  constructor(private router: Router, private userService: UserService) { }

  ngOnInit(): void {
  }

  isUserValid: boolean = false;

  loginForm = new FormGroup({
    email: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required]),
  });
  

  loginSubmit() {
    const { email, password } = this.loginForm.value;
    this.userService.loginUser({email, password }).subscribe((res: any) => {

      if (JSON.parse(res).message == "Failure") {
        this.isUserValid = false;
        alert("Login Unsuccessfull, Enter corect Credentials.!")
      } else if (JSON.parse(res).message == "Success") {
        this.isUserValid = true;
        this.userService.setData(JSON.parse(res));
        this.router.navigate(["/"])
      }
    });
  }
}
