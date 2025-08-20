using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {

        private readonly MyProjectContext _context;
        public CommentRepository(MyProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetProductCommentShow(int ProductId)
        {
            return await _context.Comments.Where(c => c.ProductId == ProductId && c.IsApproved == true).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetSearchCommentForAdmin(string search = null, int ProductId = 0, int userId = 0, DateTime? time = null)
        {
            return await _context.Comments
                         .Where(i => (i.Commnet.Contains(search) || search == null) &&
                                      (i.ProductId == ProductId || ProductId == 0) &&
                                      (i.UserId == userId || userId == 0) &&
                                      (i.Created == time || time == null)).ToListAsync();
        }

        public async Task UpdateShowComment(int CommentId, bool IsApproved)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == CommentId);
            if (comment == null)
            {
                throw new NotImplementedException("کامنت یافت نشد");
            }

            comment.IsApproved = IsApproved;

            Update(comment);
        }
    }
}
