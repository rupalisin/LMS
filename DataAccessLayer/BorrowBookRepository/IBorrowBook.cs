using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BorrowBookRepository
{
    public interface IBorrowBook
    {
        
            Task BorrowBookAsync(int Id, int bookId);
    }
}
