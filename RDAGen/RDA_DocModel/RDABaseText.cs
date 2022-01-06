using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace RDAGen
{
    public class RDABaseText
    {
        private DocX m_oDoc;
        private Formatting m_oFormat;
        Xceed.Document.NET.Paragraph m_oParagraph;

        public RDABaseText(DocX doc)
        {
            m_oDoc = doc;

            //Formatting Title  
            m_oFormat = new Formatting();

            //Specify font family  
            m_oFormat.FontFamily = new Xceed.Document.NET.Font("Arial");
            
            //Specify font size  
            m_oFormat.Size = 11;
        }

        private void FormatText(bool bold = false, bool italic = false, bool underline = false)
        {
            if (bold)
                m_oParagraph.Bold();

            if (italic)
                m_oParagraph.Italic();

            if (underline)
                m_oParagraph.UnderlineColor(Color.Black);
        }

        public void Append(string sText = "", bool bold = false, bool italic = false, bool underline = false)
        {
            m_oParagraph = m_oParagraph ?? m_oDoc.InsertParagraph(sText, false, m_oFormat);

            m_oParagraph = m_oParagraph.Append(sText);
            FormatText(bold, italic, underline);
        }

        public virtual void Add(string sText = "", bool bold=false, bool italic=false, bool underline=false)
        {
            //Insert Paragraph
            m_oParagraph = m_oDoc.InsertParagraph(sText, false, m_oFormat);

            m_oParagraph.Alignment = Alignment.both;
            m_oParagraph.LineSpacingAfter = 12;
            m_oParagraph.LineSpacingBefore = 12;
            m_oParagraph.LineSpacing *= 1.5F; //A unidade LineSpacing está em pixels, tem que multiplicar por 1,5 para obter o valor (1,5) que o Word usa corretamente

            FormatText(bold, italic, underline);
        }
    }
}
