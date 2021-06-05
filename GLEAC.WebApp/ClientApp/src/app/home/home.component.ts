import { Component } from '@angular/core';

import { MENU_ITEMS } from './home-menu';

@Component({
  selector: 'ngx-home',
  styleUrls: ['home.component.scss'],
  template: `
    <ngx-one-column-layout>
      <nb-menu [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class HomeComponent {

  menu = MENU_ITEMS;
}
