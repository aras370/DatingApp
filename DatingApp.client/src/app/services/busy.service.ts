import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {

  busyrequestcount = 0

  constructor(private spinner: NgxSpinnerService) {

  }

  busy() {
    this.busyrequestcount++;
    this.spinner.show(undefined, {
      type: 'line-scale-party',
      bdColor: 'rgba(255,255,255,0)',
      color: '#333333'
    })
  }

  free() {
    this.busyrequestcount--;
    if (this.busyrequestcount <= 0) {
      this.busyrequestcount = 0;
      this.spinner.hide();
    }
  }

}
