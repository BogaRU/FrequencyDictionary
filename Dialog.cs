using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public class Dialog
    {
        public string name;
        public string type;
        public double id;
        public Message[] messages;
        public Dialog(string name, string type, double id, Message[] messages)
        {
            this.name = name;
            this.type = type;
            this.id = id;
            this.messages = messages;
        }
    }
}
