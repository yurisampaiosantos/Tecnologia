using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCarregamento.Modelo
{
    public class ListTimeSheetsActivities
    {
        private decimal _teamId;

        public decimal TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
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
        private string _barcode;

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        private string _activities;

        public string Activities
        {
            get { return _activities; }
            set { _activities = value; }
        }
    }
}
