import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item, CreateItem } from './item.model';

@Injectable({ providedIn: 'root' })
export class ItemDataService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = '/api/items';

  createItem(item: CreateItem): Observable<Item> {
    return this.http.post<Item>(this.baseUrl, item);
  }

  getAllItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.baseUrl);
  }
}
