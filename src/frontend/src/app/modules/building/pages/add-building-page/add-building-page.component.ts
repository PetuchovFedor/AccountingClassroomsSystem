import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { LabelModule } from "@progress/kendo-angular-label";
import { InputsModule } from "@progress/kendo-angular-inputs";
import { ButtonModule } from '@progress/kendo-angular-buttons';
import { BuildingService } from '../../services/building.service';
import { BuildingCreateModel } from '../../models/building.model';
import { Router } from '@angular/router';

@Component({
  selector: 'add-building-page',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, InputsModule, LabelModule, ButtonModule],
  templateUrl: './add-building-page.component.html',
  styleUrl: './add-building-page.component.css'
})
export class AddBuildingPageComponent {
  submit() {    
    let dto: BuildingCreateModel = {
      name: this.createForm.controls['name'].value as string,
      address: this.createForm.controls['address'].value as string,
      floorsCount: this.createForm.controls['floorsCount'].value
    }    
    this.buildingService.add(dto)
    this.router.navigate(['/building'])
  }
  createForm: FormGroup
  constructor(private buildingService: BuildingService, private router: Router) {
    this.createForm = new FormGroup({
      'name': new FormControl('', Validators.required),
      'address': new FormControl('', Validators.required),
      'floorsCount': new FormControl('', [Validators.required, Validators.pattern('[1-9]{1}[0-9]*')])
    })
  }
}
