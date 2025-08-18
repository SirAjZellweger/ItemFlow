import { inject, Injectable, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Item, CreateItem } from './item.model';
import { ItemDataService } from './item.data.service';

@Injectable({ providedIn: 'root' })
export class ItemService {
  private readonly data = inject(ItemDataService);

  private readonly _items = signal<Item[]>([]);
  readonly items = this._items.asReadonly();

  createItem(item: CreateItem): Observable<Item> {
    return this.data.createItem(item).pipe(tap(newItem => this._items.update(items => [...items, newItem])));
  }

  getItems(): Observable<Item[]> {
    return this.data.getAllItems().pipe(tap(items => this._items.set(items)));
  }
}
