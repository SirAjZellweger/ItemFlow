import { ChangeDetectionStrategy, Component, inject, input } from '@angular/core';
import { ItemService } from '../shared/item.domain.service';
import { ReplaySubject, share, switchMap } from 'rxjs';
import { toObservable } from '@angular/core/rxjs-interop';
import { AsyncPipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-page-item-detail',
  imports: [
    AsyncPipe,
    RouterLink,
    MatCardModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatMenuModule,
  ],
  templateUrl: './page-item-detail.component.html',
  styleUrl: './page-item-detail.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageItemDetailComponent {
  private readonly itemService = inject(ItemService);
  private readonly snackBar = inject(MatSnackBar);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  public readonly id = input.required<string>();

  public readonly item$ = toObservable(this.id).pipe(
    switchMap(id => this.itemService.getItemById(id)),
    share({ connector: () => new ReplaySubject(1) }),
  );

  public deleteItem(): void {
    this.itemService.deleteItem(this.id()).subscribe({
      next: () => {
        this.router.navigate(['/items']);
        this.snackBar.open('Gegenstand erfolgreich gelöscht', undefined, { duration: 3000 });
      },
      error: () => this.snackBar.open('Fehler beim Löschen des Gegenstands', 'Schliessen'),
    });
  }

  public navigateBack(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }
}
