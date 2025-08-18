import { ChangeDetectionStrategy, Component, computed, inject, signal } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { CreateItem } from '../shared/item.model';
import { ItemService } from '../shared/item.domain.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-page-add-item',
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './page-add-item.component.html',
  styleUrl: './page-add-item.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PageAddItemComponent {
  private readonly itemService = inject(ItemService);

  public readonly name = signal('');
  public readonly description = signal<string | undefined>(undefined);

  public readonly isNameValid = computed(() => this.name().trim().length > 0);
  public readonly isFormValid = computed(() => this.isNameValid());

  public submit(): void {
    if (this.isFormValid()) {
      const item: CreateItem = {
        name: this.name(),
        description: this.description(),
      };

      this.itemService.createItem(item).pipe(take(1)).subscribe();
    }
  }
}
