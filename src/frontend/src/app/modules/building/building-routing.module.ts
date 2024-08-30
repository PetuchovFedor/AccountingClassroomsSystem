import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuildingsPageComponent } from './pages/buildings-page/buildings-page.component';
import { AddBuildingPageComponent } from './pages/add-building-page/add-building-page.component';
import { BuildingComponent } from './building.component';

const routes: Routes = [
  {
    path: '',
    component: BuildingComponent,
    children: [
      {path: '', redirectTo: 'all', pathMatch:'full'},
      {path: 'new', component: AddBuildingPageComponent},
      {path: 'all', component: BuildingsPageComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingRoutingModule { }
