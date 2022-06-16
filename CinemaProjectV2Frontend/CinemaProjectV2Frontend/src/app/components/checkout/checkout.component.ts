import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import IOrder from 'src/app/interface/IOrder';
import { CartserviceService } from 'src/app/services/cartservice.service';
import { CustomerService } from 'src/app/services/customer.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent implements OnInit {
  constructor(
    private cartService: CartserviceService,
    private orderService: OrderService,
    private customerService: CustomerService
  ) {}

  cart: IOrder;

  ngOnInit(): void {
    this.cart = this.cartService.getCart(); //Får kurven
  }

  postOrderForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  loginUser() {
    const email = this.postOrderForm.value.email; //Tager formen og lægger over i 2 nye variabler
    const password = this.postOrderForm.value.password;

    this.customerService
      .getCustomerByEmailAndPassword(email, password) //kalder en httpget controller som forventer både e-mail + password.
      .subscribe((data) => {
        console.log('data: ', data);
        console.log('cart: ', this.cart);
        this.cartService.addCustomerToOrder(data.customerID); //kalder addCustomerToOrder fra CartService
        this.orderService.postAndPutOrder(this.cart).subscribe((data) => {
          //Herefter post og putter order. Ordren oprettes tom uden FK, og derefter PUT med FKs.
          console.log('data: ', data);
        });
      });
  }
}
