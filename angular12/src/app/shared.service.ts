import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:6848/api";
  readonly PhotoUrl = "http://localhost:6848/Photos/";

  constructor(private http:HttpClient) { }

  getDeptList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Department');
  }
  addDeparment(val:any){
    return this.http.post(this.APIUrl+'/Department', val);
  }
  updateDepartment(val:any){
    console.log('update service');
    return this.http.put(this.APIUrl+'/Department', val);
  }
  deleteDepartment(val:any){
    return this.http.delete(this.APIUrl+'/Department/'+val);
  }

  getExperienceList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Experience');
  }
  addExperience(val:any){
    console.log(val);
    return this.http.post(this.APIUrl+'/Experience', val);
  }
  updateExperience(val:any){
    debugger;
    console.log('update service');
    return this.http.put(this.APIUrl+'/Experience',val);
  }
  deleteExperience(val:any){
    return this.http.delete(this.APIUrl+'/Experience/'+val);
  }
  
  getEmployeeList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employee');
  }
  addEmployee(val:any){
    return this.http.post(this.APIUrl+'/Employee', val);
  }
  updateEmployee(val:any){
    console.log('update service');
    return this.http.put(this.APIUrl+'/Employee', val);
  }
  deleteEmployee(val:any){
    return this.http.delete(this.APIUrl+'/Employee/'+val);
  }

  uploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/Employee/SaveFile', val);
  }
  getAllDepartmentNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/Employee/GetAllDepartmentNames");
  }
  getAllEmployeeNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+"/Experience/GetAllEmployeeNames");
  }

}
