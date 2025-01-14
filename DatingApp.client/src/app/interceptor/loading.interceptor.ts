import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, finalize, Observable } from 'rxjs';
import { BusyService } from '../services/busy.service';


@Injectable()


export class loadingInterceptor implements HttpInterceptor {


  constructor(private busyservice: BusyService) {

  }


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.busyservice.busy();

    return next.handle(req).pipe(
      delay(1000),
      finalize(() => {
        this.busyservice.free()
      })
    )

  }

}