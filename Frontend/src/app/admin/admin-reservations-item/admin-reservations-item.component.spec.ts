import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminReservationsItemComponent } from './admin-reservations-item.component';

describe('AdminReservationsItemComponent', () => {
  let component: AdminReservationsItemComponent;
  let fixture: ComponentFixture<AdminReservationsItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminReservationsItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminReservationsItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
