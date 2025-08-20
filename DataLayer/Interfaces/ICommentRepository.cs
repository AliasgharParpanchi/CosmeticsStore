using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICommentRepository: IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetProductCommentShow(int ProductId);
        Task UpdateShowComment(int CommentId, bool IsApproved);
        Task<IEnumerable<Comment>> GetSearchCommentForAdmin(string search= null , int ProductId = 0 , int userId = 0, DateTime? time = null);
    }
}