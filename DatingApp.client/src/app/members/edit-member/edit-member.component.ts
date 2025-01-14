import { AfterContentInit, AfterViewInit, Component, OnInit, ViewChild, viewChild } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { MemberService } from '../../services/member.service';
import { UserDTO } from '../../UserDTO/UserDTO';
import { MemberDTO } from '../../UserDTO/MemberDTO';
import { take } from 'rxjs';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-edit-member',
  templateUrl: './edit-member.component.html',
  styleUrl: './edit-member.component.css'
})
export class EditMemberComponent implements OnInit {

  @ViewChild('editform', { static: false }) editform: NgForm;


  user: UserDTO

  member: MemberDTO



  constructor(private toaster: ToastrService, private accountservice: AccountService, private memberservice: MemberService) {
    this.accountservice.currentUser.pipe(take(1)).subscribe(user => {
      this.user = user
    });
  }

  ngOnInit(): void {
    this.loadmember()
  }


  loadmember() {
    this.memberservice.getmember(this.user.userName).subscribe(response => {
      this.member = response;

    });
  }


  updatemember() {

    this.memberservice.edituserinformation(this.member).subscribe(() => {
      this.toaster.success('حساب کاربری شما با موفقیت ویرایش شد')
      this.editform.reset(this.member);
    }, error => {
      console.log(error)
      this.toaster.error('ویرایش اطلاعات انجام نشد,لطفا بعدا تلاش کنید')
    });
  }

}



