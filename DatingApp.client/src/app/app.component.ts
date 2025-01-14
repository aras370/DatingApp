import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserDTO } from './UserDTO/UserDTO';
import { AccountService } from './services/account.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient,private accountservice:AccountService) {
    
  }
 
  
  
  users: any
  
  ngOnInit(): void {
    this.getusers()
    this.setCurrentUser()
  }

  setCurrentUser(){
    var user:UserDTO=JSON.parse(localStorage.getItem('user')||"{}")
    this.accountservice.setCurrentUser(user)
  }

  getusers() {
    this.http.get("https://localhost:44319/api/User/GetAllUsers").subscribe(
      response => { this.users = response }
      , error => {
        console.log(error)
      })
  }

  title = 'Dating App';
}
