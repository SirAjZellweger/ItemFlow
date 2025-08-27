import { Routes } from '@angular/router';
import { PageItemsComponent } from './page-items/page-items.component';
import { PageAddItemComponent } from './page-add-item/page-add-item.component';
import { PageItemDetailComponent } from './page-item-detail/page-item-detail.component';
import { PageEditItemComponent } from './page-edit-item/page-edit-item.component';

export const ITEM_ROUTES: Routes = [
  {
    path: '',
    component: PageItemsComponent,
  },
  {
    path: 'new',
    component: PageAddItemComponent,
  },
  {
    path: ':id',
    component: PageItemDetailComponent,
  },
  {
    path: ':id/edit',
    component: PageEditItemComponent,
  },
];
