import { Component, OnInit } from '@angular/core';
import { ActorService } from 'src/app/services/actor.service';
import { FormGroup, NgForm } from '@angular/forms';
import { FormControl } from '@angular/forms';
import IActor from 'src/app/interface/IActor';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.css']
})
export class ActorComponent implements OnInit {

  constructor(private actorService : ActorService) { }

  actorList: IActor[];
  checked = false;


  ngOnInit(): void {
   this.getActors();


    }




    actorForm = new FormGroup({
    actorName: new FormControl('')
  })
  getActors(): void {
    this.actorList = [];
    this.actorService.getAllActors().subscribe((data) => { this.actorList = data; });

  }

  createActor(): void {
    this.actorForm.value.isAlive = this.checked;
    console.log(this.actorForm.value);
    this.actorService.createActor(this.actorForm.value).subscribe();
    this.getActors();
    this.actorList = [...this.actorList, this.actorForm.value];

  }

  deleteActor(actor: IActor)
  {
    this.actorService.deleteActor(actor)
      .subscribe(response =>
        {
        this.actorList = this.actorList.filter(item => item.actorID !== actor.actorID);

        }

        );


  }
  






}



