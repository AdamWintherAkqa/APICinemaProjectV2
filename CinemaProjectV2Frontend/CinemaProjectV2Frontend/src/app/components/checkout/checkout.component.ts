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
    this.cart = this.cartService.getCart();
  }

  postOrderForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  loginUser() {
    const email = this.postOrderForm.value.email;
    const password = this.postOrderForm.value.password;

    this.customerService
      .getCustomerByEmailAndPassword(email, password)
      .subscribe((data) => {
        console.log('data: ', data);
        console.log('cart: ', this.cart);
        this.cartService.addCustomerToOrder(data.customerID);
        this.orderService.postAndPutOrder(this.cart).subscribe((data) => {
          console.log('data: ', data);
        });
      });
  }
}
