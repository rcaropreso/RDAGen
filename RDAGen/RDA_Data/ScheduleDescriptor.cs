using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    public class ProjectScheduleList
    {
        public ObservableCollection<ScheduleDescriptor> List { get; set; } = new ObservableCollection<ScheduleDescriptor>();

        public void BuildScheduleList(List<ProjectStepDescriptor> steps)
        {
            List.Clear();
            foreach (var step in steps)
            {
                List.Add(new ScheduleDescriptor("", "Etapa: " + step.Name, step.StartDate, step.EndDate));

                foreach (var activity in step.GetActivitiesList())
                {
                    List.Add(new ScheduleDescriptor(activity.GlobalIndex.ToString(),
                        "Atividade: " + activity.Name, activity.StartDate, activity.EndDate));
                }
            }
        }

    }

        /// <summary>
        /// Classe usada para criar o cronograma
        /// </summary>
    public class ScheduleDescriptor
    {
        public string Index { get; set; }       //identificador numerico da atividade
        public string Name { get; set; }        //nome de etapa/atividade
        public DateTime? StartDate { get; set; } //data de inicio da etapa/atividade
        public DateTime? EndDate { get; set; }   //data de termino da etapa/atividade

        public ScheduleDescriptor()
        {

        }

        public ScheduleDescriptor(string index, string name, DateTime? startDate, DateTime? endDate)
        {
            Index = index;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
