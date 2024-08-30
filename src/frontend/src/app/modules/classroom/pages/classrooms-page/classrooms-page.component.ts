import { Component } from '@angular/core';
import { ClassroomReadModel } from '../../models/classroom.model';
import { Router } from '@angular/router';
import { ClassroomCardComponent } from '../../components/classroom-card/classroom-card.component';
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { ClassroomService } from '../../services/classroom.service';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { FilterPanelComponent } from '../../../../shared/components/filter-panel/filter-panel.component';
import { AdditionalFieldService } from '../../services/additioanl-field.service';
import { IFilterPanelProps } from '../../../../shared/components/filter-panel/interfaces';
import { AdditionalFieldReadModel } from '../../models/additioanlField.model';
import { FormControl, Validators } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'classrooms-page',
  standalone: true,
  imports: [ClassroomCardComponent, ClassroomCardComponent, ButtonModule, AsyncPipe,
    FilterPanelComponent
  ],
  templateUrl: './classrooms-page.component.html',
  styleUrl: './classrooms-page.component.css'
})
export class ClassroomsPageComponent {
  filterPanelProps!: IFilterPanelProps<AdditionalFieldReadModel>
  clickOnManagementButton() {
    this.router.navigate(['/classroom/types-management'])
  }
  clickOnNewButton() {
    this.router.navigate(['/classroom/new']) 
  }
  classrooms$: Observable<ClassroomReadModel[]>
  constructor(private router: Router, private classroomService: ClassroomService, 
    private additioanlFieldService: AdditionalFieldService
   ) { 
    this.classrooms$ = this.classroomService.data$
    const filterCallback = (filterMap: Map<string, string | null>) => {
      const result = this.classroomService.data$.value.filter(item => {
        let isApprove = true
        for (const [key, value] of filterMap) {
          if (item.additionalFields.has(key)) {
            if (value === null || item.additionalFields.get(key) === value) {
              continue         
            }
          }
          isApprove = false
          break
        }
        return isApprove
      })      
      this.classroomService.data$.next(result)
    }
    const formControlCallback = (fields: AdditionalFieldReadModel[]): Map<string, FormControl> =>  {     
      let result = new Map<string, FormControl>()
      fields.forEach(item => {
        let control = new FormControl('')
        switch (item.dataType) {
          case('string'): {
            control.addValidators(Validators.required)
            break
          }
          case('number'): {
            control.addValidators(Validators.pattern('[0-9]*'))
            break
          }
          case('date'): {
            control.addValidators(Validators.pattern('[0-9]{2}.[0-9]{2}.[0-9]{4}'))
            break
          }
          default: {
            throw new Error('Non existing data type')
          }
        }
      result.set(item.name, control)
    })    
    return result
    }
    this.filterPanelProps = {
      id: 'filterPanel',
      dataService: this.additioanlFieldService,
      filterCallbackFn: filterCallback,
      handleFormControls: formControlCallback,
      title: "Панель фильтрации по дополнительным полям",
      label: 'Выберите требуемые поля',
      cancelCallback: () => this.classroomService.updateData()
    }
  }  
  onClick() {
      
  }
}
