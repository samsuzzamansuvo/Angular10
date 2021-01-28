import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CandidateTabsService {

  constructor(public http:HttpClient) { }

  getCandidateList(){
    return this.http.get(environment.apiBaseURI +'/CandidateTabs')
  }

  postCandidate(formData){
    return this.http.post(environment.apiBaseURI +'/CandidateTabs' ,formData)
  }
}
