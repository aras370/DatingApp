import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { IUserlogin } from '../models/user.interface';
import { Observable } from 'rxjs';
import { UserDTO } from '../UserDTO/UserDTO';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit {




  constructor(public accountservice: AccountService, private route: Router, private toastr: ToastrService) {

  }
  ngOnInit(): void {



  }


  user: any = {}

  islogin: boolean = true

  login() {
    this.accountservice.Login(this.user).subscribe(data => {
      this.route.navigateByUrl('/members')
      console.log(data)
      this.islogin = true
    }, error => {
      this.toastr.error(error.error)
    })
  }

  Logout() {
    this.accountservice.Logout()
    this.route.navigateByUrl('/');
  }


}


