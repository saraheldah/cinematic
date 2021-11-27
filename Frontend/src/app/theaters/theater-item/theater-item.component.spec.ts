import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TheaterItemComponent } from './theater-item.component';

describe('TheaterItemComponent', () => {
  let component: TheaterItemComponent;
  let fixture: ComponentFixture<TheaterItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TheaterItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TheaterItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
