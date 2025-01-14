import { CanActivateFn, CanDeactivate } from '@angular/router';
import { EditMemberComponent } from '../members/edit-member/edit-member.component';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})


export class preventUnsavesdChangesGuard implements CanDeactivate<unknown> {

  canDeactivate(component: EditMemberComponent) {

    //console.log(component.editform.dirty)

    if (component.editform?.dirty) {

      return confirm('تغییرات ذخیره نشده‌اند. آیا مطمئن هستید که می‌خواهید بدون ذخیره خارج شوید؟');
    }

    return true

  }
}







