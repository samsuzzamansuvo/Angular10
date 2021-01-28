import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidateTabsComponent } from './candidate-tabs/candidate-tabs.component';
import { CareerinformationsComponent } from './careerinformations/careerinformations.component';


const routes: Routes = [
  {path:'',redirectTo:'/home',pathMatch:'full'},
  {path:'home',component:HomeComponent},
  {path:"candidate-tabs",component:CandidateTabsComponent},
  {path:'careerinformations',component:CareerinformationsComponent}
    
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }