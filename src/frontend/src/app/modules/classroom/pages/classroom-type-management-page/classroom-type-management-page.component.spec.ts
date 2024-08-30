import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassroomTypeManagementPageComponent } from './classroom-type-management-page.component';

describe('ClassroomTypeManagementPageComponent', () => {
  let component: ClassroomTypeManagementPageComponent;
  let fixture: ComponentFixture<ClassroomTypeManagementPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClassroomTypeManagementPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassroomTypeManagementPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
