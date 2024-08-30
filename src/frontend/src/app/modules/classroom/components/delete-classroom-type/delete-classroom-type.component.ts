import { Component, OnDestroy } from '@angular/core';
import { DropdownProps } from '../../../../shared/components/dropdown-list/interfaces';
import { DropdownListService } from '../../../../shared/services/dropdown-list.service';
import { ClassroomTypeService } from '../../services/classroom-type.service';
import { DropdownListComponent } from '../../../../shared/components/dropdown-list/dropdown-list.component';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { ClassroomTypeReadModel } from '../../models/classroomType.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'delete-classroom-type',
  standalone: true,
  imports: [DropdownListComponent, ButtonModule],
  templateUrl: './delete-classroom-type.component.html',
  styleUrl: './delete-classroom-type.component.css'
})
export class DeleteClassroomTypeComponent implements OnDestroy {
  onClick() {
    this.classroomTypeService.delete(this.item.id)
  }
  subscription: Subscription
  constructor(private classroomTypeService: ClassroomTypeService) {
    const itemService = new DropdownListService({id: '', name: ''})
    this.subscription =  itemService.selectedItem$.subscribe(item => {
      this.item = {...item}
    })
    this.dropdownProps = {
      id: 'deleteList',
      appearance: {
        size: 'medium',
        rounded: 'large',
        fillMode: 'solid'
      },
      initValue: {id: '', name: ''},
      dataService: this.classroomTypeService,
      label: 'Выбурите тип который нужно удалить',
      selectedItemService: itemService
    }
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  }
  item: ClassroomTypeReadModel = {id: '', name: ''}
  dropdownProps: DropdownProps<ClassroomTypeReadModel>
}
