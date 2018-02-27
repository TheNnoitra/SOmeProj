using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.Calc.DB.Models
{
    public class Doc : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string DocName { get; set; }

        public virtual string Author { get; set; }

        public virtual DateTime PubDate { get; set; }

        public virtual string DocType { get; set; }

        public virtual string DocPath { get; set; }

        public virtual DocStatus DocStatus { get; set; }
    }

    public enum DocStatus
    {
        Active = 1,
        Deleted = 0
    }
}

