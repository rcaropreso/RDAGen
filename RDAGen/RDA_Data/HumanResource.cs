using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    /// <summary>
    ///  Lista de RH para o ListView
    /// </summary>
    public class HumanResourceList
    {
        public ObservableCollection<HumanResource> List { get; set; } = new ObservableCollection<HumanResource>();
    }

    public class HumanResource
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string EducationLevel { get; set; } //escolaridade 
        public string Education { get; set; }      //formação

        public string ProjectRole { get; set; }    //função no projeto
        public float ProjectHours { get; set; }    // horas trabalhadas
        public DateTime StartDate { get; set; }    //período de atuação - inicio
        public DateTime EndDate { get; set; }      //período de atuação - fim
        public string Expenses { get; set; }       //total do dispendio        

        public Constants.HRType Type  { get; set; } //Indica se é direto ou indireto

        private Dictionary<Guid, HumanResourceActivity> HRActivities; //atuação no projeto, por atividade

        public HumanResource()
        {
            HRActivities = new Dictionary<Guid, HumanResourceActivity>();
        }

        public HumanResource(string name, string cpf, string educationlevel, string education, Constants.HRType type)
        {
            Name = name;
            CPF = cpf;
            EducationLevel = educationlevel;
            Education = education;
            Type = type;

            HRActivities = new Dictionary<Guid, HumanResourceActivity>();
        }

        public HumanResource(string name, string cpf, string educationlevel, string education, Constants.HRType type,
            string role, float hours, DateTime? start, DateTime? end, string expenses)
        {
            Name = name;
            CPF = cpf;
            EducationLevel = educationlevel;
            Education = education;
            Type = type;
            ProjectRole = role;
            ProjectHours = hours;
            StartDate = start ?? DateTime.Now;
            EndDate = end ?? DateTime.Now;
            Expenses = expenses;

            HRActivities = new Dictionary<Guid, HumanResourceActivity>();
        }

        public void RegisterActivity(Guid id, HumanResourceActivity activity)
        {
            if (HRActivities.ContainsKey(id))
            {
                HRActivities[id] = activity;
            }
            else
            {
                HRActivities.Add(id, activity);
            }
        }

        public HumanResourceActivity GetActivityById(Guid id)
        {
            HumanResourceActivity value;
            HRActivities.TryGetValue(id, out value);
            return value;
        }

        public void UnregisterActivity(Guid id)
        {
            HRActivities.Remove(id);
        }

        public void UnregisterAllActivities()
        {
            HRActivities.Clear();
        }

        public List<HumanResourceActivity> GetActivitiesList()
        {
            return HRActivities.Values.ToList();
        }
    }
}
