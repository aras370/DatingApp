import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { AccountService } from '../services/account.service';
import { UserDTO } from '../UserDTO/UserDTO';



@Injectable()

export class JwtInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    var currentuser: UserDTO

    this.accountservice.currentUser.pipe(take(1)).subscribe(user => currentuser = user)

    if (currentuser) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${currentuser.token}`
        }
      })
    }
    return next.handle(req)
  }

  constructor(private accountservice: AccountService) {

  }

}
