import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { ItemService } from '../shared/item.domain.service';
import { switchMap, take, tap } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CreateItem, FormItemComponent } from '../shared';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-page-add-item',
  imports: [FormItemComponent, MatButtonModule, MatToolbarModule, MatIconModule],
  templateUrl: './page-add-item.component.html',
  styleUrl: './page-add-item.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageAddItemComponent {
  private readonly itemService = inject(ItemService);
  private readonly router = inject(Router);
  private readonly snackBar = inject(MatSnackBar);
  private readonly route = inject(ActivatedRoute);

  public submit(createItem: CreateItem): void {
    this.itemService
      .createItem(createItem)
      .pipe(
        tap(createdItem => this.router.navigate(['/items', createdItem.id])),
        switchMap(() =>
          this.snackBar
            .open('Gegenstand erfolgreich erstellt', 'Zurück zur Übersicht', { duration: 3000 })
            .onAction()
            .pipe(tap(() => this.router.navigate(['/items']))),
        ),
        take(1),
      )
      .subscribe({
        error: () => this.snackBar.open('Fehler beim Erstellen des Gegenstands', 'Schliessen'),
      });
  }

  public navigateBack(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }
}
