import { Component, OnDestroy } from '@angular/core';
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { FormsModule} from '@angular/forms';
import { DropdownListComponent } from '../../../../shared/components/dropdown-list/dropdown-list.component';
import { DropdownProps } from '../../../../shared/components/dropdown-list/interfaces';
import { DropdownListService } from '../../../../shared/services/dropdown-list.service';
import { ClassroomTypeService } from '../../services/classroom-type.service';
import { ClassroomTypeReadModel, ClassroomTypeUpdateModel } from '../../models/classroomType.model';
import { Subscription } from 'rxjs';
import { runInThisContext } from 'vm';

@Component({
  selector: 'update-classroom-type',
  standalone: true,
  imports: [ButtonModule,
    FormsModule, InputsModule, DropdownListComponent
  ],
  templateUrl: './update-classroom-type.component.html',
  styleUrl: './update-classroom-type.component.css'
})
export class UpdateClassroomTypeComponent implements OnDestroy {
  onClick() {
    const dto: ClassroomTypeUpdateModel = {id: this.item.id, name: this.newName}    
    this.classroomTypeService.update(dto)
  }
  subscription: Subscription
  constructor(private classroomTypeService: ClassroomTypeService) {
    const itemService = new DropdownListService({id: '', name: ''})
    this.subscription =  itemService.selectedItem$.subscribe(item => {
      this.item = {...item}
    })
    this.dropdownListProps = {
      appearance: {
        size: 'medium',
        rounded: 'large',
        fillMode: 'solid'
      },
      initValue: {id: '', name: ''},
      id: 'classroomTypeList',
      dataService: this.classroomTypeService,
      selectedItemService: itemService,  
      style: {
        'margin-bottom': '17px',
        'width': '180px'
      }          
    }
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  }
  newName: string = ''
  item: ClassroomTypeReadModel = {id: '', name: ''}
  dropdownListProps: DropdownProps<ClassroomTypeReadModel>
}
