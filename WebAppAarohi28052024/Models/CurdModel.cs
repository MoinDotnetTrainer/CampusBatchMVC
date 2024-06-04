using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebAppAarohi28052024.Models
{
    [Table("tbl_demodata")]
    public class CurdModel
    {
        [Key]  // pk
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // identity
        public int Id { get; set; }
        public string name { get; set; }
        public string EmailID { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public bool Status { get; set; }
    }
}
