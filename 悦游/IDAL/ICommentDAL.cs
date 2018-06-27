﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface ICommentDAL:IBaseDAL<Comment>
    {
        IQueryable<Comment> GetTop6();

        IQueryable<Comment> GetGuideCommentByGuideId(int id);
    }
}
