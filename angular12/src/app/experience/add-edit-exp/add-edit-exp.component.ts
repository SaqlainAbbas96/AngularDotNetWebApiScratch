import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-exp',
  templateUrl: './add-edit-exp.component.html',
  styleUrls: ['./add-edit-exp.component.css']
})
export class AddEditExpComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() exp:any;
  ExperienceId:any="";
  Employee:any="";
  ExperienceYear:any="";
  ExperienceDescription:any="";

  EmployeeList:any=[];

  ngOnInit(): void {
   
    this.loadEmployeeList();
  }

  loadEmployeeList(){
    this.service.getAllEmployeeNames().subscribe((data:any)=>{
      this.EmployeeList = data;

      this.ExperienceId = this.exp.ExperienceId;
      this.Employee = this.exp.Employee;
      this.ExperienceYear = this.exp.ExperienceYear;
      this.ExperienceDescription = this.exp.ExperienceDescription;
    });
  }

  addExperience(){
    var val = { ExperienceId:this.ExperienceId, 
                Employee:this.Employee, 
                ExperienceYear:this.ExperienceYear, 
                ExperienceDescription:this.ExperienceDescription};
                debugger;

                this.service.addExperience(val).subscribe(res=>{
                  alert(res.toString());
                });
  }

  updateExperience(){
    var val = {ExperienceId:this.ExperienceId, 
              Employee:this.Employee,
              ExperienceYear:this.ExperienceYear,
              ExperienceDescription:this.ExperienceDescription};
              debugger;
              this.service.updateExperience(val).subscribe(res=>{
                alert(res.toString());
              });
  }


}
