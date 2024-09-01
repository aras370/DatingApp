import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUserlogin } from '../models/user.interface';
import { UserDTO } from '../UserDTO/UserDTO';
import { map, catchError } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AccountService {


  baseurl: string = 'https://localhost:44319/api'

  private currentUserSource = new ReplaySubject<UserDTO | null>()

  currentUser = this.currentUserSource.asObservable()

  constructor(private http: HttpClient) {

  }

  Login(user: any) {

    return this.http.post(`${this.baseurl}/Account/Login`, user).pipe(map(response => {

      var user = <UserDTO>response

      if (user != null) {
        localStorage.setItem('user', JSON.stringify(user))
      }
      this.currentUserSource.next(user)
    }))

  }

  Logout() {
    localStorage.removeItem('user')
    this.currentUserSource.next(null)
  }

  setCurrentUser(user: UserDTO) {
    this.currentUserSource.next(user)
  }

  Register(model: any) {
    return this.http.post(this.baseurl + '/Account/Register', model).pipe(map((result: any) => {
      console.log(result)
      if (result.isSuccess && result.data != undefined) {
        localStorage.setItem('user', JSON.stringify(result.data))
        this.currentUserSource.next(result.data)
      }
      return result
    }

    ))
  }

}
