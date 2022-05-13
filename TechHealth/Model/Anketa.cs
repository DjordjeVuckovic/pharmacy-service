using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHealth.Model
{
    public class Rating
    {
        protected string id;
        protected DateTime date;
        protected string idPac;

        public string Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string IdUser { get => idPac; set => idPac = value; }

        public Rating()
        {
            date = DateTime.Now;
        }

        public Rating(string idpacijenta)
        {
            idPac = idpacijenta;
            date = DateTime.Now;
        }
    }
}
