using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.Calc.DB.NH.Repositories
{
    public class NHMyDocRepository : NHBaseRepository<Doc>, IMyDocRepository
    {
        public override IEnumerable<Doc> GetAll()
        {
            return base.GetAll();
        }
        public bool Check(string Author, string DocName)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<Doc>()
                .And(u => u.Author == Author
                && u.DocName == DocName)
                .RowCount() > 0;
        }

        public bool CheckSame(string DocName)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<Doc>()
                .And(u => u.DocName == DocName && 
                u.DocStatus != DocStatus.Deleted)
                .RowCount() > 0;
        }

        public Doc FindDoc(string DocName)
        {
            var session = Helper.GetCurrentSession();

            return session
                .QueryOver<Doc>()
                .And(u => u.DocName == DocName &&
                 u.DocStatus != DocStatus.Deleted)
                .List<Doc>()
                .FirstOrDefault();
        }

        public override void Delete(long id)
        {
            var doc = Find(id);
            if (doc != null)
            {
                doc.DocStatus = DocStatus.Deleted;
                Save(doc);
            }
        }
    }
}
