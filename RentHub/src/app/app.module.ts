import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { NewApartmentComponent } from './components/apartment/new-apartment/new-apartment.component';
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
import { UploadComponent } from './components/apartment/new-apartment/upload/upload.component';
import { AllUserApartmentComponent } from './components/apartment/all-user-apartment/all-user-apartment.component';
import { CommentsService } from './service/apartment/comments.service';
import { FavouriteService } from './service/user/favourite.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NewApartmentComponent,
    ViewApartmentComponent,
    EditApartmentComponent,
    AllApartmentComponent,
    NewUserComponent,
    LoginUserComponent,
    NavbarComponent,
    UploadComponent,
    AllUserApartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ModalModule.forRoot()
  ],
  providers: [
    ApartmentService,
    UserService,
    CommentsService,
    FavouriteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
