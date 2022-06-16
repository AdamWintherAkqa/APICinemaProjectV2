import ICandyShop from './ICandyShop';
import ISeat from './ISeat';

export default interface IOrder {
  orderID: number;
  orderDate: Date;
  movieTimeID: number;
  customerID: number;
  ageCheck: boolean;
  seats: ISeat[];
  candyShops: ICandyShop[];
  //Merchandise: IMerchandise[];
}
