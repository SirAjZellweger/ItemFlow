import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageItemDetailComponent } from './page-item-detail.component';

describe('PageItemDetailComponent', () => {
  let component: PageItemDetailComponent;
  let fixture: ComponentFixture<PageItemDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageItemDetailComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(PageItemDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
