import { Component } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import {KENDO_BUTTON} from '@progress/kendo-angular-buttons'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, KENDO_BUTTON],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  clickOnMainButton() {
    this.router.navigate(['/'])
  }
  constructor(private router: Router)
  {

  }
  title = 'frontend';

  clickOnBuildingButton() {
    this.router.navigate(['/building'])
  }

  clickOnClassroomButton() {
    this.router.navigate(['/classroom'])
  }

}
