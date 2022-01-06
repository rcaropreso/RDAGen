using RDAGen.RDA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.Views
{

    /// <summary>
    ///ATIVIDADE CONFORME ART. 24
    /// </summary>
    public class ActivityArt24
    {
        public string Name { get; set; }

        public ActivityArt24(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    ///ESTE PROJETO GEROU PROPRIEDADE INTELECTUAL?
    /// </summary>
    public class ProjectIP
    {
        public string Name { get; set; }

        public ProjectIP(string name)
        {
            Name = name;
        }
    }


    /// <summary>
    ///GRAU DE INOVAÇÃO: DESENVOLVIMENTO
    /// </summary>
    public class ProjectDevelopment
    {
        public string Name { get; set; }

        public ProjectDevelopment(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    ///GRAU DE INOVAÇÃO: ABRANGÊNCIA
    /// </summary>
    public class ProjectInovation
    {
        public string Name { get; set; }

        public ProjectInovation(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    ///PROJETO PARA CUMPRIR TROCA DE PPB POR P,D&I ?
    /// </summary>
    public class ProjectSubstitution
    {
        public string Name { get; set; }

        public ProjectSubstitution(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// UF
    /// </summary>
    public class BRState
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public BRState(string id, string name)
        {
            Id = id;
            Name = name;
            FullName = id + " - " + name;
        }
    }

    /// <summary>
    /// TIPO DE PROJETO
    /// </summary>
    public class ProjectType
    {
        public string Name { get; set; }

        public ProjectType(string name)
        {
            Name = name;
        }
    }


    public class RDASectionView
    {

        public AgreementList Agreements { get; set; }
        public ProjectIPList ProjectIPs { get; set; }
        public ProjectActivityList ProjectActivities { get; set; }
        public ProjectStepList ProjectSteps { get; set; }
        public HumanResourceList HumanResources { get; set; }
        public DirectHRActivityList DirectHRActivities { get; set; } //usado apenas no listview, nao use em nenhum local
        public ProjectScheduleList BaseYearSchedule { get; set; }//usado apenas no listview de cronograma, nao use em nenhum local

        public BaseYearActivityList BaseYearActivities { get; set; }
        public BaseYearExpensesList BaseYearExpenses { get; set; }


        public List<BRState> BRStates { get; set; } 
        public List<ProjectType> ProjectTypes { get; set; }
        public List<ProjectSubstitution> ProjectSubstitutions { get; set; }        

        public List<ProjectInovation> ProjectInovationList { get; set; }
        public List<ProjectDevelopment> ProjectDevelopmentList { get; set; }
        public List<ProjectIP> ProjectIPList { get; set; }
        public List<ActivityArt24> ActivityArt24List { get; set; }
        public List<ProjectActivityDescriptor> ProjectFullActivitiesList { get; set; }

        public bool ReachInstitution { get; set; }
        public bool ReachInCompany { get; set; }
        public bool ReachMarket { get; set; }
        public bool ReachExport { get; set; }
        public bool ReachOuterCompany { get; set; }
        public bool ReachImportReduction { get; set; }

        public Constants.HRType HumanResourceType { get; set; }

        public BaseYearHRInvestmentsDescriptor baseYearHRInvestments { get; set; }


        public RDASectionView()
        {
            //PRECISAMOS DEFINIR AQUI QUAIS LISTAS SAO TEMPORARIAS (volateis) E QUAIS FAZEM PARTE DO MODEL, tá misturado

            Agreements = new AgreementList();
            ProjectIPs = new ProjectIPList();
            ProjectSteps = new ProjectStepList();
            ProjectActivities = new ProjectActivityList();
            HumanResources = new HumanResourceList();
            DirectHRActivities = new DirectHRActivityList();
            BaseYearActivities = new BaseYearActivityList();
            BaseYearExpenses = new BaseYearExpensesList();
            BaseYearSchedule = new ProjectScheduleList();

            BRStates = new List<BRState>();
            ProjectTypes = new List<ProjectType>();
            ProjectSubstitutions = new List<ProjectSubstitution>();
            ProjectInovationList = new List<ProjectInovation>();
            ProjectDevelopmentList= new List<ProjectDevelopment>();
            ProjectIPList = new List<ProjectIP>();
            ActivityArt24List = new List<ActivityArt24>();
            ProjectFullActivitiesList = new List<ProjectActivityDescriptor>();

            baseYearHRInvestments = new BaseYearHRInvestmentsDescriptor();

            //{"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"};
            BRStates.Add(new BRState("AC", "Acre"));
            BRStates.Add(new BRState("AL", "Alagoas"));
            BRStates.Add(new BRState("AP", "Amapá"));
            BRStates.Add(new BRState("AM", "Amazonas"));
            BRStates.Add(new BRState("BA", "Bahia"));
            BRStates.Add(new BRState("CE", "Ceará"));
            BRStates.Add(new BRState("DF", "Distrito Federal"));
            BRStates.Add(new BRState("ES", "Espírito Santo"));
            BRStates.Add(new BRState("GO", "Goiás"));
            BRStates.Add(new BRState("MA", "Maranhão"));

            BRStates.Add(new BRState("MT", "Mato Grosso"));
            BRStates.Add(new BRState("MS", "Mato Grosso do Sul"));
            BRStates.Add(new BRState("MG", "Minas Gerais"));
            BRStates.Add(new BRState("PA", "Pará"));
            BRStates.Add(new BRState("PB", "Paraíba"));
            BRStates.Add(new BRState("PR", "Paraná"));
            BRStates.Add(new BRState("PE", "Pernambuco"));
            BRStates.Add(new BRState("PI", "Piauí"));
            BRStates.Add(new BRState("RJ", "Rio de Janeiro"));
            BRStates.Add(new BRState("RN", "Rio Grande do Norte"));

            BRStates.Add(new BRState("RS", "Rio Grande do Sul"));
            BRStates.Add(new BRState("RO", "Rondônia"));
            BRStates.Add(new BRState("RR", "Roraima"));          
            BRStates.Add(new BRState("SC", "Santa Catarina"));
            BRStates.Add(new BRState("SP", "São Paulo"));
            BRStates.Add(new BRState("SE", "Sergipe"));
            BRStates.Add(new BRState("TO", "Tocantins"));


            //TIPOS DE PROJETO
            ProjectTypes.Add(new ProjectType("Capacitação e Treinamento"));
            ProjectTypes.Add(new ProjectType("Componente Microeletrônico"));
            ProjectTypes.Add(new ProjectType("Dispositivos"));
            ProjectTypes.Add(new ProjectType("Ensaios e Testes"));
            ProjectTypes.Add(new ProjectType("Equipamento(Hardware)"));
            ProjectTypes.Add(new ProjectType("Estudos e Metodologias"));
            ProjectTypes.Add(new ProjectType("Hardware com software embarcado"));
            ProjectTypes.Add(new ProjectType("Integração de sistemas"));
            ProjectTypes.Add(new ProjectType("Intercâmbio científico"));
            ProjectTypes.Add(new ProjectType("Laboratório de P&D"));
            ProjectTypes.Add(new ProjectType("Metodologia"));
            ProjectTypes.Add(new ProjectType("Outros(especifique): "));
            ProjectTypes.Add(new ProjectType("Placa de Circuito"));
            ProjectTypes.Add(new ProjectType("Processo Produtivo"));
            ProjectTypes.Add(new ProjectType("Serviço Tecnológico"));
            ProjectTypes.Add(new ProjectType("Software, Aplicativo"));
            ProjectTypes.Add(new ProjectType("Software, Componente"));
            ProjectTypes.Add(new ProjectType("Software, Embarcado"));
            ProjectTypes.Add(new ProjectType("Software, Outro"));

            //Confirmação de Substituição 
            ProjectSubstitutions.Add(new ProjectSubstitution("Sim"));
            ProjectSubstitutions.Add(new ProjectSubstitution("Não"));

            //Grau de inovação/abrangencia
            ProjectInovationList.Add(new ProjectInovation("Novo para a empresa, mas existente no mercado nacional"));
            ProjectInovationList.Add(new ProjectInovation("Novo no mercado nacional, mas já existente no mercado mundial"));
            ProjectInovationList.Add(new ProjectInovation("Novo no mercado mundial"));

            //Grau de inovação/desenvolvimento
            ProjectDevelopmentList.Add(new ProjectDevelopment("Aprimoramento a partir de algo existente"));
            ProjectDevelopmentList.Add(new ProjectDevelopment("Desenvolvimento de algo novo"));

            //ESTE PROJETO GEROU PROPRIEDADE INTELECTUAL
            ProjectIPList.Add(new ProjectIP("Sim"));
            ProjectIPList.Add(new ProjectIP("Não"));

            //ATIVIDADE CONFORME ART. 24:
            ActivityArt24List.Add(new ActivityArt24("I"));
            ActivityArt24List.Add(new ActivityArt24("II"));
            ActivityArt24List.Add(new ActivityArt24("III"));
            ActivityArt24List.Add(new ActivityArt24("IV-A"));
            ActivityArt24List.Add(new ActivityArt24("IV-B"));
            ActivityArt24List.Add(new ActivityArt24("IV-C"));
            ActivityArt24List.Add(new ActivityArt24("§1º"));
        }
    }
}
