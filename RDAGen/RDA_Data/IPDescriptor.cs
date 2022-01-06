using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    /// <summary>
    ///  Lista de de Propriedades Intelectuais para o ListView
    /// </summary>
    public class ProjectIPList
    {
        public ObservableCollection<ProjectIPDescriptor> List { get; set; } = new ObservableCollection<ProjectIPDescriptor>();
    }

    /// <summary>
    /// Descritor de Propriedade Intelectual vinculada ao projeto
    /// </summary>
    public class ProjectIPDescriptor
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string Register { get; set; }
        public string Date { get; set; }
        public string Local { get; set; }

        public ProjectIPDescriptor(string desc, string type, string register, string date, string local)
        {
            Description = desc;
            Type = type;
            Register = register;
            Date = date;
            Local = local;
        }
    }

}
