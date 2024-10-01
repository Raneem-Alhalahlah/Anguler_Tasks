import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './Raneem/nav-bar/nav-bar.component';
import { ServicesComponent } from './Raneem/services/services.component';
import { SubServicesComponent } from './Raneem/sub-services/sub-services.component';
import { HomeComponent } from './Raneem/home/home.component';
import { Router, RouterModule } from '@angular/router';
import { LectureComponent } from './Raneem/lecture/lecture.component';
import { FormsModule, NgForm } from '@angular/forms';
import { SubscriptionComponent } from './Raneem/subscription/subscription.component';
import { SubServicesDetailsComponent } from './Raneem/sub-services-details/sub-services-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ServicesComponent,
    SubServicesComponent,
    LectureComponent,
    SubscriptionComponent,
    SubServicesDetailsComponent
  ],
  imports: [
    FormsModule,
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot(
      [
        { path: "", component: HomeComponent, pathMatch: "full" },
        { path: "Services", component: ServicesComponent },
        { path: "SubServices/:id", component: SubServicesComponent },
        { path: "lecture", component: LectureComponent },
        { path: "Subsicription", component: SubscriptionComponent },
        { path: "details/:id", component: SubServicesDetailsComponent }
      ]
    )
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
