import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCandyShopComponent } from './create-candy-shop.component';

describe('CreateCandyShopComponent', () => {
  let component: CreateCandyShopComponent;
  let fixture: ComponentFixture<CreateCandyShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCandyShopComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCandyShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
