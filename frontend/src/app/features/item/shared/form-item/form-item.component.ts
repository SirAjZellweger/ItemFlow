import { ChangeDetectionStrategy, Component, computed, output, signal, input, effect } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CreateItem, Item, UpdateItem } from '../item.model';

@Component({
  selector: 'app-form-item',
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './form-item.component.html',
  styleUrl: './form-item.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormItemComponent {
  public readonly mode = input<'create' | 'edit'>('create');
  public readonly initialValue = input<Item | null>(null);

  public readonly name = signal('');
  public readonly description = signal<string | undefined>(undefined);

  public readonly isNameValid = computed(() => this.name().trim().length > 0);
  public readonly isFormValid = computed(() => this.isNameValid());

  public readonly submitted = output<CreateItem | UpdateItem>();

  constructor() {
    effect(() => {
      const value = this.initialValue();
      if (value && this.mode() === 'edit') {
        this.name.set(value.name);
        this.description.set(value.description);
      }
    });
  }

  public submit(): void {
    if (this.isFormValid()) {
      const item: CreateItem = {
        name: this.name(),
        description: this.description(),
      };

      const updateItem: UpdateItem = {
        name: this.name(),
        description: this.description(),
      };

      this.submitted.emit(this.mode() === 'create' ? item : updateItem);
    }
  }
}
