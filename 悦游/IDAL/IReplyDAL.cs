﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface  IReplyDAL:IBaseDAL<Reply>
    {
        IQueryable<Reply> GetReplyByCommentId(int id);
    }
}
