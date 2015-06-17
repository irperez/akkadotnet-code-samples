using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.DataLayer.Contexts
{
    public interface IPageContext
    {

        string Save(PageMetadata page);
        PageMetadata GetPageMetadata(string url);
        void Remove(PageMetadata page);
    }
}
