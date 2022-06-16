import { Component, OnInit } from '@angular/core';
import ICandyShop from 'src/app/interface/ICandyShop';
import IOrder from 'src/app/interface/IOrder';
import { CandyShopService } from 'src/app/services/candy-shop.service';
import { CartserviceService } from 'src/app/services/cartservice.service';

@Component({
  selector: 'app-candy-shop',
  templateUrl: './candy-shop.component.html',
  styleUrls: ['./candy-shop.component.css'],
})
export class CandyShopComponent implements OnInit {
  constructor(
    private candyShopService: CandyShopService,
    private cartService: CartserviceService
  ) {}
  candyShopList: ICandyShop[] = [];
  cart: IOrder;

  ngOnInit(): void {
    this.cart = this.cartService.getCart();
    this.candyShopService.getAllCandyShops().subscribe((data) => {
      console.log('data: ', data);
      this.candyShopList = data;
    });
  }

  addCandyToCart(candyShop: ICandyShop) {
    this.cartService.addCandyShopToOrder(candyShop);
    console.log(this.cartService.getCart());
  }
}
