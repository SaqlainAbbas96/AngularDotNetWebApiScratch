import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-exp',
  templateUrl: './show-exp.component.html',
  styleUrls: ['./show-exp.component.css']
})
export class ShowExpComponent implements OnInit {

  constructor(private service:SharedService) { }

  ExperienceList:any=[];
  ModalTitle:any;
  ActivateAddEditExpComp:boolean=false;
  exp:any;

  ngOnInit(): void {
    this.refreshExpList();
  }

  refreshExpList(){
    this.service.getExperienceList().subscribe(data => {
      this.ExperienceList = data;
    });
  }

  addClick(){
    this.exp={
      ExperienceId:0,
      Employee:"",
      ExperienceYear:"",
      ExperienceDescription:""
    }
    this.ModalTitle="Add Experience"; 
    this.ActivateAddEditExpComp=true;
  }

  editClick(item:any){
    this.exp = item;
    this.ModalTitle="Edit Experience";
    this.ActivateAddEditExpComp = true;
  }

  
  deleteClick(item:any){
    if(confirm('Are you sure??')){
      this.service.deleteExperience(item.ExperienceId).subscribe(data=>{
        alert(data.toString());
        this.refreshExpList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditExpComp=false;
    this.refreshExpList();
  }

}
