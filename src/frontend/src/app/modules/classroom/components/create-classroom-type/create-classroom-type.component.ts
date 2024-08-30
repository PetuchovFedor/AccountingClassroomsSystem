import { Component } from '@angular/core';
import { InputsModule } from "@progress/kendo-angular-inputs";
import { FormsModule } from '@angular/forms';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { LabelModule } from "@progress/kendo-angular-label";
import { ClassroomTypeService } from '../../services/classroom-type.service';
import { ClassroomTypeCreateModel } from '../../models/classroomType.model';

@Component({
  selector: 'create-classroom-type',
  standalone: true,
  imports: [FormsModule, InputsModule, ButtonModule, LabelModule],
  templateUrl: './create-classroom-type.component.html',
  styleUrl: './create-classroom-type.component.css'
})
export class CreateClassroomTypeComponent {
  constructor(private classroomTypeService: ClassroomTypeService) {

  }
  onClick() {
    const dto: ClassroomTypeCreateModel = {
      name: this.newClassroomType
    }
    this.classroomTypeService.add(dto)
    this.newClassroomType = ''
  }
  newClassroomType: string = ''
}
