import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/apartment/home/home.component';
import { LoginUserComponent } from './components/users/login-user/login-user.component';
import { NewUserComponent } from './components/users/new-user/new-user.component';
import { NewApartmentComponent } from './components/apartment/new-apartment/new-apartment.component';
import { EditApartmentComponent } from './components/apartment/edit-apartment/edit-apartment.component';
import { AllApartmentComponent } from './components/apartment/all-apartment/all-apartment.component';
import { ViewApartmentComponent } from './components/apartment/view-apartment/view-apartment.component';
import { AuthGuard } from "./service/auth-guard.guard"
import { AllUserApartmentComponent } from './components/apartment/all-user-apartment/all-user-apartment.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "user/login",
    component: LoginUserComponent
  },
  {
    path: "user/signup",
    component: NewUserComponent
  },
  {
    path: "apartment/all",
    component: AllApartmentComponent,
  },
  {
    path: "apartment/create-post",
    component: NewApartmentComponent,
    // canActivate: [AuthGuard]
  },
  {
    path: "apartment/edit-post/:id",
    component: EditApartmentComponent,
    // canActivate: [AuthGuard]
  },
  {
    path: "apartment/post-details/:id",
    component: ViewApartmentComponent
  },
  {
    path: "user/your-posts/:userid",
    component: AllUserApartmentComponent,
    // canActivate: [AuthGuard]
  },
  {
    path: "**",
    redirectTo: '/'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
