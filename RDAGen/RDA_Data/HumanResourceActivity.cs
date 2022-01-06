using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RDAGen.RDA_Data
{
    /// <summary>
    ///  Lista de RH Direto para o ListView
    /// </summary>
    public class DirectHRActivityList
    {
        public ObservableCollection<HumanResourceActivity> List { get; set; } = new ObservableCollection<HumanResourceActivity>();

        public void UpdateActivitiesListView(HumanResource hr)
        {
            var newList = hr.GetActivitiesList();

            this.List.Clear();
            foreach (var listItem in newList)
            {
                this.List.Add(listItem);
            }

            //Ordena a lista de atividades segundo o numero sequencial
            this.List.OrderBy(listItem => listItem.Name);
        }
    }

    /// <summary>
    /// Descreve a mão de obra direta/indireta
    /// </summary>
    public class HumanResourceActivity
    {
        //Talvez fosse melhor só guardar o string codificado ao inves de um objeto inteiro
        private RichTextBox m_description = new RichTextBox();//Descrição da atividade feita por um determinado RH

        public RichTextBox Description //Descrição da atividade feita por um determinado RH
        {
            get => m_description;

            set
            {
                string sAux = GetRtfStringFromRichTextBox(value);
                m_description.Document = GetRichTextBoxFromRtfString(sAux);
            }
        }          
        public string Name { get; set; }             //Nome da atividade (é o full name)
        public string ShortName { get; set; }        //Nome curso no padrão "Atividade [AT xx]"
        public Guid Id { get; set; }                 //Id da atividade
        public string DescriptionDummy { get; set; }

        public HumanResourceActivity()
        {
        }

        public HumanResourceActivity(Guid id, string name, string shortname, RichTextBox desc, string desc2="")
        {
            Id = id;
            Name = name;
            ShortName = shortname;

            Description = desc;
            DescriptionDummy = desc2;
        }

        //O ideal é ter essas duas transformações como serviço que fica disponivel e assim as classes model nao precisarão ter objetos RichTextBox
        //(o problema é que teriamos que criar uma classe especial para podermos saber que um string é RTF ou string comum, para nao misturar)
        private string GetRtfStringFromRichTextBox(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            MemoryStream ms = new MemoryStream();
            textRange.Save(ms, DataFormats.Rtf);

            return Encoding.Default.GetString(ms.ToArray());
        }

        private FlowDocument GetRichTextBoxFromRtfString(string richTextString)
        {
            FlowDocument fd = new FlowDocument();
            MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(richTextString));
            TextRange textRange = new TextRange(fd.ContentStart, fd.ContentEnd);
            textRange.Load(ms, DataFormats.Rtf);
            return fd;
        }
    }
}
