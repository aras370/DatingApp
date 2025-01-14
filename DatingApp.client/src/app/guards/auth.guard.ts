import { CanActivate, CanActivateFn } from '@angular/router';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private accountservice: AccountService, private toastr: ToastrService) {


  }

  canActivate(): Observable<boolean> {
    return this.accountservice.currentUser.pipe(map(user => {
      if (user)
        return true;
      else {
        this.toastr.error('ابتدا به سیستم وارد شوید')
        return false
      }
    }))
  }
}
