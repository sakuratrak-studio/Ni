﻿using System;
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

        public string SenderId { get; set; }

        [ForeignKey(nameof(CommentWebsiteId))]
        public NiCommentWebsite CommentWebsite { get; set; }

        public Guid CommentWebsiteId { get; set; }

        [ForeignKey(nameof(ReplyParentId))]
        public NiComment ReplyParent { get; set; }

        public int? ReplyParentId { get; set; }

        public DateTimeOffset SendTime { get; set; }


    }
}
