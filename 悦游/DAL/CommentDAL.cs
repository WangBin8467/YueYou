using IDAL;
using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CommentDAL : BaseDAL<Comment>, ICommentDAL
    {
        public IQueryable<Comment> GetTop6()
        {
            var comments = dbContext.Set<Comment>().OrderByDescending(u => u.Contents_qulity).Skip(0).Take(6);
            return comments;
        }

        public IQueryable<Comment> GetGuideCommentByGuideId(int id)
        {
            var guidecomment = dbContext.Set<Comment>().Where(u => u.Guide_id == id).OrderByDescending(u => u.Comment_time);
            return guidecomment;
        }
    }
}
