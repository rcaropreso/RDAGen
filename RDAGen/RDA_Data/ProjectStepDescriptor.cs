using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    /// <summary>
    ///  Lista de Etapas para o ListView
    /// </summary>
    public class ProjectStepList
    {
        public ObservableCollection<ProjectStepDescriptor> List { get; set; } = new ObservableCollection<ProjectStepDescriptor>();

        public void AddProjectStep(ProjectStepDescriptor item)
        {
            item.Index = List.Count + 1;
            List.Add(item);
            UpdateOrder();
        }

        public void InsertProjectStep(ProjectStepDescriptor item)
        {
            List.Add(item);
            UpdateOrder();
        }

        public void UpdateOrder()
        {
            List.OrderBy(item => item.Id);
        }

        public List<ProjectActivityDescriptor> GetFullActivitiesList()
        {
            List<ProjectActivityDescriptor> fullList = new List<ProjectActivityDescriptor>();
            foreach (var item in List)
            {
                var stepList = item.GetActivitiesList(); //atividades de uma etapa

                fullList.AddRange(stepList);
            }

            return fullList;
        }

        public int GetGlobalActivityIndex()
        {
            return GetFullActivitiesList().Count;
        }
    }

    /// <summary>
    /// Descritor de uma ETAPA do projeto
    /// </summary>
    public class ProjectStepDescriptor
    {
        public Guid Id { get => m_Id; }          //identificador da ETAPA
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private Dictionary<Guid, ProjectActivityDescriptor> Activities;

        public int Index { get; set; } //Numero sequencial da etapa
        public Constants.ActivityStatus Status { get; set; } //Status da Etapa

        private Guid m_Id;
        //private DateTimeFormatInfo m_dtfi;

        public void UpdateDates()
        {
            //m_dtfi = CultureInfo.CreateSpecificCulture("pt-BR").DateTimeFormat;
            //m_dtfi.DateSeparator = "-";
            //m_dtfi.ShortDatePattern = @"dd/MM/yyyy";
            //m_dtfi.ShortDatePattern = @"dd/MM/yyyy";

            var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            StartDate = dt;
            EndDate = dt;

            foreach (var item in Activities)
            {
                var activity = item.Value;
                
                if(activity.StartDate <= StartDate)
                {
                    StartDate = activity.StartDate ?? dt;
                }

                if (activity.EndDate >= EndDate)
                {
                    EndDate = activity.EndDate ?? dt;
                }
            }
        }

        private void InitializeData()
        {
            /*
            var ii = new DateTime(2021, 03, 10);
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("pt-BR").DateTimeFormat;

            Console.WriteLine("Original Short Date Pattern:");
            Console.WriteLine("   {0}: {1}", dtfi.ShortDatePattern, ii.ToString("d", dtfi));
            */
            m_Id = Guid.NewGuid();
            Activities = new Dictionary<Guid, ProjectActivityDescriptor>();
            UpdateDates();
        }

        public ProjectStepDescriptor()
        {
            InitializeData();
        }

        public ProjectStepDescriptor(string name, string description)
        {
            Name = name;
            Description = description;

            InitializeData();
        }

        public ProjectStepDescriptor(Guid id, string name, string description, DateTime start, DateTime end,
            Dictionary<Guid, ProjectActivityDescriptor> activities, int index, Constants.ActivityStatus status)
        {
            m_Id = id;
            Name = name;
            Description = description;
            StartDate = start;
            EndDate = end;
            Activities = activities;
            Index = index;
            Status = status;
        }

        public void RegisterActivity(ProjectActivityDescriptor activity)
        {
            if (Activities.ContainsKey(activity.Id))
            {
                Activities[activity.Id] = activity; //update
            }
            else
            {
                activity.Index = Activities.Count + 1; //cria um indice para a atividade dentro da sua lista "pai"
                activity.StepIndex = this.Index;       //insere o indice da etapa para construção do nome completo da atividade
                Activities.Add(activity.Id, activity); //insert
            }

            UpdateDates();
        }

        public ProjectActivityDescriptor GetActivityById(Guid id)
        {
            ProjectActivityDescriptor value;
            Activities.TryGetValue(id, out value);
            return value;
        }

        public List<ProjectActivityDescriptor> GetActivitiesList()
        {
            return Activities.Values.ToList();
        }
    }
}
