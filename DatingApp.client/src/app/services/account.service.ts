import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUserlogin } from '../models/user.interface';
import { UserDTO } from '../UserDTO/UserDTO';
import { map, catchError } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';
import { LoginDTO } from '../AccountDTO/LoginDTO';
import { IResponseResult } from '../ResponseResult/user.login';



@Injectable({
  providedIn: 'root'
})
export class AccountService {


  baseurl: string = 'https://localhost:44319/api'

  private currentUserSource = new ReplaySubject<UserDTO | null>()

  currentUser = this.currentUserSource.asObservable()

  constructor(private http: HttpClient) {

  }

  Login(user: LoginDTO) {

    return this.http.post<IResponseResult>(`${this.baseurl}/Account/Login`, user).pipe(map(response => {
      console.log(response)
      if (response.issuccess) {

        var user = <UserDTO>response.data
        localStorage.setItem('user', JSON.stringify(user))
        this.currentUserSource.next(user)
      }
      return response

    }))

  }

  Logout() {
    localStorage.removeItem('user')
    this.currentUserSource.next(null)
  }

  setCurrentUser(user: UserDTO) {
    if (user != null && user.token != null && user.token != undefined && user.token != '') {
      this.currentUserSource.next(user)

    }
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
