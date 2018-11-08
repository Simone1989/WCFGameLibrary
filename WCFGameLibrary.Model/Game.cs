using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFGameLibrary.Model
{
    [DataContract]
    public class Game
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
