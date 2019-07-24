using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ni.Models
{
    public class NiComment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(SenderId))]
        public NiUser Sender { get; set; }

        public int SenderId { get; set; }

        [ForeignKey(nameof(WebsiteId))]
        public NiWebsite Website { get; set; }

        public int WebsiteId { get; set; }

        [ForeignKey(nameof(ReplyParentId))]
        public NiComment ReplyParent { get; set; }

        public int? ReplyParentId { get; set; }

        public DateTimeOffset SendTime { get; set; }


    }
}
