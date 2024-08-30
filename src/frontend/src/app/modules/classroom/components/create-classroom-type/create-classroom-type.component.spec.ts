import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateClassroomTypeComponent } from './create-classroom-type.component';

describe('CreateClassroomTypeComponent', () => {
  let component: CreateClassroomTypeComponent;
  let fixture: ComponentFixture<CreateClassroomTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateClassroomTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateClassroomTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
