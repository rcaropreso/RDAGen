using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen
{
    class TextStatement
    {
        public string Text;
        public bool Italic;
        public bool Bold;
        public bool Underline;
        public bool NewLine;

        public TextStatement(string txt, bool italic, bool bold, bool underline, bool newline)
        {
            Text = txt;
            Italic = italic;
            Bold = bold;
            Underline = underline;
            NewLine = newline;
        }
    }
}
