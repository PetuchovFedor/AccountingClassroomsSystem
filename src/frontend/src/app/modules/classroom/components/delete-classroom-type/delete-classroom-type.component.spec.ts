import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteClassroomTypeComponent } from './delete-classroom-type.component';

describe('DeleteClassroomTypeComponent', () => {
  let component: DeleteClassroomTypeComponent;
  let fixture: ComponentFixture<DeleteClassroomTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteClassroomTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteClassroomTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
