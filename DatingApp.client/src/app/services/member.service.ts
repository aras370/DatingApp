import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MemberDTO } from '../UserDTO/MemberDTO';


const httpoptions={
  headers:new HttpHeaders({
    Authorization:'Bearer'+JSON.parse(localStorage.getItem('user')||'').token
  })
}

@Injectable({
  providedIn: 'root'
})
export class MemberService {

baseurl: string = 'https://localhost:44319/api/'

  constructor(private http:HttpClient) { 

  }

getmembers(){

  return this.http.get<MemberDTO[]>(this.baseurl+'users',httpoptions)

}

getmember(username:string){
return this.http.get<MemberDTO>(this.baseurl+'users/'+username,httpoptions)
}

}
