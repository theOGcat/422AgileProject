/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BookStoreDATA;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace BookStoreLIB
{
    public class BookCatalog
    {
        public DataSet GetBookInfo()
        {
            //perform any business logic befor passing to client.
            // None needed at this time.
            var bookCatalog = new DALBookCatalog();
            return bookCatalog.GetBookInfo();
        }


    }
}
