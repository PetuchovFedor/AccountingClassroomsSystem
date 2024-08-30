import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    //{path: '', redirectTo: 'home', pathMatch: 'full' },
    {path: '', component: HomeComponent, pathMatch: 'full'},
    {
        path: 'building',
        loadChildren: () => import('./modules/building/building.module').then((m) => m.BuildingModule)
    },
    {
        path: 'classroom',
        loadChildren: () => import('./modules/classroom/classroom.module').then((m) => m.ClassroomModule)
    }
];
