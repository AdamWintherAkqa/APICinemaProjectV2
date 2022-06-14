import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandyShopComponent } from './candy-shop.component';

describe('CandyShopComponent', () => {
  let component: CandyShopComponent;
  let fixture: ComponentFixture<CandyShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CandyShopComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CandyShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
