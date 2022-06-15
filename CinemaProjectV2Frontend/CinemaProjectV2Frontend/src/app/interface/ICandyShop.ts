import IOrder from './IOrder';

export default interface ICandyShop {
  candyShopID: number;
  candyShopName: string;
  candyShopImageURL: string;
  candyShopPrice: number;
  candyShopType: string;
  orders: IOrder[];
}
