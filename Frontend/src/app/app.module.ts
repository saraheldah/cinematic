import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { LandingPageComponent } from './landing-page/landing-page/landing-page.component';
import { SeatListComponent } from './seats/seat-list/seat-list.component';
import { SeatFormComponent } from './seats/seat-form/seat-form.component';
import { SeatItemComponent } from './seats/seat-item/seat-item.component';
import { RegisterComponent } from './register/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AdminComponent,
    LandingPageComponent,
    SeatListComponent,
    SeatFormComponent,
    SeatItemComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: 'theaters',
        loadChildren: () => import('./theaters/theaters.module').then((m) => m.TheatersModule),
      },
      {
        path: 'plays',
        loadChildren: () => import('./plays/plays.module').then((m) => m.PlaysModule),
      },
      {
        path: 'seats',
        component: SeatListComponent,
      },
      {
        path: 'seats/:id',
        component: SeatListComponent,
      },
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'login/:succ',
        component: LoginComponent,
      },
      {
        path: 'register',
        component: RegisterComponent,
      },

      {
        path: 'admin',
        component: AdminComponent,
      },
      {
        path: '',
        component: LandingPageComponent,
      },
      {
        path: '**',
        redirectTo: '',
        pathMatch: 'full',
      },
    ]),
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
