import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateClassroomTypeComponent } from './update-classroom-type.component';

describe('UpdateClassroomTypeComponent', () => {
  let component: UpdateClassroomTypeComponent;
  let fixture: ComponentFixture<UpdateClassroomTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateClassroomTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateClassroomTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
