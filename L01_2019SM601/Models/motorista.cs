using System.ComponentModel.DataAnnotations;

namespace L01_2019SM601.Models
{
    public class motorista
    {
        [Key]
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }
        

    }
}
