import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/login/shared/user.model';
import { AuthenticationService } from '../shared/authentication.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  registrationSuccess: boolean = true;
  constructor(private formBuilder: FormBuilder,private route: ActivatedRoute,private authService: AuthenticationService,private router: Router) { }

  ngOnInit(): void {
    this.registrationSuccess = this.route.snapshot.params['succ'];
    console.log(this.registrationSuccess);
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit(){
    if(this.loginForm.valid){
      const user: User = {
         username: this.loginForm.get('username')?.value,
         password: this.loginForm.get('password')?.value,
      };
      this.authService.login(user).subscribe(() => this.router.navigateByUrl('/landing-page'));
    }
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
