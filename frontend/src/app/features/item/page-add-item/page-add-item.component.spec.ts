import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageAddItemComponent } from './page-add-item.component';

describe('PageAddItemComponent', () => {
  let component: PageAddItemComponent;
  let fixture: ComponentFixture<PageAddItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageAddItemComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(PageAddItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
