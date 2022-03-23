using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCarregamento.Modelo
{
    public class ListTimeSheets
    {
        public string DataExame { get; set; }

        private string _linha;

        public string Linha
        {
            get { return _linha; }
            set { _linha = value; }
        }

        private decimal _teamId;

        public decimal TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        private decimal _groupId;

        public decimal GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        private string _matricula;

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _funcao;

        public string Funcao
        {
            get { return _funcao; }
            set { _funcao = value; }
        }

        private string _statusFDM;
        public string StatusFDM
        {
            get { return _statusFDM; }
            set { _statusFDM = value; }
        }
    }
}
