import { Component, EventEmitter, Output, output } from '@angular/core';
import { AccountService } from '../services/account.service';
import RegisterDTO from '../AccountDTO/RegisterDTO';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

constructor(private accountservice:AccountService){

}

model:RegisterDTO

  @Output() cancelregister = new EventEmitter()

  register() {

    console.log(this.model)

    this.accountservice.Register(this.model).subscribe(response=>{
      console.log(response)
      this.cancel()
    },error=>{
      console.log(error)
    })
  }

  cancel() {
    this.cancelregister.emit(false)
  }

}
