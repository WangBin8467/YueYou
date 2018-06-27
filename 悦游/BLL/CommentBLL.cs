using IBLL;
using IDAL;
using YueYou.Model;
using DALContainer;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class CommentBLL:BaseBLL<Comment>,ICommentBLL
    {
        private ICommentDAL CommentDAL = Container.Resolve<ICommentDAL>();
        public override void SetDal()
        {
            Dal = CommentDAL;
        }
        public IQueryable<Comment>GetTop6()
        {
            var comments = CommentDAL.GetTop6();
            return comments;
        }

        public IQueryable<Comment> GetGuideCommentByGuideId(int id)
        {
            var guidecomment = CommentDAL.GetGuideCommentByGuideId(id);
            return guidecomment;
        }


    }
}
