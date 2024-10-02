import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubServicesDetailsComponent } from './sub-services-details.component';

describe('SubServicesDetailsComponent', () => {
  let component: SubServicesDetailsComponent;
  let fixture: ComponentFixture<SubServicesDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SubServicesDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubServicesDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
