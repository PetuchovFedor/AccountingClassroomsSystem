import { Component, EventEmitter, Input, OnDestroy, OnInit, Output,  } from '@angular/core';
import { NgStyle } from '@angular/common';
import { DropDownsModule } from "@progress/kendo-angular-dropdowns";
import { DropdownProps} from './interfaces';
import { FormsModule, ReactiveFormsModule, NgModel } from '@angular/forms';
import { LabelModule } from "@progress/kendo-angular-label";
import { Observable, Subscription } from 'rxjs';
import { AsyncPipe

 } from '@angular/common';
@Component({
  selector: 'dropdown-list',
  standalone: true,
  imports: [DropDownsModule, FormsModule, ReactiveFormsModule, 
    NgStyle, LabelModule, AsyncPipe],
  templateUrl: './dropdown-list.component.html',
  styleUrl: './dropdown-list.component.css'
})
export class DropdownListComponent<T extends {id: string, name: string}> implements OnInit { 
  ngOnInit(): void {
    this.data = this.props.dataService.data$
  }
  
  onChange() {    
    this.props.selectedItemService.updateItem(this.selectedItem)    
  }
  @Input()
  props!: DropdownProps<T>  
  data!: Observable<T[]>
  selectedItem!: T
}
