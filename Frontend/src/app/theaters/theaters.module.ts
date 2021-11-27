import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TheaterListComponent } from './theater-list/theater-list.component';
import { TheaterItemComponent } from './theater-item/theater-item.component'; 
import { TheaterService } from './shared/theater.service';
import { TheaterFormComponent } from './theater-form/theater-form.component';

@NgModule({
  declarations: [
    TheaterFormComponent,
    TheaterListComponent,
    TheaterItemComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    RouterModule.forChild([
      {path: '',
      component: TheaterListComponent,
      },
      {
        path: 'theater-form',
        component: TheaterFormComponent,
      },
      {
        path: 'theater-form/:id',
        component: TheaterFormComponent,
      }
    ]),
    FontAwesomeModule,
  ],
  providers: [TheaterService]
})
export class TheatersModule { }
