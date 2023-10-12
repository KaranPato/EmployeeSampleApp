import { Component } from '@angular/core';
import { EmployeeService } from './employee.service';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { first } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  employees: any = [];
  managerEmployees: any = [];
  showManagersTable: boolean = false;
  showAddEmployeeForm: boolean = false;
  employeeForm: FormGroup;
  submitted = false;

  name = '';

  constructor(private service: EmployeeService, private formBuilder: FormBuilder) { }

  // EmployeeTypes
  EmployeeTypes: any = ['Employee', 'Manager']

  ngOnInit() {
    this.service.getAllEmployees().subscribe((data: any) => this.employees = data.data);
  }

  // convenience getter for easy access to form fields
  get f() { return this.employeeForm?.controls; }

  showManagers() {
    this.service.getAllManagers().subscribe((data: any) => {
      this.managerEmployees = data.data;
      this.showManagersTable = true;
    });
  }

  selectEmployeeType(event: any) {
    if (event == "1")
      this.employeeForm.controls['isManager'].setValue(false);
    else
      this.employeeForm.controls['isManager'].setValue(true);
  }

  AddEmployee() {
    this.employeeForm = this.formBuilder.group({
      id: ['', Validators.required],
      name: ['', Validators.required],
      isManager: [true, Validators.required],
    });
    this.showAddEmployeeForm = true;
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.employeeForm?.invalid) {
      return;
    }

    let array = [];
    array.push(this.employeeForm.value);
    this.service.addEmployee(array).subscribe((data: any) => {
      this.managerEmployees = data.data;
      this.showManagersTable = true;
    })
  }

}
