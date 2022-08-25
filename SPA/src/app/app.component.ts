import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, RouterEvent, NavigationStart, NavigationCancel, NavigationError } from '@angular/router';
import { NgxNotiflixService } from './_core/services/ngx-notiflix.service';
import { IconSetService } from '@coreui/icons-angular';
import { iconSubset } from './icons/icon-subset';
import { Title } from '@angular/platform-browser';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body',
  template: `<router-outlet></router-outlet>`,
})
export class AppComponent implements OnInit {
  title = 'CoreUI Free Angular Admin Template';

  constructor(
    private router: Router,
    private titleService: Title,
    private iconSetService: IconSetService,
    private notiflixService: NgxNotiflixService
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

    //custom notiflix
    this.notiflixService.init({
      loadingSvgUrl: 'assets/img/loading.svg',
      loadingType: 'custom',
      okButton: 'Okie',
    });
  }

  navigationInterceptor(e: RouterEvent) {
    if (e instanceof NavigationStart) {
      this.notiflixService.showLoading();
    }

    if (e instanceof NavigationEnd || e instanceof NavigationCancel || e instanceof NavigationError) {
      this.notiflixService.hideLoading();
    }
  }
}
