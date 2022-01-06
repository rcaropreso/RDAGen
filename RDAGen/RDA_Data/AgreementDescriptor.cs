using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    /// <summary>
    ///  Lista de convenios para o ListView
    /// </summary>
    public class AgreementList
    {
        public ObservableCollection<AgreementDescriptor> List { get; set; } = new ObservableCollection<AgreementDescriptor>();
    }

    /// <summary>
    /// Descritor de Convenio
    /// </summary>
    public class AgreementDescriptor
    {
        public string AgreementNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate{ get; set; }

        public AgreementDescriptor(string number, string start, string end)
        {
            AgreementNumber = number;
            StartDate = start;
            EndDate = end;
        }
    }
}
