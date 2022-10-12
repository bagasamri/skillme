using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Penilaian
    {
        [Key]
        public int ID { get; set; }
        public string Batch { get; set; }
        public string NIK { get; set; }
        public string Nama { get; set; }
        
        public int Nilai { get; set; }  
        public int? App { get; set; }

    }
}
