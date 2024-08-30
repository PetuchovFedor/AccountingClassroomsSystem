import { Component } from '@angular/core';
import { CreateClassroomTypeComponent } from '../../components/create-classroom-type/create-classroom-type.component';
import { UpdateClassroomTypeComponent } from '../../components/update-classroom-type/update-classroom-type.component';
import { DeleteClassroomTypeComponent } from '../../components/delete-classroom-type/delete-classroom-type.component';

@Component({
  selector: 'app-classroom-type-management-page',
  standalone: true,
  imports: [CreateClassroomTypeComponent, UpdateClassroomTypeComponent, DeleteClassroomTypeComponent],
  templateUrl: './classroom-type-management-page.component.html',
  styleUrl: './classroom-type-management-page.component.css'
})
export class ClassroomTypeManagementPageComponent {

}
