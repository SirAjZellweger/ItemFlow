import { ChangeDetectionStrategy, Component, inject, input } from '@angular/core';
import { FormItemComponent, ItemService, UpdateItem } from '../shared';
import { ReplaySubject, share, switchMap } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { toObservable } from '@angular/core/rxjs-interop';
import { AsyncPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-page-edit-item',
  imports: [AsyncPipe, FormItemComponent, MatButtonModule, MatToolbarModule, MatIconModule],
  templateUrl: './page-edit-item.component.html',
  styleUrl: './page-edit-item.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageEditItemComponent {
  private readonly itemService = inject(ItemService);
  private readonly router = inject(Router);
  private readonly snackBar = inject(MatSnackBar);
  private readonly route = inject(ActivatedRoute);

  public readonly id = input.required<string>();

  public readonly item$ = toObservable(this.id).pipe(
    switchMap(id => this.itemService.getItemById(id)),
    share({ connector: () => new ReplaySubject(1) }),
  );

  public submit(updateItem: UpdateItem): void {
    this.itemService.updateItem(this.id(), updateItem).subscribe({
      next: updatedItem => {
        this.router.navigate(['/items', updatedItem.id]);

        this.snackBar.open('Änderungen am Gegenstand erfolgreich gespeichert', undefined, { duration: 3000 });
      },
      error: () => this.snackBar.open('Fehler beim Speichern der Änderungen am Gegenstand', 'Schliessen'),
    });
  }

  public navigateBack(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }
}
