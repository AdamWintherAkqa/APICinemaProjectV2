import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCandyShopComponent } from './edit-candy-shop.component';

describe('EditCandyShopComponent', () => {
  let component: EditCandyShopComponent;
  let fixture: ComponentFixture<EditCandyShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCandyShopComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCandyShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
