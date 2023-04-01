using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public class Telegram
    {
        public object about;
        public Chat chats;
        public Telegram(object about, Chat chats)
        {
            this.about = about;
            this.chats = chats;
        }
    }
}
