export default interface IOrder {
  orderID: number;
  orderDate: Date;
  movieTimeID: number;
  customerID: number;
  ageCheck: boolean;
  //Seats: ISeat[];
  //CandyShops: ICandyShop[];
  //Merchandise: IMerchandise[];
}
