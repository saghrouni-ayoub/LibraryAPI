using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class BookForCreationWithAmountOfPages : BookForCreation
    {
        public int AmountOfPages { get; set; }
    }
}
