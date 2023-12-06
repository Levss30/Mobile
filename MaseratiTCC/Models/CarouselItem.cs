using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaseratiTCC.Models
{
     public class CarouselItem
    {
        public string EstrelaSource { get; set; }
        public double Avaliacao { get; set; }
        public List<bool> Estrelas => Enumerable.Range(1, 5).Select(i => i <= Avaliacao).ToList();
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Type DestinationPage { get; set; }
    }
}
