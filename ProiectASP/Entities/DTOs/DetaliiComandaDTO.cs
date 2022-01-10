using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Entities.DTO
{
    public class DetaliiComandaDTO
    {
        public int IdComanda { get; set; }
        public Comenzi Comenzi { get; set; }

        public int IdProdus { get; set; }
        public Produse Produse { get; set; }

        public int IdProiectant { get; set; }
        public Angajati Angajati { get; set; }
        public int IdExecutant { get; set; }
        public string Status { get; set; }


        public DetaliiComandaDTO(DetaliiComanda detalii_comanda)
        {
            this.IdProdus = detalii_comanda.IdProdus;
            this.Produse = new Produse();
            this.IdProiectant = detalii_comanda.IdProiectant;
            this.Angajati = new Angajati();
            this.IdExecutant = detalii_comanda.IdExecutant;
            this.Status = detalii_comanda.Status;
        }
    }
}
