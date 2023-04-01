using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public class Chat
    {
        public object about;
        public Dialog[] list;
        public Chat(object about, Dialog[] list)
        {
            this.about = about;
            this.list = list;
        }
    }
}
