export interface CreateItem {
  readonly name: string;
  readonly description?: string;
}

export interface Item extends CreateItem {
  readonly id: string;
}
