using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Movies
{
    //Factory klassen för filmer
    class MovieFactory
    {
        public static IMovie GetMovie(string movie)
        {
            IMovie Movie = null;

            if(movie == "AVeryBadMovie")
            {
                Movie = new BadMovie();
            }
            else if(movie == "AnOkayMovie")
            {
                Movie = new OkayMovie();
            }
            else if(movie == "AGoodMovie")
            {
                Movie = new GoodMovie();
            }

            return Movie;
        }
    }
}
