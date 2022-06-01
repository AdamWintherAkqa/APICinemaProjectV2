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
  MovieID: number;
  MovieName: string;
  MoviePlayTime: number;
  MovieReleaseDate: Date;
  MovieAgeLimit: number;
  InstructorID: number;
  //Instructor: IInstructor;
  MovieIsChosen: boolean;
  MovieImageURL: string;
  //Genre: IGenre[];
  //Actors: IActor[];
}
