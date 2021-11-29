import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login/login.component';
import { AdminComponent } from './admin/admin-login/admin.component';
import { LandingPageComponent } from './landing-page/landing-page/landing-page.component';
import { SeatListComponent } from './seats/seat-list/seat-list.component';
import { RegisterComponent } from './login/register/register.component';
import { AdminReservationsComponent } from './admin/admin-reservations/admin-reservations.component';
import { AdminReservationsItemComponent } from './admin/admin-reservations-item/admin-reservations-item.component';
import { AuthGuard } from 'src/_guards/auth-guard';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AdminComponent,
    LandingPageComponent,
    SeatListComponent,
    RegisterComponent,
    AdminReservationsComponent,
    AdminReservationsItemComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {
        path: 'theaters',
        canActivate: [AuthGuard],
        loadChildren: () => import('./theaters/theaters.module').then((m) => m.TheatersModule),
      },
      {
        path: 'plays',
        canActivate: [AuthGuard],
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
        path: 'landing-page',
        component: LandingPageComponent,
      },
      {
        path: 'pending',
        component: AdminReservationsComponent,
      },
      {
        path: '**',
        redirectTo: 'login',
        pathMatch: 'full',
      },
    ]),
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
