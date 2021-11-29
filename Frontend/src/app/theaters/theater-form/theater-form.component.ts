import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TheaterService } from '../shared/theater.service';
import { Theater } from '../shared/theater.model';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';


@Component({
  selector: 'app-theater-form',
  templateUrl: './theater-form.component.html',
  styleUrls: ['./theater-form.component.css'],
})
export class TheaterFormComponent implements OnInit {
  @Output() onAddTheater: EventEmitter<Theater> = new EventEmitter();
  theaterForm!: FormGroup;
  isEditMode: boolean = false;
  theaterId!: Guid;
  theaters: Theater[];


  constructor(
    private theaterService: TheaterService,
    private router: Router,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) {this.theaters = [];}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.theaterId = Guid.parse(params.get('id')!);
      if (this.theaterId) {
        this.loadTheater(this.theaterId);
        this.isEditMode = true;
      }
    });

    this.theaterForm = this.formBuilder.group({
      name: ['', Validators.required],
      location: ['', Validators.required],
      /* seatsNumber: ['', Validators.max(50)], */
    });
  }

  loadTheater(id: Guid) {
    this.theaterService
      .getTheaterById(id)
      .subscribe((x) => this.theaterForm.patchValue(x));
  }

  onSubmit() {
    if (this.isEditMode) {
      this.updateTheater(this.theaterId);
    } else {
      this.addTheater();
    }
  }

  updateTheater(id: Guid) {
    if (this.theaterForm.valid) {
      var updatedTheater: Theater = {
        name: this.theaterForm.get('name')?.value.toUpperCase(),
        location: this.theaterForm.get('location')?.value.toUpperCase(),
      };
      this.theaterService.updateTheater(updatedTheater,id).subscribe();
      this.router.navigate(['./theaters']);
    }
  }

  addTheater() {
    if (this.theaterForm.valid) {
      const newTheater: Theater = {
        name: this.theaterForm.get('name')?.value.toUpperCase(),
        location: this.theaterForm.get('location')?.value.toUpperCase(),
      };
      this.theaterService.addTheater(newTheater).subscribe(() => (this.theaters));
      this.router.navigate(['./theaters']);
    }
  }
}
