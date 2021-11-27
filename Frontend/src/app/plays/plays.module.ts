import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PlayFormComponent } from './play-form/play-form.component';
import { PlayListComponent } from './play-list/play-list.component';
import { PlayItemComponent } from './play-item/play-item.component';



@NgModule({
  declarations: [
    PlayFormComponent,
    PlayListComponent,
    PlayItemComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    RouterModule.forChild([
      {path: '',
      component: PlayListComponent,
      },
      {path: ':id',
      component: PlayListComponent,
      },
      {
        path: 'play-form/form',
        component: PlayFormComponent,
      },
      {
        path: 'play-form/:id',
        component: PlayFormComponent,
      }
    ]),
    FontAwesomeModule,
  ]
})
export class PlaysModule { }
