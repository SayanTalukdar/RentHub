import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewApartmentComponent } from './components/apartment/new-apartment/new-apartment.component';
import { HomeComponent } from './components/apartment/home/home.component';
import { ViewApartmentComponent } from './components/apartment/view-apartment/view-apartment.component';
import { EditApartmentComponent } from './components/apartment/edit-apartment/edit-apartment.component';
import { AllApartmentComponent } from './components/apartment/all-apartment/all-apartment.component';
import { NewUserComponent } from './components/users/new-user/new-user.component';
import { LoginUserComponent } from './components/users/login-user/login-user.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApartmentService } from './service/apartment/apartment.service';
import { UserService } from './service/user/user.service';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './core/navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    NewApartmentComponent,
    HomeComponent,
    ViewApartmentComponent,
    EditApartmentComponent,
    AllApartmentComponent,
    NewUserComponent,
    LoginUserComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    ApartmentService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
