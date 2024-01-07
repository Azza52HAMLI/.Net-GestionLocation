using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metiers
{
    public class Bus
    {
        private string immat, marque;
        private DateTime dateachat;
        int capacite;
        decimal prixachat, prixjour;

        public Bus(string immat, string marque, DateTime dateachat, int capacite, decimal prixachat, decimal prixjour)
        {
            this.immat = immat;
            this.marque = marque;
            this.dateachat = dateachat;
            this.capacite = capacite;
            this.prixachat = prixachat;
            this.prixjour = prixjour;
        }

        public string Immat { get => immat; set => immat = value; }
        public string Marque { get => marque; set => marque = value; }
        public DateTime Dateachat { get => dateachat; set => dateachat = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public decimal Prixachat { get => prixachat; set => prixachat = value; }
        public decimal Prixjour { get => prixjour; set => prixjour = value; }

        public override bool Equals(object obj)
        {
            return obj is Bus bus &&
                   immat == bus.immat ;
        }
    }
}
