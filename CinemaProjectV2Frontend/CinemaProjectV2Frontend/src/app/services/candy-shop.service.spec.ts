import { TestBed } from '@angular/core/testing';

import { CandyShopService } from './candy-shop.service';

describe('CandyShopService', () => {
  let service: CandyShopService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CandyShopService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
