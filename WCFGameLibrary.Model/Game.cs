using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
