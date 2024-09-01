import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  registermode: boolean = false

  toggleRegisterMode() {
    this.registermode = !this.registermode
  }


  cancelregistermode(event: boolean) {
    this.registermode = event 
  }

}
