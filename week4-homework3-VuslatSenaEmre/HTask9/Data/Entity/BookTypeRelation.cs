using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTask9.Data.Entity
{
    public class BookTypeRelation
    {
        public int BookTypeRelationId { get; set; }
        public int BookId { get; set; }
        public int BookTypeId { get; set; }
    }
}