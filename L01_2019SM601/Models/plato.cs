using System.ComponentModel.DataAnnotations;

namespace L01_2019SM601.Models
{
    public class plato
    {
        [Key]
        public int platoId { get; set; }
        public string nombrePlato { get; set; }
        public double precio { get; set; }
    }
}
