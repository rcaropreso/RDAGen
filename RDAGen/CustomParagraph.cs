using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Xceed.Words.NET;

namespace RDAGen
{
    public class CustomParagraph : RDABaseText
    {
        private List<TextStatement> m_vTexts;
        private RDASection m_oParent = null;

        public CustomParagraph(DocX doc, RDASection oParent = null) : base(doc)
        {
            m_vTexts = new List<TextStatement>();
            m_oParent = oParent;
        }

        private void ParseRitchTextBox(RichTextBox rtb)
        {
            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.

            //Quebrando um block em inlines e obtendo a forma~tação de cada pedaço
            //Pegar fonte, tamanho e os flags
            foreach (Block blk in rtb.Document.Blocks)
            {
                System.Windows.Documents.Paragraph p = blk as System.Windows.Documents.Paragraph;
                foreach (var item in p.Inlines)
                {
                    bool bNewLine = false;

                    //TextRange textRange2 = new TextRange(item.ContentStart, item.ContentEnd);
                    System.Windows.Documents.Run r = item as System.Windows.Documents.Run;

                    string sText = r.Text;
                    bool bIsItalic = r.FontStyle == FontStyles.Italic;
                    bool bIsBold = r.FontWeight == FontWeights.Bold;
                    bool bIsUnderline = false;

                    foreach (TextDecoration td in r.TextDecorations)
                    {
                        bIsUnderline = td.Location == TextDecorationLocation.Underline;
                    }


                    if (item == p.Inlines.FirstInline)
                    {
                        sText = sText.TrimStart();
                        //sText += "\n";
                        sText = this.InsertTab(sText);
                        bNewLine = true;
                    }

                    m_vTexts.Add(new TextStatement(sText, bIsItalic, bIsBold, bIsUnderline, bNewLine));
                }
            }
        }

        //private int GetRTBSize(RichTextBox rtb)
        //{
        //    return StringFromRichTextBox(rtb).Length;
        //}
        public void  Clear()
        {
            m_vTexts.Clear();
        }

        public void InsertParagraph(RichTextBox rtb)
        {
            this.Clear();
            this.ParseRitchTextBox(rtb);

            for (int i = 0; i < m_vTexts.Count; i++)
            {
                var item = m_vTexts.ElementAt(i);
                if (item.NewLine)
                {
                    Add(item.Text, item.Bold, item.Italic, item.Underline);
                }
                else
                {
                    Append(item.Text, item.Bold, item.Italic, item.Underline);
                }
            }
        }

        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            
            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        public string InsertTab(string sText)
        {
            if (this.m_oParent != null)
            {
                sText = sText.Insert(0, "\t");
                sText = m_oParent.InsertTab(sText);
            }

            return sText;
        }
    }
}
