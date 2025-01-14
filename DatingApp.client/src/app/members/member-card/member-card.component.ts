import { Component, Input, OnInit } from '@angular/core';
import { MemberDTO } from '../../UserDTO/MemberDTO';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrl: './member-card.component.css'
})
export class MemberCardComponent implements OnInit {

ngOnInit(): void {
  
}

@Input() member:MemberDTO

}
