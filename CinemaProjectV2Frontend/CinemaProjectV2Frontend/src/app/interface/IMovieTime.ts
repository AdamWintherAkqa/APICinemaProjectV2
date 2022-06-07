import IMovie from './IMovie';

export default interface IMovieTime {
  movieTimeID: number;
  time: Date;
  hallID: number;
  movie: IMovie;
}
