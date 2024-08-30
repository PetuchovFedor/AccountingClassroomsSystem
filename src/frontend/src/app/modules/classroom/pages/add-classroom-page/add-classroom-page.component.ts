import { Component } from '@angular/core';
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { FormsModule, ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { ClassroomCreateModel } from '../../models/classroom.model';
import { DropdownListComponent } from '../../../../shared/components/dropdown-list/dropdown-list.component';
import { DropdownProps} from '../../../../shared/components/dropdown-list/interfaces'
import { ClassroomTypeReadModel } from '../../models/classroomType.model';
import { BuildingReadModel } from '../../models/building.model';
import { ClassroomService } from '../../services/classroom.service';
import { BuildingService } from '../../services/building.service';
import { ClassroomTypeService } from '../../services/classroom-type.service';
import { DropdownListService } from '../../../../shared/services/dropdown-list.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Router } from '@angular/router';


@Component({
  selector: 'add-classroom-page',
  standalone: true,
  imports: [LabelModule, InputsModule, ButtonModule, FormsModule, ReactiveFormsModule,
    DropdownListComponent    
  ],
  templateUrl: './add-classroom-page.component.html',
  styleUrl: './add-classroom-page.component.css'
})
export class AddClassroomPageComponent {
  classroomTypeProps: DropdownProps<ClassroomTypeReadModel>;
  buildingProps: DropdownProps<BuildingReadModel>;
  private classroomType!: ClassroomTypeReadModel
  private building!: BuildingReadModel
  submit() {    
    const dto: ClassroomCreateModel = {
      name: this.createForm.controls['name'].value as string,
      capacity: this.createForm.controls['capacity'].value as number,
      number: this.createForm.controls['number'].value as number,
      floor: this.createForm.controls['floor'].value as number,
      universityBuildingId: this.building.id,
      classroomTypeId: this.classroomType.id
    }
    this.classroomService.add(dto)
    this.router.navigate(['/classroom/all'])
  }
  createForm: FormGroup
  constructor(private classroomService: ClassroomService, private buildingService: BuildingService,
    private classroomTypeService: ClassroomTypeService, private router: Router) {
    this.createForm = new FormGroup({
      'name': new FormControl('', Validators.required),
      'capacity': new FormControl('', Validators.pattern('[1-9]{1}[0-9]*')),
      'floor': new FormControl('', Validators.pattern('[1-9]{1}[0-9]*')),
      'number': new FormControl('', Validators.pattern('[1-9]{1}[0-9]*'))
    })
    let typeDropdownServide = new DropdownListService<ClassroomTypeReadModel>(this.classroomType)
    typeDropdownServide.selectedItem$
      .pipe(takeUntilDestroyed())
      .subscribe(item => this.classroomType = {...item})
    let buildingDropdownService = new DropdownListService<BuildingReadModel>(this.building)
    buildingDropdownService.selectedItem$
      .pipe(takeUntilDestroyed())
      .subscribe(item => this.building = {...item})
    this.classroomTypeProps = {
      appearance: {
        size: 'medium',
        rounded: 'large',
        fillMode: 'solid'
      },
      initValue: {id: '', name: ''},
      id: 'classroomType',
      selectedItemService: typeDropdownServide,
      dataService: this.classroomTypeService,
      label: 'Выберите тип аудитории',     
    }
    this.buildingProps = {
      appearance: {
        size: 'medium',
        rounded: 'large',
        fillMode: 'solid'
      },
      selectedItemService: buildingDropdownService,
      dataService: this.buildingService,
      initValue: {id: '', name: ''},
      id: 'building',      
      label: 'Выберите корпус',            
    }
  }

}
