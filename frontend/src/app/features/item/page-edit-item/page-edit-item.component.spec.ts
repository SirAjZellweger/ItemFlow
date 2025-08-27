import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageEditItemComponent } from './page-edit-item.component';

describe('PageEditItemComponent', () => {
  let component: PageEditItemComponent;
  let fixture: ComponentFixture<PageEditItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageEditItemComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(PageEditItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
