import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateservicComponent } from './updateservic.component';

describe('UpdateservicComponent', () => {
  let component: UpdateservicComponent;
  let fixture: ComponentFixture<UpdateservicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateservicComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateservicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
