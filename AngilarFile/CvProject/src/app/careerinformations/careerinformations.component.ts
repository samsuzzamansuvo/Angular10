import { CareerinformationsService } from './../Shared/careerinformations.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-careerinformations',
  templateUrl: './careerinformations.component.html',
  styleUrls: ['./careerinformations.component.css']
})
export class CareerinformationsComponent implements OnInit {

  careerinformationForms: FormArray = this.fb.array([]);
  careerInfoList=[];

  constructor(public fb:FormBuilder, public carerService:CareerinformationsService) { }

  ngOnInit(): void {

    this.carerService.getCareerinformationList()
    .subscribe(res=>this.careerInfoList=res as []);


    this.carerService.getCareerinformationList().subscribe
    (
      res=>{
        if(res==[])
        this.addCareerinformationsForms();
        else{
          (res as []).forEach((careerInfo:any)=>[
            this.careerinformationForms.push(this.fb.group({
              ID:[careerInfo.ID],
              CandidateID: [careerInfo.CandidateID],
              CompamnyName: [careerInfo.CompamnyName],
              CompanyBusiness: [careerInfo.CompanyBusiness],
              Designation: [careerInfo.Designation],
              Department: [careerInfo.Department],
              StartDate: [careerInfo.StartDate],
              EndDate: [careerInfo.EndDate]
            }))

          ]);
        }
      }
    );
  }


  addCareerinformationsForms() {
    this.careerinformationForms.push(this.fb.group({
      ID:[0],
      CandidateID: [0],
      CompamnyName: [''],
      CompanyBusiness: [''],
      Designation: [''],
      Department: [''],
      StartDate: [''],
      EndDate: ['']
    }));
  }

  recordSubmit(fg:FormGroup){
    this.carerService.postCareerinformation(fg.value).subscribe(
      (res:any)=>{}
    )
  }
}
