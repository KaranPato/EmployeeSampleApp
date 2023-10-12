import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  getAllEmployees() {
    return this.http.get(apiUrl);
  }

  getAllManagers(){
    return this.http.get(apiUrl + "/GetManagers");
  }

  addEmployee(data: any){
    return this.http.post(apiUrl, data);
  }
}
