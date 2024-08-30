import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BuildingRoutingModule } from './building-routing.module';
import { BuildingsPageComponent } from './pages/buildings-page/buildings-page.component';
import { BuildingCardComponent } from './components/building-card/building-card.component';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BuildingRoutingModule,
    BuildingsPageComponent,
    BuildingCardComponent
  ]
})
export class BuildingModule { }
