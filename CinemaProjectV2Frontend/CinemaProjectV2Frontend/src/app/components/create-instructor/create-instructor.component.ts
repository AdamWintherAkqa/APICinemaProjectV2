import { Component, Input, OnInit } from '@angular/core';
import { GenreService } from 'src/app/services/genre.service';
import { FormGroup, NgForm } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IInstructor from 'src/app/interface/IInstructor';
import { Observable } from 'rxjs';
import { InstructorService } from 'src/app/services/instructor.service';
import { __values } from 'tslib';
import { HttpClient } from '@angular/common/http';




@Component({
  selector: 'app-create-instructor',
  templateUrl: './create-instructor.component.html',
  styleUrls: ['./create-instructor.component.css']
})
export class CreateInstructorComponent implements OnInit {

  instructorName:string = '';
  instructorID:number;


  constructor(private instructorService : InstructorService) { }

  instructorList: IInstructor[];
  checked = false;

  ngOnInit(): void {

    this.instructorService.getAllInstructors().subscribe((data) => {this.instructorList = data})
  }
  instructorForm = new FormGroup({
  instructorName: new FormControl('')


  }


  )
  createInstructor(): void {
    console.log(this.instructorForm.value);
    this.instructorService.createInstructor(this.instructorForm.value).subscribe();
    this.instructorList = [...this.instructorList, this.instructorForm.value];
  }


  deleteInstructor(instructor: IInstructor)
  {
    this.instructorService.deleteInstructor(instructor)
    .subscribe(response =>
        {
          this.instructorList = this.instructorList.filter(item => item.instructorID !== instructor.instructorID);


        });


  }

}





  // updateInstructor(instructor:IInstructor){
  // let endPoints = "http://localhost:4200/create-instructor"
  // this.instructorService.updateInstructor(instructor).subscribe(data => {
  // console.log(data);















