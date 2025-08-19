import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { ItemService } from '../shared/item.domain.service';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-page-items',
  imports: [RouterLink, JsonPipe, MatButtonModule, MatIconModule],
  templateUrl: './page-items.component.html',
  styleUrl: './page-items.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageItemsComponent {
  private readonly itemService = inject(ItemService);

  public readonly items = this.itemService.items;

  constructor() {
    this.itemService.init();
  }
}
