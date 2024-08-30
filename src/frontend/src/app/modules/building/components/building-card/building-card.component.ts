import { Component, Input, OnInit } from '@angular/core';
import { BuildingReadModel, BuildingUpdateModel } from '../../models/building.model';
import { IconsModule } from "@progress/kendo-angular-icons";
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { trashIcon, pencilIcon, cancelIcon, checkIcon } from '@progress/kendo-svg-icons';
import { FormsModule, ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { BuildingService } from '../../services/building.service';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'building-card',
  standalone: true,
  imports: [IconsModule, ButtonModule, FormsModule, ReactiveFormsModule, InputsModule, LabelModule],
  templateUrl: './building-card.component.html',
  styleUrl: './building-card.component.css'
})
export class BuildingCardComponent implements OnInit {
  constructor(private buildingService: BuildingService) {

  }
  onDelete() {
    this.buildingService.delete(this.building.id)
  }

  onUpdate() {
    let dto: BuildingUpdateModel = {
      id: this.building.id,
      name: this.updateForm.controls['name'].value as string,
      address: this.updateForm.controls['address'].value as string,
      floorsCount: this.updateForm.controls['floorsCount'].value as number,
    }
    if (dto.name == this.building.name && dto.floorsCount == this.building.floorsCount && dto.address == this.building.address) {
      this.isEdit = false
      return
    }
    this.buildingService.update(dto)
    this.isEdit = false
  }
  public trashIcon = trashIcon
  public pencilIcon = pencilIcon
  public cancelIcon = cancelIcon
  public checkIcon = checkIcon
  
  isEdit = false
  updateForm!: FormGroup
  ngOnInit(): void {
    this.updateForm = new FormGroup({
      'name': new FormControl(this.building.name, Validators.required),
      'address': new FormControl(this.building.address, Validators.required),
      'floorsCount': new FormControl(this.building.floorsCount, [Validators.required, Validators.pattern('[1-9]{1}[0-9]*')])
    })
  }

  @Input()
  building!: BuildingReadModel 

  setShowEditIcon() {
    this.isEdit = !this.isEdit
  }
  
  
}
