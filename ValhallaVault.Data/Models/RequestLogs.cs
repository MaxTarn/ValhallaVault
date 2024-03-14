using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaVault.Data.Models
{
    public class RequestLogs
    {
        [Key]
        public int Id { get; set; }    
        public string Method { get; set; }
        public string Path { get; set; }
        public int StatusCode { get; set; }
        public DateTime LogTime { get; set; }

    }
}
