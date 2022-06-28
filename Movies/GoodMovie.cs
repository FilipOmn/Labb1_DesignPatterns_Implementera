using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Movies
{
    class GoodMovie : IMovie
    {
        public string GetTitle()
        {
            return "AGoodMovie";
        }
    }
}
