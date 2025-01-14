import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginDTO } from '../AccountDTO/LoginDTO';
import { IResponseResult } from '../ResponseResult/user.login';


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


  user: LoginDTO = { email: '', password: '' }

  islogin: boolean = false

  login() {
    this.accountservice.Login(this.user).subscribe(
      (data: IResponseResult) => {

        console.log('Login Response:', data);

        if (data.issuccess === true) {
          this.toastr.success('ورود شما با موفقیت انجام شد')
          this.route.navigateByUrl('/members');
          this.islogin = true;
        } else if (data.message === 'حساب کاربری شما فعال نمیباشد') {
          this.toastr.warning('حساب کاربری شما فعال نمی باشد')
          this.islogin = false;
        } else if (data.message === 'کاربری با مشخصات وارد شده یافت نشد') {
          this.toastr.error('کاربری با مشخصات وارد شده یافت نشد')
          this.islogin = false;
        }
      },
      error => {
        console.log(error);  // Log any unexpected errors
        this.toastr.error('در فرایند ورود خطایی رخ داد لطفا بعدا تلاش کنید')
      }
    );
  }



  Logout() {
    this.accountservice.Logout()
    this.route.navigateByUrl('/');
  }


}


