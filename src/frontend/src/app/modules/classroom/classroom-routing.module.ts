import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClassroomComponent } from './classroom.component';
import { ClassroomsPageComponent } from './pages/classrooms-page/classrooms-page.component';
import { AddClassroomPageComponent } from './pages/add-classroom-page/add-classroom-page.component';
import { ClassroomTypeManagementPageComponent } from './pages/classroom-type-management-page/classroom-type-management-page.component';

const routes: Routes = [{
  path: '',
  component: ClassroomComponent,
  children: [
    {path: 'all', component: ClassroomsPageComponent},
    {path: '', redirectTo: 'all', pathMatch:'full'},
    {path: 'new', component: AddClassroomPageComponent},
    {path: 'types-management', component: ClassroomTypeManagementPageComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClassroomRoutingModule { }
