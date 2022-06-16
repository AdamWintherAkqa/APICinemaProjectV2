import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookMovieTimeComponent } from './book-movie-time.component';

describe('BookMovieTimeComponent', () => {
  let component: BookMovieTimeComponent;
  let fixture: ComponentFixture<BookMovieTimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookMovieTimeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookMovieTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
