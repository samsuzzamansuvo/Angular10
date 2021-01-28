import { CandidateTabsService } from './../Shared/candidate-tabs.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormArray, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-candidate-tabs',
  templateUrl: './candidate-tabs.component.html',
  styleUrls: ['./candidate-tabs.component.css']
})
export class CandidateTabsComponent implements OnInit {
  candidateTabsForms: FormArray = this.fb.array([]);
  candidateList=[];

  constructor(public fb:FormBuilder,public candidateTabService:CandidateTabsService) { }

  ngOnInit(): void {
    this.candidateTabService.getCandidateList()
    .subscribe(res=>this.candidateList=res as []);


    this.candidateTabService.getCandidateList().subscribe
    (
      res=>{
        if(res==[])
        this.addCandidateTabsForms();
        else{
          (res as []).forEach((candidateTab:any)=>[
            this.candidateTabsForms.push(this.fb.group({
              CandidateID: [candidateTab.candidateID],
              CreateDate: [candidateTab.CreateDate],
              UpdateDate: [candidateTab.UpdateDate],
              EmailAddress: [candidateTab.EmailAddress],
              ContactNo: [candidateTab.ContactNo]
            }))

          ]);
        }
      }
    );
  }

  addCandidateTabsForms() {
    this.candidateTabsForms.push(this.fb.group({
      CandidateID: [0],
      CreateDate: [''],
      UpdateDate: [''],
      EmailAddress: [''],
      ContactNo: ['']
    }));
  }

  recordSubmit(fg:FormGroup){
    this.candidateTabService.postCandidate(fg.value).subscribe(
      (res:any)=>{}
    )
  }
}
