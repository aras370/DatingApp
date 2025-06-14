import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessageComponent } from './message/message.component';
import { AuthGuard } from './guards/auth.guard';
import { EditMemberComponent } from './members/edit-member/edit-member.component';
import { preventUnsavesdChangesGuard } from './guards/prevent-unsavesd-changes.guard';

const routes: Routes = [{ path: '', component: HomeComponent },
{ path: 'members', component: MemberListComponent, canActivate: [AuthGuard] },
{ path: 'members/:username', component: MemberDetailComponent },
{ path: 'lists', component: ListsComponent },
{ path: 'messages', component: MessageComponent },
{ path: 'member/edit', component: EditMemberComponent,canDeactivate:[preventUnsavesdChangesGuard] },
{ path: '**', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
