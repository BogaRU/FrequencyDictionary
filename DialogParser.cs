using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    internal class DialogParser
    {
        public static void ParseDialog (string path)
        {
            string[] lines = File.ReadAllLines(path);
            StringBuilder text = new StringBuilder("");
            foreach (string line in lines)
            {
                try
                {
                    if (line.Length < 2) continue;
                    text.Append(" " + line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            File.WriteAllText("parsedDialog.txt", text.ToString());
        }
    }
}
