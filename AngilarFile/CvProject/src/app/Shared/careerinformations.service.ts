import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CareerinformationsService {

  constructor(public http:HttpClient) { }
  
  getCareerinformationList(){
    return this.http.get(environment.apiBaseURI +'/Careerinformations')
  }

  postCareerinformation(formData){
    return this.http.post(environment.apiBaseURI +'/Careerinformations' ,formData)
  }
}
