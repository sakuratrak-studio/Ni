using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ni.Models
{
    public class NiCommentWebsite
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        [ForeignKey(nameof(OwnerId))]
        public NiUser Owner { get; set; }
        public string OwnerId { get; set; }

        public string AllowOrigin { get; set; }

        public DateTimeOffset CreateTime { get; set; }


        [InverseProperty(nameof(NiComment.CommentWebsite))]
        public IEnumerable<NiComment> Comments { get; set; }


    }
}
