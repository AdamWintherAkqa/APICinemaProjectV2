import { Component, OnInit } from '@angular/core';
import { InstructorService } from 'src/app/services/instructor.service';
import { FormGroup, NgForm } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IInstructor from 'src/app/interface/IInstructor';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-instructor',
  templateUrl: './create-instructor.component.html',
  styleUrls: ['./create-instructor.component.css']
})
export class InstructorComponent implements OnInit {

  constructor(private instructorService : InstructorService) { }

  instructorList: IInstructor[];
  checked = false;


  ngOnInit(): void {
   this.getInstructors();


    }




    instructorForm = new FormGroup({
    instructorName: new FormControl('')
  })
  getInstructors(): void {
    this.instructorList = [];
    this.instructorService.getAllInstructors().subscribe((data) => { this.instructorList = data; });
  }

  createInstructor(): void {
    this.instructorForm.value.isAlive = this.checked;
    console.log(this.instructorForm.value);
    this.instructorService.createInstructor(this.instructorForm.value).subscribe();

    this.instructorList = [...this.instructorList, this.instructorForm.value];
    this.getInstructors();
  }

  deleteInstructor(instructor: IInstructor)
  {
    this.instructorService.deleteInstructor(instructor)
      .subscribe(response =>
        {
        this.instructorList = this.instructorList.filter(item => item.instructorID !== instructor.instructorID);
        }

        );



  }






}



