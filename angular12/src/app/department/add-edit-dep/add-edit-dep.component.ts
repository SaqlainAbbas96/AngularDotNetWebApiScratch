import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedService) { }
 
  @Input() dep:any;
  DepartmentId:string="";
  DepartmentName:string="";

  ngOnInit(): void {
    this.DepartmentId = this.dep.DepartmentId;
    this.DepartmentName = this.dep.DepartmentName;
  }

  addDepartment(){
    var val = {DepartmentId:this.DepartmentId, 
              DepartmentName:this.DepartmentName};
              this.service.addDeparment(val).subscribe(res=>{alert(res.toString());
              });
  }

  updateDepartment(){
    var val = {DepartmentId:this.DepartmentId, 
              DepartmentName:this.DepartmentName};
              this.service.updateDepartment(val).subscribe(res=>{alert(res.toString());
              });
  }


}
