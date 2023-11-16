using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Ticket
    {
        private int tkt_TicketNro;
        private DateTime tkt_FechaHoraEnt;
        private DateTime tkt_FechaHoraSal;
        public int cli_ClienteDNI;
        private int tv_TVCodigo;
        private string tkt_Patente;
        private int sec_SectorCodigo;
        private double tkt_Duracion;
        public decimal tv_Tarifa;
        public decimal tkt_Total;

        public decimal Tkt_Total
        {
            get { return tkt_Total; }
            set { tkt_Total = value; }
        }

        public decimal Tv_Tarifa
        {
            get { return tv_Tarifa; }
            set { tv_Tarifa = value; }
        }

        public double Tkt_Duracion
        {
            get { return tkt_Duracion; }
            set { tkt_Duracion = value; }
        }

        public int Sec_SectorCodigo
        {
            get { return sec_SectorCodigo; }
            set { sec_SectorCodigo = value; }
        }

        public string Tkt_Patente
        {
            get { return tkt_Patente; }
            set { tkt_Patente = value; }
        }

        public int Tv_TVCodigo
        {
            get { return tv_TVCodigo; }
            set { tv_TVCodigo = value; }
        }

        public int Cli_ClienteDNI
        {
            get { return cli_ClienteDNI; }
            set { cli_ClienteDNI = value; }
        }

        public DateTime Tkt_FechaHoraSal
        {
            get { return tkt_FechaHoraSal; }
            set { tkt_FechaHoraSal = value; }
        }

        public DateTime Tkt_FechaHoraEnt
        {
            get { return tkt_FechaHoraEnt; }
            set { tkt_FechaHoraEnt = value; }
        }

        public int Tkt_TicketNro
        {
            get { return tkt_TicketNro; }
            set { tkt_TicketNro = value; }
        }
    }
}
