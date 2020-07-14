using System;
using System.Collections.Generic;
using System.Linq;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Data
{
    public class MovieRepository
    {
        private readonly BookingTicketsContext _context;
        public MovieRepository(BookingTicketsContext context){
            this._context = context;
        }   

        public IEnumerable<Movie> GetMovies()
        {
            return this._context.Movies.ToList();
        }

        public Movie GetMovieById(int movieId){
            return this._context.Movies.FirstOrDefault(m => m.Id == movieId);
        }

        public void InsertMovie(Movie movie){
            if(movie == null){
                throw new ArgumentNullException(nameof(movie));
            }
            this._context.Movies.Add(movie);
        }

        public void DeleteMovie(Movie movie){
            if(movie == null){
                throw new ArgumentNullException(nameof(movie));
            }
            this._context.Movies.Remove(movie);
        }

        public void UpdateMovie(Movie movie){
            //this._context.Entry(movie).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }
    }
}