using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using YueYou.Model;

namespace DAL
{
   public partial class ReplyDAL : BaseDAL<Reply>, IReplyDAL
    {
        public IQueryable<Reply> GetReplyByCommentId(int id)
        {
            var commentreply = dbContext.Set<Reply>().Where(u => u.Comment_id == id).OrderByDescending(u => u.Reply_time);
            return commentreply;
        }
    }
}
