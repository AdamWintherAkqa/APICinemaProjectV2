import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import ICandyShop from 'src/app/interface/ICandyShop';
import { CandyShopService } from 'src/app/services/candy-shop.service';

@Component({
  selector: 'app-create-candy-shop',
  templateUrl: './create-candy-shop.component.html',
  styleUrls: ['./create-candy-shop.component.css'],
})
export class CreateCandyShopComponent implements OnInit {
  candyShopList: ICandyShop[] = [];
  constructor(private candyShopService: CandyShopService) {}

  ngOnInit(): void {
    this.getAllCandyShops();
  }

  createCandyShopForm = new FormGroup({
    candyShopName: new FormControl(''),
    candyShopImageURL: new FormControl(''),
    candyShopPrice: new FormControl(''),
    candyShopType: new FormControl(''),
  });

  createCandyShop() {
    this.candyShopService
      .postCandyShop(this.createCandyShopForm.value)
      .subscribe((data) => {
        console.log('resp: ', data);
      });
    this.getAllCandyShops();
  }

  getAllCandyShops() {
    this.candyShopService.getAllCandyShops().subscribe((data) => {
      console.log('data: ', data);
      this.candyShopList = data;
    });
  }

  deleteCandyShop(candyShop: ICandyShop) {
    this.candyShopService
      .deleteCandyShop(candyShop.candyShopID)
      .subscribe((data) => {
        console.log('data: ', data);
        this.getAllCandyShops();
      });
  }
}
