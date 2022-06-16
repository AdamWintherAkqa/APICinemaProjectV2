import IOrder from './IOrder';

export default interface IMerchandise {
  merchandiseID: number;
  merchandiseType: string;
  merchandiseName: string;
  merchandiseColor: string;
  merchandisePrice: number;
  merchandiseSize: string;
  merchandiseStock: number;
  merchandiseDescription: string;
  order: IOrder[];
}
