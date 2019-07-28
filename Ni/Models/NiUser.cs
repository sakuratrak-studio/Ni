using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Aiursoft.Pylon.Models;

namespace Ni.Models
{
    public class NiUser : AiurUserBase
    {
        [InverseProperty(nameof(NiCommentWebsite.Owner))]
        public IEnumerable<NiCommentWebsite> CommentWebsites { get; set; }

        [InverseProperty(nameof(NiComment.Sender))]
        public IEnumerable<NiComment> Comments { get; set; }
    }
}
