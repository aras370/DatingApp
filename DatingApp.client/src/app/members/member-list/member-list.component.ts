import { Component, OnInit } from '@angular/core';
import { MemberService } from '../../services/member.service';
import { MemberDTO } from '../../UserDTO/MemberDTO';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css'
})
export class MemberListComponent implements OnInit {

  members: MemberDTO[]

  constructor(private memberService: MemberService) {

  }

  loadmembers() {

    this.memberService.getmembers().subscribe(members => {
      this.members = members
    })

  }

  ngOnInit(): void {
    this.loadmembers()
  }


}
