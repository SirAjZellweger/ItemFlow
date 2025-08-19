import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item, CreateItem } from './item.model';
import { ENVIRONMENT } from '@core';

@Injectable({ providedIn: 'root' })
export class ItemDataService {
  private readonly http = inject(HttpClient);
  private readonly environment = inject(ENVIRONMENT);
  private readonly baseUrl = `${this.environment.apiUrl}/items`;

  public createItem(item: CreateItem): Observable<Item> {
    return this.http.post<Item>(this.baseUrl, item);
  }

  public getAllItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.baseUrl);
  }
}
