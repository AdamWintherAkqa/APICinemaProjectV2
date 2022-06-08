import IHall from './IHall';
import IOrder from './IOrder';

export default interface ISeat {
  seatID: number;
  hallID: number;
  hall: IHall;
  seatNumber: number;
  seatRowLetter: string;
  orders: IOrder[];
}
