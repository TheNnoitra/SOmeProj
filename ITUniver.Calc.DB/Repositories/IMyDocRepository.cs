using ITUniver.Calc.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITUniver.Calc.DB.Repositories
{
    public interface IMyDocRepository : IBaseRepository<Doc>
    {
        /// <summary>
        /// Проверить наличие пользователя с таким паролем
        /// </summary>
        /// <param name="login">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        bool Check(string login, string password);
    }
}
