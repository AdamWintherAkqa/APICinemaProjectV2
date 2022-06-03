import IMovie from './IMovie';

export default interface IMovieTime {
  movieTimeID: number;
  movieTimeDate: Date;
  hallID: number;
  movie: IMovie;
}
