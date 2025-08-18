import { Routes } from '@angular/router';
import { PageItemsComponent } from './page-items/page-items.component';
import { PageAddItemComponent } from './page-add-item/page-add-item.component';

export const ITEM_ROUTES: Routes = [
  {
    path: '',
    component: PageItemsComponent,
  },
  {
    path: 'new',
    component: PageAddItemComponent,
  },
];
