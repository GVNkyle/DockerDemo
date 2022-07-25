import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, RouterEvent, NavigationStart, NavigationCancel, NavigationError } from '@angular/router';

import { IconSetService } from '@coreui/icons-angular';
import { iconSubset } from './icons/icon-subset';
import { Title } from '@angular/platform-browser';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body',
  template: `<router-outlet></router-outlet>
             <ngx-spinner bdColor="rgba(0, 0, 0, 0.8)" template="<img style='width: 96px; height: 96px' src='../assets/img/spinner.gif' />" type="ball-scale-multiple" [fullScreen]="true">
</ngx-spinner>`,
})
export class AppComponent implements OnInit {
  title = 'CoreUI Free Angular Admin Template';

  constructor(
    private router: Router,
    private titleService: Title,
    private iconSetService: IconSetService,
    private spinnerService: NgxSpinnerService
  ) {
    titleService.setTitle(this.title);
    // iconSet singleton
    iconSetService.icons = { ...iconSubset };
  }

  ngOnInit(): void {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
    });
  }

  navigationInterceptor(e: RouterEvent) {
    if (e instanceof NavigationStart) {
      this.spinnerService.show();
    }

    if (e instanceof NavigationEnd || e instanceof NavigationCancel || e instanceof NavigationError) {
      this.spinnerService.hide();
    }
  }
}
