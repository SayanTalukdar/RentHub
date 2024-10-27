import { Component, DoCheck, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit, DoCheck {

  isAuthenticated: boolean = false;
  ngOnInit(): void {
    this.isAuthenticated = this.userService.isAuthenticated()
  }
  ngDoCheck(): void {
    this.isAuthenticated = this.userService.isAuthenticated()
  }

  constructor(private userService: UserService, private router: Router) { }

  logout() {
    this.userService.removeData();
    this.router.navigateByUrl("/user/login")
  }
}

