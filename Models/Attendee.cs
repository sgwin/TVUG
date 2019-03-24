using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreMSSQL.Models
{
    public class Attendee
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName="nvarchar(250)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Location { get; set; }
    }
}
