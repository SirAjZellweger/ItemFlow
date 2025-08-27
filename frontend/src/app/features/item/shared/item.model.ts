interface ItemBase {
  readonly name: string;
  readonly description?: string;
}

export type CreateItem = ItemBase;
export type UpdateItem = ItemBase;

export interface Item extends ItemBase {
  readonly id: string;
}
