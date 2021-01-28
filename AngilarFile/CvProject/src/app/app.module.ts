import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CandidateTabsComponent } from './candidate-tabs/candidate-tabs.component';
import { CareerinformationsComponent } from './careerinformations/careerinformations.component';
import { EducationalInformationsComponent } from './educational-informations/educational-informations.component';
import { PersonalInfoTabsComponent } from './personal-info-tabs/personal-info-tabs.component';
import { ReferanceInfoesComponent } from './referance-infoes/referance-infoes.component';
import { TraningInformationsComponent } from './traning-informations/traning-informations.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';



@NgModule({
  declarations: [
    AppComponent,
    CandidateTabsComponent,
    CareerinformationsComponent,
    EducationalInformationsComponent,
    PersonalInfoTabsComponent,
    ReferanceInfoesComponent,
    TraningInformationsComponent,
    HomeComponent

    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
