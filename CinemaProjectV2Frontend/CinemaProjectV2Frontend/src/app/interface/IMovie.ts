import IActor from './IActor';
import IGenre from './IGenre';
import IInstructor from './IInstructor';

/*public int MovieID { get; set; } // PK
public string MovieName { get; set; }
public int MoviePlayTime { get; set; }
public DateTime MovieReleaseDate { get; set; }
public int MovieAgeLimit { get; set; }
public int InstructorID { get; set; } // FK
public Instructor Instructor { get; set; }
public bool MovieIsChosen { get; set; }
public string MovieImageURL { get; set; }
public virtual ICollection<Genre> Genre { get; set; }
public virtual ICollection<Actor> Actors { get; set; }
*/
export default interface IMovie {
  movieID: number;
  movieName: string;
  moviePlayTime: number;
  movieReleaseDate: Date;
  // movieDescription: string;
  movieAgeLimit: number;
  instructorID: number;
  instructor?: IInstructor;
  movieIsChosen: boolean;
  movieImageURL: string;
  genre: IGenre;
  actors: IActor;
}
