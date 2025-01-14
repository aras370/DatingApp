import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MemberDTO } from '../UserDTO/MemberDTO';




@Injectable({
  providedIn: 'root'
})

export class MemberService {

  baseurl: string = 'https://localhost:44319/api/'

  constructor(private http: HttpClient) {

  }

  getmembers() {

    return this.http.get<MemberDTO[]>(this.baseurl + 'user')

  }

  getmember(username: string) {
    return this.http.get<MemberDTO>(this.baseurl + 'user/' + username)
    
  }

  edituserinformation(user: MemberDTO) {

    return this.http.put(this.baseurl+'User/EditUserProfoile',user);
 
   }

}
