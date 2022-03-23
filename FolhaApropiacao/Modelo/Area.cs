using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCarregamento.Modelo
{
    public class Area
    {
        private decimal _id;

        public decimal Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}
