import { inject, Injectable, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Item, CreateItem } from './item.model';
import { ItemDataService } from './item.data.service';

@Injectable({ providedIn: 'root' })
export class ItemService {
  private readonly data = inject(ItemDataService);

  private readonly _items = signal<Item[]>([]);
  readonly items = this._items.asReadonly();

  private initialized = false;

  public init(): void {
    if (!this.initialized) {
      this.getItems().subscribe();
      this.initialized = true;
    }
  }

  public createItem(item: CreateItem): Observable<Item> {
    return this.data.createItem(item).pipe(tap(newItem => this._items.update(items => [...items, newItem])));
  }

  private getItems(): Observable<Item[]> {
    return this.data.getAllItems().pipe(tap(items => this._items.set(items)));
  }
}
