import { Component, DestroyRef, inject, Input, OnDestroy, OnInit } from '@angular/core';
import { IconsModule } from "@progress/kendo-angular-icons";
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { trashIcon, pencilIcon, cancelIcon, checkIcon } from '@progress/kendo-svg-icons';
import { FormsModule, ReactiveFormsModule, FormGroup, FormControl, Validators, ValidatorFn } from '@angular/forms';
import { ClassroomReadModel, ClassroomUpdateModel } from '../../models/classroom.model';
import { DropdownListComponent } from '../../../../shared/components/dropdown-list/dropdown-list.component';
import { DropdownProps} from '../../../../shared/components/dropdown-list/interfaces';
import { ClassroomTypeReadModel } from '../../models/classroomType.model';
import { BuildingReadModel } from '../../models/building.model';
import { ClassroomService } from '../../services/classroom.service';
import { ClassroomTypeService } from '../../services/classroom-type.service';
import { BuildingService } from '../../services/building.service';
import { DropdownListService } from '../../../../shared/services/dropdown-list.service';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop'
import { environment } from '../../../../../environments/environment';
import { AdditionalFieldReadModel } from '../../models/additioanlField.model';
import { AdditionalFieldService } from '../../services/additioanl-field.service';

@Component({
  selector: 'classroom-card',
  standalone: true,
  imports: [IconsModule, LabelModule, InputsModule, ButtonModule, FormsModule, ReactiveFormsModule,
    DropdownListComponent
  ],
  templateUrl: './classroom-card.component.html',
  styleUrl: './classroom-card.component.css'
})

export class ClassroomCardComponent implements OnInit {
  destroyRef = inject(DestroyRef)
  classroomTypeProps!: DropdownProps<ClassroomTypeReadModel>
  buildingProps!: DropdownProps<BuildingReadModel>
  public trashIcon = trashIcon
  public pencilIcon = pencilIcon
  public cancelIcon = cancelIcon
  public checkIcon = checkIcon
  private classroomType!: ClassroomTypeReadModel
  private building!: BuildingReadModel
  isEdit = false
  updateForm!: FormGroup
  additionalFields!: AdditionalFieldReadModel[]
  @Input()
  classroom!: ClassroomReadModel

  onUpdate() {
    let additioanlFields: Map<string, string> = new Map<string, string>()
    this.additionalFields.forEach(item => {
      if (this.updateForm.controls[item.name].value != '') {
        additioanlFields.set(item.id, this.updateForm.controls[item.name].value)
      }
    })
    let tmp: {[key:string] : string} = {}
    additioanlFields.forEach((value: string, key: string) => {      
      tmp[key] = value
    })    
    const dto: ClassroomUpdateModel = {
      id: this.classroom.id,
      name: this.updateForm.controls['name'].value as string,
      capacity: this.updateForm.controls['capacity'].value as number,
      number: this.updateForm.controls['number'].value as number,
      floor: this.updateForm.controls['floor'].value as number,
      universityBuildingId: this.building.id,
      classroomTypeId: this.classroomType.id,
      additionalFields: tmp
    }
    this.classroomService.update(dto)
    this.isEdit = false    
  }
  onDelete() {
    this.classroomService.delete(this.classroom.id)
  }
  
  constructor(private classroomService: ClassroomService, private buildingService: BuildingService,
    private classroomTypeService: ClassroomTypeService, private additionalFieldService: AdditionalFieldService
  ) {
    

  }
  setShowEditIcon() {
    this.isEdit = !this.isEdit
  }
  ngOnInit(): void {
    this.updateForm = new FormGroup({
      'name': new FormControl(this.classroom.name, Validators.required),
      'capacity': new FormControl(this.classroom.capacity, Validators.pattern('[1-9]{1}[0-9]*')),
      'floor': new FormControl(this.classroom.floor, Validators.pattern('[1-9]{1}[0-9]*')),
      'number': new FormControl(this.classroom.number, Validators.pattern('[1-9]{1}[0-9]*'))      
    })    
    this.additionalFieldService.data$
    .pipe(takeUntilDestroyed(this.destroyRef))
    .subscribe(data => {
      this.additionalFields = data
      this.additionalFields.forEach(item => {        
        this.updateForm.addControl(item.name, this.handleFormControl(item, this.classroom.additionalFields))
      })
    })
    
    this.classroomType = {...this.classroom.classroomType}
    this.building = {...this.classroom.universityBuilding}
    let typeDropdownServide = new DropdownListService<ClassroomTypeReadModel>(this.classroomType)
    typeDropdownServide.selectedItem$
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(item => this.classroomType = {...item})
    let buildingDropdownService = new DropdownListService<BuildingReadModel>(this.building)
    buildingDropdownService.selectedItem$
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(item => this.building = {...item})
    
    this.classroomTypeProps = {
      appearance: {
        size: 'medium',
        rounded: 'large',
        fillMode: 'solid'
      },
      initValue: {...this.classroomType},
      id: 'classroomType',
      dataService: this.classroomTypeService,
      selectedItemService: typeDropdownServide,
      label: 'Выберите тип аудитории',           
    }
    this.buildingProps = {
      appearance: {
        size: 'medium',
        rounded: 'large',
        fillMode: 'solid'
      },
      dataService: this.buildingService,
      initValue: {...this.building},
      selectedItemService: buildingDropdownService,
      id: 'building',      
      label: 'Выберите корпус',            
    }
  }

  private handleFormControl(field: AdditionalFieldReadModel, classroomFields: Map<string, string>): FormControl {
    let result: FormControl
    if (classroomFields.has(field.name)) {
      result = new FormControl(classroomFields.get(field.name))
    } else {
      result = new FormControl('')
    }
    switch (field.dataType) {
      case('string'): {
        result.addValidators(Validators.required)
        break
      }
      case('number'): {
        result.addValidators(Validators.pattern('[0-9]*'))
        break
      }
      case('date'): {
        result.addValidators(Validators.pattern('[0-9]{2}.[0-9]{2}.[0-9]{4}'))
        break
      }
      default: {
        throw new Error('Non existing data type')
      }
    }
    return result;
  }
}


