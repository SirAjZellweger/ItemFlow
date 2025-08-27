import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { ItemService } from '../shared/item.domain.service';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { Item } from '../shared/item.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-page-items',
  imports: [RouterLink, MatButtonModule, MatIconModule, MatListModule, MatCardModule, MatToolbarModule],
  templateUrl: './page-items.component.html',
  styleUrl: './page-items.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageItemsComponent {
  private readonly itemService = inject(ItemService);
  private readonly snackBar = inject(MatSnackBar);
  private readonly router = inject(Router);

  public readonly items = this.itemService.items;

  public deleteItem(item: Item, event: MouseEvent): void {
    event.stopPropagation();

    this.itemService.deleteItem(item.id).subscribe({
      next: () => this.snackBar.open('Gegenstand erfolgreich gelöscht', undefined, { duration: 3000 }),
      error: () => this.snackBar.open('Fehler beim Löschen des Gegenstands', 'Schliessen'),
    });
  }

  public editItem(item: Item, event: MouseEvent): void {
    event.stopPropagation();

    this.router.navigate(['/items', item.id, 'edit']);
  }
}
