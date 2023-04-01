using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public class Message
    {
        public int id;
        public string type;
        public DateTime date;
        public string date_unixtime;
        public string from;
        public string from_id;
        public object text;
        public TextEntity[] text_entities;
        public Message(int id, string type, DateTime date, string date_unixtime, string from, string from_id, object text, TextEntity[] text_entities)
        {
            this.id = id;
            this.type = type;
            this.date = date;
            this.date_unixtime = date_unixtime;
            this.from = from;
            this.from_id = from_id;
            this.text = text;
            this.text_entities = text_entities;
        }
    }
}
