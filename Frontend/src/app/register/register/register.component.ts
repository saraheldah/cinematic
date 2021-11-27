import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../shared/user.model';
import { UserService } from '../shared/user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  isValid: boolean = true;
  success: boolean = false;

  constructor(private formBuilder: FormBuilder,private userService: UserService,private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['',Validators.required],
      password: ['', Validators.minLength(10)],
      confirmPassword: ['',Validators.required]
    });
  }

  onSubmit(){
    if(this.registerForm.get('password')?.value != this.registerForm.get('confirmPassword')?.value){
      this.isValid = false;
    }
    if (this.registerForm.valid && this.isValid) {
      const newUser: User = {
        username: this.registerForm.get('username')?.value,
        email: this.registerForm.get('email')?.value.toLowerCase(),
        phone: this.registerForm.get('phone')?.value,
        password: this.registerForm.get('password')?.value,
        role: 0,
      };
      this.userService.addUser(newUser).subscribe();
      this.success = true;
      var succ = this.success ;
      this.router.navigate(['./login',succ]);
    }
  }

}
