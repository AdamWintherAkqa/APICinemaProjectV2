import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import ICandyShop from 'src/app/interface/ICandyShop';
import { CandyShopService } from 'src/app/services/candy-shop.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-edit-candy-shop',
  templateUrl: './edit-candy-shop.component.html',
  styleUrls: ['./edit-candy-shop.component.css'],
})
export class EditCandyShopComponent implements OnInit {
  constructor(
    private candyShopService: CandyShopService,
    private dataService: DataService
  ) {}

  candyShop: ICandyShop;

  ngOnInit(): void {
    this.candyShop = this.dataService.choosenCandyShop;
    //console.log('candyShop: ', this.candyShop);
  }

  editCandyShopForm = new FormGroup({
    candyShopName: new FormControl(
      this.dataService.choosenCandyShop.candyShopName
    ),
    candyShopImageURL: new FormControl(
      this.dataService.choosenCandyShop.candyShopImageURL
    ),
    candyShopPrice: new FormControl(
      this.dataService.choosenCandyShop.candyShopPrice
    ),
    candyShopType: new FormControl(
      this.dataService.choosenCandyShop.candyShopType
    ),
  });

  editCandyShop() {
    this.candyShop = this.editCandyShopForm.value;
    this.candyShop.candyShopID = this.dataService.choosenCandyShop.candyShopID;
    console.log('candyShop: ', this.candyShop);
    this.candyShopService.putCandyShop(this.candyShop).subscribe((data) => {
      console.log('resp: ', data);
    });
  }
}
