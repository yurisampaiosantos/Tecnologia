using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCarregamento.Modelo
{
    public class ListActivities
    {
        private decimal _teamId;

        public decimal TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
    }
}
