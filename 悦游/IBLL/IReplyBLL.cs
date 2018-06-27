﻿using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IReplyBLL:IBaseBLL<Reply>
    {
        IQueryable<Reply> GetReplyByCommentId(int id);
    }
}
