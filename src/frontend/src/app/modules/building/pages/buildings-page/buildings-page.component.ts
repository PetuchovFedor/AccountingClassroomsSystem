import { Component} from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { BuildingReadModel } from '../../models/building.model';
import { BuildingCardComponent } from '../../components/building-card/building-card.component';
import { KENDO_BUTTON } from '@progress/kendo-angular-buttons';
import { Router } from '@angular/router';
import { Observable} from 'rxjs';
import { BuildingService } from '../../services/building.service';


@Component({
  selector: 'buildings-page',
  standalone: true,
  imports: [BuildingCardComponent, KENDO_BUTTON, AsyncPipe],
  templateUrl: './buildings-page.component.html',
  styleUrl: './buildings-page.component.css',  
})
export class BuildingsPageComponent {  
  constructor(private router: Router, private buildingService: BuildingService) {       
    this.buildings$ = this.buildingService.data$
  }

  onClick() {
    this.router.navigate(['/building/new'])    
  }
  buildings$: Observable<BuildingReadModel[]>
}
