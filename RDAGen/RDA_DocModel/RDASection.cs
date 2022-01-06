using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace RDAGen
{
    public class RDASection : RDABaseText
    {
        private int m_iSectionNumber;
        private RDASection m_oParent = null;
        private Guid m_uuid;

        public RDASection(DocX doc, RDASection oParent=null) : base(doc)
        {
            m_uuid = Guid.NewGuid();
            m_iSectionNumber = ReferenceManager.GetSectionNumber(oParent?.GetUID());            
            m_oParent = oParent;
        }

        public string GetUID()
        {
            return m_uuid.ToString();
        }

        private string BuildSectionNumber()
        {
            string sText = "";

            if (this.m_oParent != null)
            {
                sText = sText.Insert(0, m_oParent.GetSectionNumber().ToString() + ".");
                m_oParent.BuildSectionNumber();
            }

            return sText + m_iSectionNumber.ToString();
        }

        public int GetSectionNumber()
        {
            return m_iSectionNumber;
        }

        public void AddText(string sText = "")
        {
            sText = sText.Trim();
            //sText = sText.Insert(0, m_iSectionNumber.ToString() + @" - ");
            sText = sText.Insert(0, BuildSectionNumber() + @" - ");

            string sTabs = "";            
            sTabs = this.InsertTab(sTabs);

            this.Add(sTabs);
            this.Append(sText, true);
        }

        public string InsertTab(string sText)
        {
            if(this.m_oParent != null)
            {
                sText = sText.Insert(0, "\t");
                m_oParent.InsertTab(sText);
            }

            return sText;
        }
    }
}
