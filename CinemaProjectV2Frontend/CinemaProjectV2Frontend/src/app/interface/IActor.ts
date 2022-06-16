import IMovie from "./IMovie";

export default interface IActor {
  actorID: number;
  actorName: string;
  movie: IMovie;
}
