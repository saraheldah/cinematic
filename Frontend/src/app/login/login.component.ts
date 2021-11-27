import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  registrationSuccess: boolean = true;
  constructor(private formBuilder: FormBuilder,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.registrationSuccess = this.route.snapshot.params['succ'];
    console.log(this.registrationSuccess);
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit(){
  }
}
