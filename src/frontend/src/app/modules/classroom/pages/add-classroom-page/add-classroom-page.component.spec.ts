import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddClassroomPageComponent } from './add-classroom-page.component';

describe('AddClassroomPageComponent', () => {
  let component: AddClassroomPageComponent;
  let fixture: ComponentFixture<AddClassroomPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddClassroomPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddClassroomPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
