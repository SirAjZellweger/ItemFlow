import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'items',
    pathMatch: 'full',
  },
  {
    path: 'items',
    loadChildren: () => import('./features').then(m => m.ITEM_ROUTES),
  },
];
