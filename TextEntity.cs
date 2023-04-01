using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public class TextEntity
    {
        public string type;
        public string text;
        public TextEntity(string type, string text)
        {
            this.type = type;
            this.text = text;
        }
    }
}
