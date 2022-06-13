import IMovie from './IMovie';

export default interface IGenre {
  genreID: number;
  genreName: string;
  movies: IMovie;


}
