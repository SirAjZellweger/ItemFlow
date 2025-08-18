import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-page-items',
  imports: [RouterLink, MatButtonModule, MatIconModule],
  templateUrl: './page-items.component.html',
  styleUrl: './page-items.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageItemsComponent {}
