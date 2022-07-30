using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Repositorio.Base
{
    public abstract class BaseRepositorio
    {
        protected ConnectionFactory _connectionFactory;

        public BaseRepositorio()
        {
            _connectionFactory = new ConnectionFactory();
        }
    }
}
