import IMovie from './IMovie';

export default interface IHall {
  hallID: number;
  hallNumber: number;
  amountOfSeats: number;
  movie: IMovie;
}
