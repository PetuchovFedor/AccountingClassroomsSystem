import { Component, Input, OnInit, DestroyRef, inject } from '@angular/core';
import { DropDownsModule, RemoveTagEvent } from "@progress/kendo-angular-dropdowns";
import { AsyncPipe } from '@angular/common';
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from '@progress/kendo-angular-inputs';
import { IFilterPanelProps } from './interfaces';
import { BehaviorSubject, Observable } from 'rxjs';
import { NgStyle} from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ButtonModule } from '@progress/kendo-angular-buttons';
@Component({
  selector: 'filter-panel',
  standalone: true,
  imports: [DropDownsModule, AsyncPipe, LabelModule, InputsModule,
    FormsModule, ReactiveFormsModule, NgStyle, ButtonModule
  ],
  templateUrl: './filter-panel.component.html',
  styleUrl: './filter-panel.component.css'
})
export class FilterPanelComponent<T extends {id:string, name:string}> implements OnInit {
  destroyRef = inject(DestroyRef)
  filterForm!: FormGroup
  formControlMap!: Map<string, FormControl>
  data: T[] = []
  @Input()
  props!: IFilterPanelProps<T>
  selectedValues: T[] = []
  constructor() {
    this.filterForm = new FormGroup({})
  }
  ngOnInit(): void {
    this.props.dataService.data$
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe(data => {
        this.data = data
        if (this.props.handleFormControls !== undefined) {
          this.formControlMap = this.props.handleFormControls(data)          
          this.formControlMap.forEach((value, key) => this.filterForm.addControl(key, value))
        }
      })    
  }

  onChange() {
    if (this.props.handleFormControls !== undefined) {
      return
    }
    this.selectedValues.forEach(value => {
      if (!this.filterForm.contains(value.name)) {
        this.filterForm.addControl(value.name, this.formControlMap.get(value.name))
      }      
    })
  }

  onRemove($event: RemoveTagEvent) {
    if (this.props.handleFormControls !== undefined) {
      return
    }    
    this.filterForm.removeControl($event.dataItem.name)    
  }

  onApply() {
    let filterParams  = new Map<string, string | null>()
    this.selectedValues.forEach(item => {
      if (this.filterForm.contains(item.name)) {
        const value = this.filterForm.controls[item.name].value as string
        if (value == '') {
          filterParams.set(item.name, null)
        } else {
          filterParams.set(item.name, value)
        }
      } else {
        filterParams.set(item.name, null)
      }
    })
    this.props.filterCallbackFn(filterParams)    
  }
  onCancel() {
    this.props.cancelCallback()
  }
}
