using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RDAGen.RDA_Data
{
    /// <summary>
    /// Lista somente as atividades no ano base, serve de lista-base para o listView
    /// </summary>
    public class BaseYearActivityList
    {
        public ObservableCollection<ProjectActivityDescriptor> List { get; set; } = new ObservableCollection<ProjectActivityDescriptor>();

        public void UpdateBaseYearActivitiesList(DateTime baseYear, List<ProjectStepDescriptor> projectSteps)
        {
            List.Clear();

            foreach (var step in projectSteps)
            {
                foreach (var activity in step.GetActivitiesList())
                {
                    if (activity.StartDate.Value.Year == baseYear.Year || //Começou no ano base
                        activity.EndDate.Value.Year == baseYear.Year ||   //Terminou no ano base
                        (activity.StartDate.Value.Year < baseYear.Year && activity.EndDate.Value.Year > baseYear.Year)) //Começou antes e terminou depois do ano base
                    {
                        List.Add(activity);
                    }
                }
            }
        }
    }

    /// <summary>
    ///  Lista de Atividades para o ListView
    /// </summary>
    public class ProjectActivityList
    {
        public ObservableCollection<ProjectActivityDescriptor> List { get; set; } = new ObservableCollection<ProjectActivityDescriptor>();

        public void UpdateActivitiesListView(ProjectStepDescriptor parentStep)
        {
            var newList = parentStep.GetActivitiesList();

            this.List.Clear();
            foreach (var listItem in newList)
            {
                this.List.Add(listItem);
            }

            //Ordena a lista de atividades segundo o numero sequencial
            this.List.OrderBy(listItem => listItem.Id);
        }
    }

    public class ProjectActivityDescriptor
    {
        public Guid StepId { get; set; }    //identificador da ETAPA (pai da atividade)
        public Guid Id { get => m_Id; }     //identificador da ATIVIDADE
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Index { get; set; }        //Numero sequencial da atividade dentro da Etapa pai
        public int GlobalIndex { get; set; }  //Numero sequencial global da atividade (considerando TODAS as atividades)
        public int StepIndex { get; set; }    //Numero sequencial da Etapa "pai"

        public RichTextBox BaseYearDescription { get; set; } //Descrição da atividade durante o ano base, é diferente da descrição feita no PT
        public RichTextBox BaseYearResults { get; set; } //Resultados obtidos pela atividade durante o ano base


        public string FullActivityName
        {
            get
            {
                return StepIndex.ToString() + "." +  Index.ToString() + 
                    " - " + "[AT" + GlobalIndex.ToString() + "]" + " " + Name;
            }
            //set { Name = value; }
        }

        public string ShortActivityName
        {
            get
            {
                return "Atividade [AT" + GlobalIndex.ToString() + "]";
            }
        }

        public Constants.ActivityStatus Status { get; set; } //Status da Atividade

        private Guid m_Id;


        private void InitializeData()
        {
            /*
            var ii = new DateTime(2021, 03, 10);
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("pt-BR").DateTimeFormat;

            Console.WriteLine("Original Short Date Pattern:");
            Console.WriteLine("   {0}: {1}", dtfi.ShortDatePattern, ii.ToString("d", dtfi));
            */

            m_Id = Guid.NewGuid();
        }

        public ProjectActivityDescriptor()
        {
            InitializeData();
        }

        public ProjectActivityDescriptor(Guid parentId, string name, string description, DateTime? start, DateTime? end)
        {
            StepId = parentId;
            Name = name;
            Description = description;
            StartDate = start;
            EndDate = end;

            InitializeData();
        }

        public ProjectActivityDescriptor(Guid id, Guid parentId, string name, string description, DateTime start, DateTime end,
            int index, int globalIndex, int stepIndex, Constants.ActivityStatus status)
        {
            m_Id = id;
            StepId = parentId;
            Name = name;
            Description = description;
            StartDate = start;
            EndDate = end;
            Index = index;
            GlobalIndex = globalIndex;
            StepIndex = stepIndex;
            Status = status;
        }
    }
}
