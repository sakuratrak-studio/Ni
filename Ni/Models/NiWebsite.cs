using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ni.Models
{
    public class NiWebsite
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        [ForeignKey(nameof(OwnerId))]
        public NiUser Owner { get; set; }
        public int OwnerId { get; set; }

        public string AllowOrigin { get; set; }

        [InverseProperty(nameof(NiComment.Website))]
        public NiComment Comments;


    }
}
