using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace RDAGen
{
    public class RDAParagraph : RDABaseText
    {
        private RDASection m_oParent = null;

        public RDAParagraph(DocX doc, RDASection oParent = null) : base(doc)
        {
            m_oParent = oParent;
        }

        public void AddText(string sText = "", bool bold = false, bool italic = false, bool underline = false)
        {
            sText = sText.TrimStart();
            string sTabs = "";
            sTabs = this.InsertTab(sTabs);

            this.Add(sTabs);
            this.Append(sText, bold, italic, underline);
        }

        public void AddText(string sText = "")
        {
            sText = sText.TrimStart();
            string sTabs = "";
            sTabs = this.InsertTab(sTabs);

            this.Add(sTabs);
            this.Append(sText, false, false, false);
        }

        public void AppendText(string sText = "", bool bold = false, bool italic = false, bool underline = false)
        {
            this.Append(sText, bold, italic, underline);
        }

        public string InsertTab(string sText)
        {
            if (this.m_oParent != null)
            {
                sText = sText.Insert(0, "\t");
                m_oParent.InsertTab(sText);
            }

            return sText;
        }
    }
}
