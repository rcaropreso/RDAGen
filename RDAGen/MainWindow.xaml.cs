using RDAGen.RDA_Data;
using RDAGen.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace RDAGen
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private RDASectionView m_RDASectionView = new RDASectionView();
        //private List<BRState> BRStates = new List<BRState>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = m_RDASectionView;

            cbProjectIP.SelectedIndex = 1; //Default é "Não"
        }


        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            return textRange.Text;
        }


        private void btCreateDummy_Click(object sender, RoutedEventArgs e)
        {
            //TODO: para os itens que possuem lista hardcoded, precisamos de um campo no RDASEctionView para indicar o selecionado
            //TODO: RDASectionView não é view, é o model e deve ser renomeado para DataStruct

            //Preenche a estrutura de dados do RDA com dados dummy
            txtSecIdentification.Text = "PROJETO 1 - ID SIGPLANI: 1234"; //Precisa de campo no RDASectionView
            txtSecProjName.Text = "Projeto de Teste para Gerador de RDA";//Precisa de campo no RDASectionView
            txtSecRegion.Text = "BRASIL";//Precisa de campo no RDASectionView
            txtSecInstitution.Text = "FIT";//Precisa de campo no RDASectionView

            //CONVENIO
            //Trocar os campos de data para DateTime
            m_RDASectionView.Agreements.List.Add(new AgreementDescriptor("Primeiro Adendo ao Convênio FIT-XXXX 001/2013", "01/04/2013", "03/01/2023"));
            m_RDASectionView.Agreements.List.Add(new AgreementDescriptor("VIGÉSIMO PRIMEIRO TERMO ADITIVO AO CONVÊNIO DE COOPERAÇÃO TÉCNICA E CIENTÍFICA ENTRE FIT X yyyy Nº. 001/13", "02/01/2019", "31/12/2019"));
            m_RDASectionView.Agreements.List.Add(new AgreementDescriptor("VIGÉSIMO TERCEIRO TERMO ADITIVO AO CONVÊNIO DE COOPERAÇÃO TÉCNICA E CIENTÍFICA ENTRE FIT X yyyy Nº. 001/13", "02/01/2019", "31/12/2019"));

            //PERIODO DE EXECUÇÃO
            txtExecutionPeriod.Text = "02/01/2019 a 31/12/2020";   //Precisa de campo no RDASectionView e precisa trocar os campos de data para DateTime
            txtBaseYearExecution.Text = "02/01/2020 a 31/12/2020"; //Precisa de campo no RDASectionView e precisa trocar os campos de data para DateTime

            //UF
            cbBRStates.Text = new BRState("SP", "São Paulo").FullName;//Precisa de campo no RDASectionView

            //TIPO DE PROJETO
            cbProjectTypes.Text = new ProjectType("Software, Aplicativo").Name;//Precisa de campo no RDASectionView

            //SUBSTITUIÇÃO POR P&D
            cbProjectSubstitution.Text = new ProjectSubstitution("Sim").Name;//Precisa de campo no RDASectionView

            //RESPONSÁVEL PELO PROJETO
            txtAccountableName.Text = "RODRIGO DE TOLEDO CAROPRESO";//Precisa de campo no RDASectionView
            txtAccountableCPF.Text = "123.456.789-10";//Precisa de campo no RDASectionView
            txtAccountablePHONE.Text = "(55) 11 9999-8888";//Precisa de campo no RDASectionView
            txtAccountableEMAIL.Text = "caropreso@somewhere.com";//Precisa de campo no RDASectionView

            //ALCANCE DO PROJETO
            chkInstitution.IsChecked = true;//Precisa de campo no RDASectionView
            chkCompany.IsChecked = true;//Precisa de campo no RDASectionView
            chkMarket.IsChecked = true;//Precisa de campo no RDASectionView
            chkOuterCompany.IsChecked = true;//Precisa de campo no RDASectionView

            //GRAU DE INOVAÇÃO
            cbProjectInovation.Text = new ProjectInovation("Novo para a empresa, mas existente no mercado nacional").Name;//Precisa de campo no RDASectionView

            //DESENVOLVIMENTO
            cbProjectDevelopment.Text = new ProjectDevelopment("Desenvolvimento de algo novo").Name;//Precisa de campo no RDASectionView

            //PROPRIEDADE INTELECTUAL
            cbProjectIP.Text = new ProjectIP("Sim").Name;//Precisa de campo no RDASectionView

            //LISTA DE Propriedades Intelectuais
            m_RDASectionView.ProjectIPs.List.Add(new ProjectIPDescriptor("IDF-XXXX: A new method for yyyy", "Inovation", "05/06/2019 (aceita)", "18/08/2019 (pedido)", "EUA"));


            //Atividade conforme art 24
            cbActivityArt24.Text = new ActivityArt24("II").Name;//Precisa de campo no RDASectionView

            //Preenchimento de RitchTextBoxes
            //INTRODUÇÃO


            //MOTIVAÇÕES


            //OBJETIVOS

            //DESCRIÇÃO DAS ETAPAS
            //Precisa de campo no RDASectionView - e precisa ser RTB
            txtProjectStepGeneralDescription.Text = "Esta seção descreve as etapas de natureza técnico-científica necessárias para o desenvolvimento deste projeto. \nFoi realizada uma pesquisa no ano base de 2019 ... \nO projeto foi organizado em 7 etapas desenvolvidas entre 02/01/2020 e 31/12/2020. Estas etapas, por sua vez, foram estruturadas em 35 atividades de caráter tecnológico a saber:";

            ProjectStepDescriptor step1 = new ProjectStepDescriptor("Planejamento e Gestão Técnica do projeto", "É a etapa responsável pelo controle e gerenciamento das atividades do projeto. Esta etapa envolveu o planejamento e acompanhamento das atividades e controle do projeto relacionados a aspectos físico-financeiros, de recursos (humanos e materiais), tempo, escopo, riscos, aderência às regras definidas na Lei de Informática estabelecidas pelo MCTI (Ministério da Ciência, Tecnologia e Inovações). Etapa necessária para direcionar esforços e acompanhar a evolução das atividades para garantir o atingimento dos resultados. Esta etapa contemplou as seguintes atividades:");
            m_RDASectionView.ProjectSteps.AddProjectStep(step1);

            ProjectStepDescriptor step2 = new ProjectStepDescriptor("Investigativa/Pesquisa", "Etapa responsável pelas atividades de investigação das possíveis abordagens para encontrar soluções para o problema técnico científico do projeto. Compreendeu atividades de análise de soluções existentes no mercado e na indústria para execução remota de diagnósticos de hardware; estudos específicos sobre criação de APIs para comunicação remota e sobre problemas de segurança e vulnerabilidades em comunicação remota em firmwares open-source UEFI. Esta etapa contemplou as seguintes atividades:");
            m_RDASectionView.ProjectSteps.AddProjectStep(step2);

            ProjectStepDescriptor step3 = new ProjectStepDescriptor("Gestão Tecnológica", "Nesta etapa foram realizados o planejamento e controle das atividades relacionadas a aspectos físico-financeiros, recursos (humanos e materiais), tempo, escopo, riscos, aderência às regras definidas na Lei de Informática e inovação. Esta etapa contemplou as seguintes atividades:");
            m_RDASectionView.ProjectSteps.AddProjectStep(step3);


            //ATIVIDADES
            //1
            ProjectActivityDescriptor act1 = new ProjectActivityDescriptor(step1.Id, "Elaborar toda a documentação de gestão e controle do projeto", "Esta atividade consistiu em elaborar atas das reuniões técnicas realizadas, as estratégias adotadas para a gestão de riscos, condução da pesquisa proposta, escopo de experimentos de validação para cada PoC.",
            DateTime.Now, DateTime.Now);

            //Obtem indice global da atividade
            act1.GlobalIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex() + 1;

            //Inserindo a atividade na etapa "pai"            
            step1.RegisterActivity(act1);


            //2
            ProjectActivityDescriptor act2 = new ProjectActivityDescriptor(step1.Id, "Gerar relatórios de andamento do projeto", "Esta atividade consistiu em gerar apresentações técnicas com o andamento do projeto e mapeamento dos riscos inerentes a cada etapa e das necessidades para o bom andamento do cronograma do projeto.",
            DateTime.Now, DateTime.Now);

            //Obtem indice global da atividade
            act2.GlobalIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex() + 1;

            //Inserindo a atividade na etapa "pai"            
            step1.RegisterActivity(act2);

            //3
            ProjectActivityDescriptor act3 = new ProjectActivityDescriptor(step1.Id, "Apresentar controle e execução das tarefas de gestão", "Esta atividade consistiu em apresentar controle e execução das tarefas de gestão sobre cada etapa do projeto.",
            DateTime.Now, DateTime.Now);

            //Obtem indice global da atividade
            act3.GlobalIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex() + 1;

            //Inserindo a atividade na etapa "pai"            
            step1.RegisterActivity(act3);

            //4
            ProjectActivityDescriptor act4 = new ProjectActivityDescriptor(step1.Id, "Liderança técnica", "Esta atividade consistiu em orientar o time durante os trabalhos, nas discussões e decisões técnicas acerca das soluções propostas, na validação das entregas especificadas e planejadas para a equipe.",
            DateTime.Now, DateTime.Now);

            //Obtem indice global da atividade
            act4.GlobalIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex() + 1;

            //Inserindo a atividade na etapa "pai"            
            step1.RegisterActivity(act4);

            //5
            ProjectActivityDescriptor act5 = new ProjectActivityDescriptor(step2.Id, "Estudo relacionado a gerenciamento e armazenamento de certificados para comunicação segura em ambiente pré-SO", "Esta atividade consistiu em realizar um estudo relacionado ao armazenamento dos certificados de segurança utilizados para criptografia das informações trafegadas, garantindo assim que a autenticidade dos dados, bem como o envio, ocorresse somente para targets autorizados.",
            DateTime.Now, DateTime.Now);

            //Obtem indice global da atividade
            act5.GlobalIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex() + 1;

            //Inserindo a atividade na etapa "pai"            
            step2.RegisterActivity(act5);

            //6
            ProjectActivityDescriptor act6 = new ProjectActivityDescriptor(step3.Id, "Gestão Administrativa e Financeira", "Os objetivos desta atividade foram: realizar o planejamento e controle financeiro de despesas, compras de equipamentos, serviços externos e demais despesas necessárias para a execução do projeto;  Elaborar relatórios pertinentes ao andamento do projeto, dentre os quais, apresentação do controle e execução das tarefas de gestão, elaboração e demonstração de relatórios mensais de acompanhamento físico-financeiro do projeto; executar a administração de RH e contratação de mão de obra especializada, suporte à gestão do projeto no quesito jurídico, técnico e administrativo",
            DateTime.Now, DateTime.Now);

            //Obtem indice global da atividade
            act6.GlobalIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex() + 1;

            //Inserindo a atividade na etapa "pai"            
            step3.RegisterActivity(act6);

            //Atualiza a lista COMPLETA DE ATIVIDADES
            m_RDASectionView.ProjectFullActivitiesList.Clear();
            m_RDASectionView.ProjectFullActivitiesList.AddRange(m_RDASectionView.ProjectSteps.GetFullActivitiesList());

            //Atualiza a lista de Atividades do ano base
            DateTime baseYear = new DateTime(int.Parse(txtBaseYear.Text), 1, 1);
            m_RDASectionView.BaseYearActivities.UpdateBaseYearActivitiesList(baseYear, m_RDASectionView.ProjectSteps.List.ToList<ProjectStepDescriptor>());

            foreach (var act in m_RDASectionView.BaseYearActivities.List)
            {
                //O RTB está gerando um newline no final e isso detona a formatação
                var rtb = new RichTextBox();
                SetRichTextBoxFromRtfString("Descrição de atividade realizada no ano base", ref rtb); //caracteres como 'ç' e 'ã' nao estão sendo carregados corretamente
                act.BaseYearDescription = rtb;

                SetRichTextBoxFromRtfString("Descrição de resultados da atividade realizada no ano base", ref rtb);
                act.BaseYearResults = rtb;
            }

            //Cadastro de RH
            var hr1 = new HumanResource("Manager 1", "123.456.789-11", "Graduação", "Graduação em Administração", Constants.HRType.DirectHR,
                "Gerente de Projeto", 500.0f, new DateTime(2021, 01, 02), new DateTime(2021, 12, 31), "R$ 50.000,00");
            m_RDASectionView.HumanResources.List.Add(hr1);

            var hr2 = new HumanResource("Dev 1", "123.456.789-12", "Pós-Graduação", "Graduação em Software", Constants.HRType.DirectHR,
                "Analista de Desenvolvimento de Software", 1500.0f, new DateTime(2021, 02, 01), new DateTime(2021, 12, 31), "R$ 75.000,00");
            m_RDASectionView.HumanResources.List.Add(hr2);

            var hr3 = new HumanResource("Lead 1", "123.456.789-13", "Mestrado", "Graduação em Desenvolvimento de Sistemas", Constants.HRType.DirectHR,
                "Lider Tecnico", 1000.0f, new DateTime(2021, 01, 10), new DateTime(2021, 12, 31), "R$ 100.000,00");
            m_RDASectionView.HumanResources.List.Add(hr3);

            var hr4 = new HumanResource("Test 1", "123.456.789-14", "Graduação", "Graduação em Desenvolvimento de Sistemas", Constants.HRType.DirectHR,
                "Analista de Testes", 1250.0f, new DateTime(2021, 03, 10), new DateTime(2021, 12, 31), "R$ 65.000,00");
            m_RDASectionView.HumanResources.List.Add(hr4);

            var hr5 = new HumanResource("Adm 1", "123.456.789-15", "Graduação", "Graduação em Economia", Constants.HRType.IndirectHR,
            "Administração Financeira", 1250.0f, new DateTime(2021, 03, 10), new DateTime(2021, 12, 31), "R$ 35.000,00");
            m_RDASectionView.HumanResources.List.Add(hr5);


            //Criando as atividades de RH Direto
            //Seleciona um HR
            HumanResource dhr1 = m_RDASectionView.HumanResources.List.Single(i => i.Name == hr1.Name);

            //Cria a atividade
            var selActivity =  m_RDASectionView.ProjectFullActivitiesList.Single(i=>i.Id == act1.Id);
            
            string selActivityName = selActivity.FullActivityName;
            Guid selActivityId = act1.Id;
            string selActivityShortName = selActivity.ShortActivityName;

            HumanResourceActivity activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr1.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr1);


            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act3.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act3.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr1.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr1);



            //Seleciona um HR
            HumanResource dhr2 = m_RDASectionView.HumanResources.List.Single(i => i.Name == hr2.Name);

            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act5.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act5.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr2.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr2);



            //Seleciona um HR
            HumanResource dhr3 = m_RDASectionView.HumanResources.List.Single(i => i.Name == hr3.Name);

            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act3.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act3.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr3.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr3);


            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act4.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act4.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr3.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr3);



            //Seleciona um HR
            HumanResource dhr4 = m_RDASectionView.HumanResources.List.Single(i => i.Name == hr4.Name);

            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act3.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act3.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr4.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr4);


            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act6.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act4.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr4.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr4);



            //Seleciona um HR
            HumanResource dhr5 = m_RDASectionView.HumanResources.List.Single(i => i.Name == hr5.Name);

            //Cria a atividade
            selActivity = m_RDASectionView.ProjectFullActivitiesList.Single(i => i.Id == act6.Id);

            selActivityName = selActivity.FullActivityName;
            selActivityId = act6.Id;
            selActivityShortName = selActivity.ShortActivityName;

            activity = new HumanResourceActivity(selActivityId, selActivityName, selActivityShortName, txtDirectHRActivityDescription);

            //Insere atividade no HR
            dhr5.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr4);


            //Atualiza a lista de atividades no HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(dhr4);


            //Dispendios do ano base
            var expensesItem = new BaseYearExpensesDescriptor("R$ 1.500.000,00", "R$ 20.000,00", "R$1.000,00", "R$2.500,00", "R$ 1.250.000", "R$ 30.000,00", "R$ 150.000,00", 
                "R$ 90.000,00", "R$ 900.000,00", "R$ 100.000,00", "R$20.000,00", "R$ 10.000,00");

            m_RDASectionView.BaseYearExpenses.List.Add(expensesItem);


            //Investimento em recursos humanos
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesDirectSuperior = txtQtyEmployeesDirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesDirectMedium = txtQtyEmployeesDirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesIndirectSuperior = txtQtyEmployeesIndirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesIndirectMedium = txtQtyEmployeesIndirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesTotal = txtQtyEmployeesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.ValueDirectSuperior = txtValueDirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.ValueDirectMedium = txtValueDirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.ValueIndirectSuperior = txtValueIndirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.ValueIndirectMedium = txtValueIndirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.ValueTotal = txtValueTotal.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursDirectSuperior = txtTotalHoursDirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursDirectMedium = txtTotalHoursDirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursIndirectSuperior = txtTotalHoursIndirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursIndirectMedium = txtTotalHoursIndirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursTotal = txtTotalHoursTotal.Text;
            m_RDASectionView.baseYearHRInvestments.TotalValuePassedToInstitution = txtTotalValuePassedToInstitution.Text;
            m_RDASectionView.baseYearHRInvestments.AnticipatedValueForNextYear = txtAnticipatedValueForNextYear.Text;
            m_RDASectionView.baseYearHRInvestments.AnticipatedValueFromPreviousYear = txtAnticipatedValueFromPreviousYear.Text;
            m_RDASectionView.baseYearHRInvestments.ExpendedValueOnBaseYear = txtExpendedValueOnBaseYear.Text;
            m_RDASectionView.baseYearHRInvestments.ValidTotalCompromisedOnBaseYear = txtValidTotalCompromisedOnBaseYear.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearReceivedResourcesTotal = txtBaseYearReceivedResourcesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearReceivedResourcesPercentage = txtBaseYearReceivedResourcesPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearAnticipatedResourcesTotal = txtBaseYearAnticipatedResourcesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearAnticipatedResourcesPercentage = txtBaseYearAnticipatedResourcesPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearDirectHRTotal = txtBaseYearDirectHRTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearDirectHRPercentage = txtBaseYearDirectHRPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearIndirectHRTotal = txtBaseYearIndirectHRTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearIndirectHRPercentage = txtBaseYearIndirectHRPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearEquipmentTotal = txtBaseYearEquipmentTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearEquipmentPercentage = txtBaseYearEquipmentPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearCivilTotal = txtBaseYearCivilTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearCivilPercentage = txtBaseYearCivilPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTravelTotal = txtBaseYearTravelTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTravelPercentage = txtBaseYearTravelPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearMaterialTotal = txtBaseYearMaterialTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearMaterialPercentage = txtBaseYearMaterialPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTrainingTotal = txtBaseYearTrainingTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTrainingPercentage = txtBaseYearTrainingPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearBooksTotal = txtBaseYearBooksTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearBooksPercentage = txtBaseYearBooksPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearServicesTotal = txtBaseYearServicesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearServicesPercentage = txtBaseYearServicesPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearOtherTotal = txtBaseYearOtherTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearOtherPercentage = txtBaseYearOtherPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearInstitutionTotal = txtBaseYearInstitutionTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearInstitutionPercentage = txtBaseYearInstitutionPercentage.Text;




            //Cronograma de atividades do ano base
            m_RDASectionView.BaseYearSchedule.BuildScheduleList(m_RDASectionView.ProjectSteps.List.ToList());



            //Atualiza GUI
            //lvDirectHRActivities.Items.Refresh();
        }


        private void btGenerate_Click(object sender, RoutedEventArgs e)
        {
            ReferenceManager.ResetCounter();//Inicializando contador de referencias, para multiplos cliques do botao gen

            string fileName = txtPath.Text + @"\" + txtFileName.Text;
            DocX doc = null;


            //Verificação de template
            if (!string.IsNullOrEmpty(txtTemplateFileName.Text))
            {
                string sSource = txtTemplateFileName.Text;

                System.IO.File.Copy(sSource, fileName, true);

                doc = DocX.Load(fileName);
            }
            else
            {
                doc = DocX.Create(fileName);
            }


            //Strings auxiliares
            string SEC_IDENTIFICATION = lblIdentification.Content.ToString();
            string SEC_PROJNAME = lblProjName.Content.ToString();
            string SEC_REGION = lblRegion.Content.ToString();
            string SEC_INSTITUTION = lblInstitution.Content.ToString();
            string SEC_AGREEMENT = lblAgreement.Content.ToString();

            string SEC_EXECUTIONPERIOD = lblExecutionPeriod.Content.ToString();
            string SEC_BASEYEARPERIOD = lblBaseYearExecution.Content.ToString();
            string SEC_SELECTEDUF = lblUF.Content.ToString();
            string SEC_PROJECTTYPE = lblProjectType.Content.ToString();

            string SEC_PROJECTSUBSTITUTION = lblProjectSubstitution.Content.ToString();
            string SEC_PROJECTACCOUNTABLE = lblProjectAccountable.Content.ToString();
            string SEC_PROJECTREACH = lblProjectReach.Content.ToString();
            string SEC_PROJECTINOVATION = lblProjectInovation.Content.ToString();
            string SEC_PROJECTIP = lblProjectIP.Content.ToString();

            string SEC_PROJECTAPPLICATION = lblProjectApplication.Content.ToString();
            string SEC_PUBLICATIONQTY = lblPublicationsQty.Content.ToString();
            string SEC_ACTIVITYART24 = lblActivityArt24.Content.ToString();
            string SEC_PROJECTOBJECTIVE = lblSecObjective.Content.ToString();
            string SEC_INVESTMENT_DESCRIPTION = lblSecInvestmentDescription.Content.ToString();

            string SEC_BASE_YEAR_SCHEDULE = lblSecBaseYearSchedule.Content.ToString();
            string PARAGRAPH_NUMBER = "#";
            string PARAGRAPH_STEP_DECRIPTION = "Descrição das Etapas/ Atividades";
            string PARAGRAPH_EXECUTION_SCHEDULE = "Período de Execução";

            string PARAGRAPH_BASE_YEAR_VALID_TOTAL_EXP = lblBaseYearValidTotalExpenses.Content.ToString();

            string SEC_PROJECT_EXPENSES = lblSecBaseYearExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_EQUIPMENT = lblSecBaseYearExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_CIVIL = lblBaseYearCivilProjectsExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_TRAVEL = lblBaseYearTravelExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_MATERIAL = lblBaseYearMaterialExpenses.Content.ToString();

            string PARAGRAPH_BASE_YEAR_EXP_TRAINING = lblBaseYearTrainingExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_BOOKS = lblBaseYearBooksExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_OTHER = lblBaseYearOtherExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_EXP_SERVICES = lblBaseYearServicesExpenses.Content.ToString();

            string PARAGRAPH_BASE_YEAR_INSTITUTION_EXPENSES = lblBaseYearInstitutionExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_TOTAL_WITHOUT_HR = lblBaseYearTotalWithoutHRExpenses.Content.ToString();
            string PARAGRAPH_BASE_YEAR_TOTAL_EXPENSES = lblBaseYearTotalExpenses.Content.ToString();

            string PARAGRAPH_HR_INVESTMENTS = lblHRInvestments.Content.ToString();

            string SUBSEC_DIRECT_HR = lblDirectHR.Content.ToString();
            string SUBSEC_INDIRECT_HR = lblIndirectHR.Content.ToString();

            string SEC_PROJECTSTEPS = lblSecProjectSteps.Content.ToString();
            string PARAGRAPH_STEP_NAME = lblProjectStepName.Content.ToString();
            string PARAGRAPH_STEP_DESCRIPTION = lblProjectStepDescription.Content.ToString();
            string PARAGRAPH_ACTIVITY_NAME = lblProjectActivityName.Content.ToString();
            string PARAGRAPH_ACTIVITY_DESCRIPTION = lblProjectActivityDescription.Content.ToString();
            string PARAGRAPH_ACTIVITY_STARTDATE = lblProjectActivityStartDate.Content.ToString();
            string PARAGRAPH_ACTIVITY_ENDDATE = lblProjectActivityEndDate.Content.ToString();

            string PARAGRAPH_DIRECTHR_NAME = lblDirectHRName.Content.ToString();
            string PARAGRAPH_DIRECTHR_CPF  = lblDirectHRCPF.Content.ToString();
            string PARAGRAPH_DIRECTHR_EDUCATION_LEVEL = lblDirectHREducationLevel.Content.ToString();
            string PARAGRAPH_DIRECTHR_EDUCATION = lblDirectHREducation.Content.ToString();
            string PARAGRAPH_DIRECTHR_PROJECT_ROLE = lblHRProjectRole.Content.ToString();
            string PARAGRAPH_DIRECTHR_PROJECT_HOURS = lblHRProjectHours.Content.ToString();
            string PARAGRAPH_DIRECTHR_PROJECT_EXPENSES = lblHRProjectExpenses.Content.ToString();
            string PARAGRAPH_DIRECTHR_PROJECT_START = lblHRProjectPeriod.Content.ToString();
            string PARAGRAPH_DIRECTHR_PROJECT_END = lblHRProjectPeriod2.Content.ToString();
            string PARAGRAPH_DIRECTHR_ACTIVITIES = lblBaseYearHRActivities.Content.ToString();


            string PARAGRAPH_SUPERIOR = lblSuperior.Content.ToString();
            string PARAGRAPH_MEDIUM = lblMedium.Content.ToString();
            string PARAGRAPH_TOTAL = lblTotal.Content.ToString();
            string PARAGRAPH_LEVEL = lblLevel.Content.ToString();

            string PARAGRAPH_QTY_EMPLOYEES = lblQtyEmployees.Content.ToString();
            string PARAGRAPH_EXP_VALUE = lblExpenseValue.Content.ToString();
            string PARAGRAPH_TOTAL_HOURS = lblTotalHours.Content.ToString();

            string PARAGRAPH_TOTAL_VALUE_PASSED_TO_INSTITUTION = lblTotalValuePassedToInstitution.Content.ToString();
            string PARAGRAPH_ANTICIPATED_VALUE_NEXT_YEAR = lblAnticipatedValueForNextYear.Content.ToString();
            string PARAGRAPH_ANTICIPATED_VALUE_PREVIOUS_YEAR = lblAnticipatedValueFromPreviousYear.Content.ToString();
            string PARAGRAPH_EXPENDED_VALUE_ON_BASE_YEAR = lblExpendedValueOnBaseYear.Content.ToString();
            string PARAGRAPH_TOTAL_COMPROMISED_ON_BASE_YEAR = lblValidTotalCompromisedOnBaseYear.Content.ToString();

            string PARAGRAPH_RUBRICA = lblRubrica.Content.ToString();
            string PARAGRAPH_RUBRICA_TOTAL = lblRubricaTotal.Content.ToString();
            string PARAGRAPH_RUBRICA_PERCENTAGE = lblRubricaPercentage.Content.ToString();
            string PARAGRAPH_RUBRICA_REMAINING = lblRubricaRemaining.Content.ToString();
            
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES = lblBaseYearReceivedResources.Content.ToString();
            string PARAGRAPH_BASE_YEAR_ANTICIPATED_RESOURCES = lblBaseYearAnticipatedResources.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_DIRECT_HR = lblBaseYearReceivedResourcesDirectHR.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_INDIRECT_HR = lblBaseYearReceivedResourcesIndirectHR.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_EQUIPMENT = lblBaseYearReceivedResourcesEquipment.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_CIVIL = lblBaseYearReceivedResourcesCivil.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_TRAVEL = lblBaseYearReceivedResourcesTravel.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_MATERIAL = lblBaseYearReceivedResourcesMaterial.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_TRAINING = lblBaseYearReceivedResourcesTraining.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_BOOKS = lblBaseYearReceivedResourcesBooks.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_SERVICES = lblBaseYearReceivedServices.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_OTHER = lblBaseYearReceivedOther.Content.ToString();
            string PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_INSTITUTION = lblBaseYearReceivedInstitution.Content.ToString();

            string SUBSEC_METHODOLOGY = lblSubSecMetodology.Content.ToString();
            string SUBSEC_BASE_YEAR_ACTIVITY = lblSubSecBaseYearActivity.Content.ToString();

            string PARAGRAPH_PROJECTSCOPE_BOLD = lblProjectScope.Content.ToString();
            string PARAGRAPH_PROJECTDEVELOPMENT_BOLD = lblProjectDevelopment.Content.ToString();
            string PARAGRAPH_PROJECTECONOMICACTIVITY_BOLD = lblProjectEconomicActivity.Content.ToString();
            string PARAGRAPH_TEMP = lblTEMP.Content.ToString();

            string SUBSEC_INTRODUCTION = lblIntroduction.Content.ToString();
            string SUBSEC_MOTIVATIONS = lblMotivation.Content.ToString();
            string SUBSEC_OBJECTIVES = lblObjectives.Content.ToString();

            string PARAGRAPH_PROJECTREACH = lblProjectReach2.Content.ToString();

            string PARAGRAPH_AGREEMENT_NUMBER = lblAgreementNumber.Content.ToString();
            string PARAGRAPH_AGREEMENT_START_DATE = lblAgreementStartDate.Content.ToString();
            string PARAGRAPH_AGREEMENT_END_DATE = lblAgreementEndDate.Content.ToString();

            string PARAGRAPH_ACCOUNTABLE_NAME = lblAccountableName.Content.ToString();
            string PARAGRAPH_ACCOUNTABLE_CPF = lblAccountableCPF.Content.ToString();
            string PARAGRAPH_ACCOUNTABLE_PHONE = lblAccountablePhone.Content.ToString();
            string PARAGRAPH_ACCOUNTABLE_EMAIL = lblAccountableEmail.Content.ToString();

            string PARAGRAPH_ACT24_1 = txtBlockArt24_1.Text;
            string PARAGRAPH_ACT24_2 = txtBlockArt24_2.Text;
            string PARAGRAPH_ACT24_3 = txtBlockArt24_3.Text;
            string PARAGRAPH_ACT24_4 = txtBlockArt24_4.Text;
            string PARAGRAPH_ACT24_5 = txtBlockArt24_5.Text;
            string PARAGRAPH_ACT24_6 = txtBlockArt24_6.Text;
            string PARAGRAPH_ACT24_7 = txtBlockArt24_7.Text;
            string PARAGRAPH_ACT24_8 = txtBlockArt24_8.Text;
            string PARAGRAPH_ACT24_9 = txtBlockArt24_9.Text;


            RDASection oSection;
            RDAParagraph oParagraph;

            //IDENTIFICAÇÃO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_IDENTIFICATION);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtSecIdentification.Text);

            //NOME DO PROJETO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJNAME);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtSecProjName.Text);

            //REGIÃO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_REGION);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtSecRegion.Text);

            //INSTITUIÇÃO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_INSTITUTION);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtSecInstitution.Text);

            //CONVÊNIO EMPRESA/INSTITUIÇÃO: 
            oSection = new RDASection(doc);
            oSection.AddText(SEC_AGREEMENT);

            oParagraph = new RDAParagraph(doc, oSection);


            string sAux = "";
            foreach (AgreementDescriptor item in m_RDASectionView.Agreements.List)
            {
                oParagraph.AddText(PARAGRAPH_AGREEMENT_NUMBER, true);
                oParagraph.AppendText(" ");
                oParagraph.AppendText(item.AgreementNumber);

                sAux = string.Format("{0} {1}", PARAGRAPH_AGREEMENT_START_DATE, item.StartDate);
                oParagraph.AddText(sAux);

                sAux = string.Format("{0} {1}", PARAGRAPH_AGREEMENT_END_DATE, item.EndDate);
                oParagraph.AddText(sAux);

                oParagraph.AddText("");
            }

            //PERIODO DE EXECUÇÃO TOTAL
            oSection = new RDASection(doc);
            oSection.AddText(SEC_EXECUTIONPERIOD);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtExecutionPeriod.Text);

            //PERIODO DE EXECUÇÃO NO ANO BASE
            oSection = new RDASection(doc);
            oSection.AddText(SEC_BASEYEARPERIOD);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtBaseYearExecution.Text);

            //UF DE EXECUÇÃO DO PROJETO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_SELECTEDUF);

            oParagraph = new RDAParagraph(doc, oSection);
            if (cbBRStates.SelectedItem != null)
            {
                oParagraph.AddText(m_RDASectionView.BRStates[cbBRStates.SelectedIndex].Id);
            }


            //TIPO DE PROJETO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTTYPE);

            int rows = m_RDASectionView.ProjectTypes.Count;

            //Create Table with 2 rows and 4 columns.
            Xceed.Document.NET.Table t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;
            //t.Design = TableDesign.ColorfulList;

            float[] w = new float[] { 5.0f, 50.0f };
            t.SetWidthsPercentage(w);

            for (int i = 0; i < rows; i++)
            {
                ProjectType item = m_RDASectionView.ProjectTypes[i];

                if (cbProjectTypes.SelectedItem != null && item.Name == m_RDASectionView.ProjectTypes[cbProjectTypes.SelectedIndex].Name)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append("X");
                }

                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);


                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);


            //PROJETO PARA CUMPRIR TROCA DE PPB...
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTSUBSTITUTION);

            rows = m_RDASectionView.ProjectSubstitutions.Count;

            //Create Table with n rows and 4 columns.
            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 50.0f };
            t.SetWidthsPercentage(w);

            for (int i = 0; i < rows; i++)
            {
                ProjectSubstitution item = m_RDASectionView.ProjectSubstitutions[i];

                if (cbProjectSubstitution.SelectedItem != null && item.Name == m_RDASectionView.ProjectSubstitutions[cbProjectSubstitution.SelectedIndex].Name)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append("X");
                }

                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);


                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);

            //RESPONSAVEL PELO PROJETO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTACCOUNTABLE);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_ACCOUNTABLE_NAME, true);
            oParagraph.AppendText(" ");
            oParagraph.AppendText(txtAccountableName.Text);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_ACCOUNTABLE_CPF, true);
            oParagraph.AppendText(" ");
            oParagraph.AppendText(txtAccountableCPF.Text);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_ACCOUNTABLE_PHONE, true);
            oParagraph.AppendText(" ");
            oParagraph.AppendText(txtAccountablePHONE.Text);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_ACCOUNTABLE_EMAIL, true);
            oParagraph.AppendText(" ");
            oParagraph.AppendText(txtAccountableEMAIL.Text);


            //ALCANCE DO PROJETO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTREACH);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_PROJECTREACH);

            //Create Table with n rows and 4 columns.
            rows = 6;

            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 50.0f };
            t.SetWidthsPercentage(w);

            if (m_RDASectionView.ReachInstitution)
            {
                t.Rows[0].Cells[0].Paragraphs.First().Append("X");
            }
            t.Rows[0].Cells[1].Paragraphs.First().Append(chkInstitution.Content.ToString());


            if (m_RDASectionView.ReachInCompany)
            {
                t.Rows[1].Cells[0].Paragraphs.First().Append("X");
            }
            t.Rows[1].Cells[1].Paragraphs.First().Append(chkCompany.Content.ToString());


            if (m_RDASectionView.ReachMarket)
            {
                t.Rows[2].Cells[0].Paragraphs.First().Append("X");
            }
            t.Rows[2].Cells[1].Paragraphs.First().Append(chkMarket.Content.ToString());


            if (m_RDASectionView.ReachExport)
            {
                t.Rows[3].Cells[0].Paragraphs.First().Append("X");
            }
            t.Rows[3].Cells[1].Paragraphs.First().Append(chkExport.Content.ToString());


            if (m_RDASectionView.ReachOuterCompany)
            {
                t.Rows[4].Cells[0].Paragraphs.First().Append("X");
            }
            t.Rows[4].Cells[1].Paragraphs.First().Append(chkOuterCompany.Content.ToString());


            if (m_RDASectionView.ReachImportReduction)
            {
                t.Rows[5].Cells[0].Paragraphs.First().Append("X");
            }
            t.Rows[5].Cells[1].Paragraphs.First().Append(chkImportReduction.Content.ToString());


            for (int i = 0; i < rows; i++)
            {
                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);


            //GRAU DE INOVAÇÃO
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTINOVATION);

            //ABRANGENCIA
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_PROJECTSCOPE_BOLD, true);

            rows = m_RDASectionView.ProjectInovationList.Count;
            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 75.0f };
            t.SetWidthsPercentage(w);

            for (int i = 0; i < rows; i++)
            {
                var item = m_RDASectionView.ProjectInovationList[i];

                if (cbProjectInovation.SelectedItem != null && item.Name == m_RDASectionView.ProjectInovationList[cbProjectInovation.SelectedIndex].Name)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append("X");
                }

                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);


                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);


            //DESENVOLVIMENTO
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_PROJECTDEVELOPMENT_BOLD, true);

            rows = m_RDASectionView.ProjectDevelopmentList.Count;
            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 50.0f };
            t.SetWidthsPercentage(w);

            for (int i = 0; i < rows; i++)
            {
                var item = m_RDASectionView.ProjectDevelopmentList[i];

                if (cbProjectDevelopment.SelectedItem != null && item.Name == m_RDASectionView.ProjectDevelopmentList[cbProjectInovation.SelectedIndex].Name)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append("X");
                }

                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);


                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);

            //ÁREA DE APLICAÇÃO DO PROJETO:
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTAPPLICATION);

            //ATIVIDADE ECONOMICA
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_PROJECTECONOMICACTIVITY_BOLD, true);

            //CÓDIGO
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(PARAGRAPH_TEMP);

            //ESTE PROJETO GEROU PROPRIEDADE INTELECTUAL?
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTIP);

            rows = m_RDASectionView.ProjectIPList.Count;
            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 50.0f };
            t.SetWidthsPercentage(w);

            for (int i = 0; i < rows; i++)
            {
                var item = m_RDASectionView.ProjectIPList[i];

                if (cbProjectIP.SelectedItem != null && item.Name == m_RDASectionView.ProjectIPList[cbProjectIP.SelectedIndex].Name)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append("X");
                }

                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);


                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);

            //TABELA DE PROPRIEDADES INTELECTUAIS
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText("");
            oParagraph.AddText("");

            rows = m_RDASectionView.ProjectIPs.List.Count;

            if (rows != 0)
            {
                t = doc.AddTable(rows, 5);
                t.Alignment = Alignment.left;

                w = new float[] { 20.0f, 20.0f, 20.0f, 20.0f, 20.0f };
                t.SetWidthsPercentage(w);

                for (int i = 0; i < rows; i++)
                {
                    var item = m_RDASectionView.ProjectIPs.List[i];

                    t.Rows[i].Cells[0].Paragraphs.First().Append(item.Description);
                    t.Rows[i].Cells[1].Paragraphs.First().Append(item.Type);
                    t.Rows[i].Cells[2].Paragraphs.First().Append(item.Register);
                    t.Rows[i].Cells[3].Paragraphs.First().Append(item.Date);
                    t.Rows[i].Cells[4].Paragraphs.First().Append(item.Local);
                }
                doc.InsertTable(t);
            }

            //QUANTIDADE DE PUBLICAÇÕES:
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PUBLICATIONQTY);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtPublicationsQty.Text);

            //ATIVIDADE CONFORME ART. 24
            oSection = new RDASection(doc);
            oSection.AddText(SEC_ACTIVITYART24);

            //Esta tabela precisa ficar na horizontal
            rows = m_RDASectionView.ActivityArt24List.Count;
            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 50.0f };
            t.SetWidthsPercentage(w);

            for (int i = 0; i < rows; i++)
            {
                var item = m_RDASectionView.ActivityArt24List[i];

                if (cbActivityArt24.SelectedItem != null && item.Name == m_RDASectionView.ActivityArt24List[cbActivityArt24.SelectedIndex].Name)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append("X");
                }

                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);


                //removendo as bordas
                System.Drawing.Color c = System.Drawing.Color.FromName("White");
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Bottom, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Top, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
                t.Rows[i].Cells[1].SetBorder(TableCellBorderType.Right, new Xceed.Document.NET.Border(BorderStyle.Tcbs_none, 0, 0, c));
            }
            doc.InsertTable(t);

            //texto do art 24
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText("");
            oParagraph.AddText(PARAGRAPH_ACT24_1);
            oParagraph.AddText(PARAGRAPH_ACT24_2);
            oParagraph.AddText(PARAGRAPH_ACT24_3);
            oParagraph.AddText(PARAGRAPH_ACT24_4);
            oParagraph.AddText(PARAGRAPH_ACT24_5);
            oParagraph.AddText(PARAGRAPH_ACT24_6);
            oParagraph.AddText(PARAGRAPH_ACT24_7);
            oParagraph.AddText(PARAGRAPH_ACT24_8);
            oParagraph.AddText(PARAGRAPH_ACT24_9);


            //OBJETIVO DO PROJETO
            CustomParagraph sRichtText;

            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTOBJECTIVE);

            //SUBSEÇÃO INTRODUÇÃO
            var oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_INTRODUCTION);

            sRichtText = new CustomParagraph(doc, oSubSection);
            sRichtText.InsertParagraph(txtIntroduction);

            //SUBSEÇÃO MOTIVAÇÕES
            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_MOTIVATIONS);

            sRichtText = new CustomParagraph(doc, oSubSection);
            sRichtText.InsertParagraph(txtMotivation);

            //SUBSEÇÃO OBJETIVOS
            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_OBJECTIVES);

            sRichtText = new CustomParagraph(doc, oSubSection);
            sRichtText.InsertParagraph(txtObjectives);


            //DESCRIÇÃO DAS ETAPAS
            oSection = new RDASection(doc);
            oSection.AddText(SEC_PROJECTSTEPS);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText(txtProjectStepGeneralDescription.Text);

            //Lista das Etapas e Atividades 

            foreach(var step in m_RDASectionView.ProjectSteps.List)
            {
                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText(step.Index + " - " + step.Name + ".", true, false, true);
                oParagraph.AppendText(" " + step.Description);

                foreach(var activity in step.GetActivitiesList())
                {
                    oParagraph = new RDAParagraph(doc, oSection);
                    oParagraph.AddText(activity.FullActivityName + ".", false, false, true);
                    oParagraph.AppendText(" " + activity.Description);
                }
            }

            //SUBSEÇÃO METODOLOGIA
            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_METHODOLOGY);

            sRichtText = new CustomParagraph(doc, oSubSection);
            sRichtText.InsertParagraph(txtMetodology);


            //SUBSEÇÃO ATIVIDADES DO ANO BASE
            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_BASE_YEAR_ACTIVITY);

            //Obtendo a lista das atividades realizadas no ano base
            //Se a atividade INICIA no ano base ou TERMINA no ano base, será incluida
            //Se a atividade nao inicia e nem termina no ano base, mas o ano base está incluido no intervalo inicio < ano-base < termino
            //a atividade sera incluida 
            int iIndex = 0;
            foreach(var activity in m_RDASectionView.BaseYearActivities.List)
            {
                //Linha em branco
                oParagraph = new RDAParagraph(doc);
                oParagraph.AddText("");

                //Atividade
                iIndex++;
                string sText = iIndex.ToString() + ". " + activity.FullActivityName;

                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText("Atividade: ", true);
                oParagraph.AppendText(sText);


                //Etapa
                var parentStep = m_RDASectionView.ProjectSteps.List.Single(i => i.Id == activity.StepId);

                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText("Etapa: ", true);
                oParagraph.AppendText(parentStep.Name);

                //Periodo
                sText = activity.StartDate.Value.ToShortDateString() + " a " + activity.EndDate.Value.ToShortDateString();

                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText("Período de execução: ", true);
                oParagraph.AppendText(sText);

                //Descrição da Atividade
                //Tem que consertar o RTB, até lá usaremos string simples
                //sRichtText = new CustomParagraph(doc, oSection);
                //sRichtText.InsertParagraph(activity.BaseYearDescription);

                //Convertendo RTB para plain text
                TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                activity.BaseYearDescription.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                activity.BaseYearDescription.Document.ContentEnd);

                sText = textRange.Text;

                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText("Descrição: ", true);
                oParagraph.AppendText(sText);

                //Resultado da Atividade
                //Tem que consertar o RTB, até lá usaremos string simples
                //sRichtText = new CustomParagraph(doc, oSection);
                //sRichtText.InsertParagraph(activity.BaseYearResults);

                //Convertendo RTB para plain text
                textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                activity.BaseYearResults.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                activity.BaseYearResults.Document.ContentEnd);

                sText = textRange.Text;

                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText("Resultado: ", true);
                oParagraph.AppendText(sText);


                //Lista de Participantes
                oParagraph = new RDAParagraph(doc, oSection);
                oParagraph.AddText("Participantes: ", true);

                //Falta construir a lista
                List<HumanResource> participants = new List<HumanResource>();
                foreach(var hr in m_RDASectionView.HumanResources.List)
                {
                    if(hr.GetActivityById(activity.Id) != null)
                    {
                        participants.Add(hr);
                    }
                }

                foreach(var hr in participants)
                {
                    oParagraph.AppendText(hr.Name);
                    if(hr == participants.Last())
                    {
                        oParagraph.AppendText(".");
                    }
                    else
                    {
                        oParagraph.AppendText(", ");
                    }
                }
            }



            //DISPENDIO DO ANO BASE
            oSection = new RDASection(doc);
            oSection.AddText(SEC_INVESTMENT_DESCRIPTION);

            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SEC_PROJECT_EXPENSES);

            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            var expensesItem = m_RDASectionView.BaseYearExpenses.List[0]; //por enquanto, acho que só temos uma linha na tabela, confirmar 

            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText(PARAGRAPH_BASE_YEAR_VALID_TOTAL_EXP + " ");

            oParagraph.AppendText(expensesItem.ValidTotalExpenses);


            //Esta tabela precisa ficar na horizontal
            rows = 2;
            t = doc.AddTable(rows, 4);
            t.Alignment = Alignment.left;

            w = new float[] { 25.0f, 25.0f, 25.0f, 25.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_EQUIPMENT);
            t.Rows[1].Cells[0].Paragraphs.First().Append(expensesItem.EquipmentAndSoftware);

            t.Rows[0].Cells[1].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_CIVIL);
            t.Rows[1].Cells[1].Paragraphs.First().Append(expensesItem.CivilProjects);

            t.Rows[0].Cells[2].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_TRAVEL);
            t.Rows[1].Cells[2].Paragraphs.First().Append(expensesItem.Travel);

            t.Rows[0].Cells[3].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_MATERIAL);
            t.Rows[1].Cells[3].Paragraphs.First().Append(expensesItem.Material);

            doc.InsertTable(t);


            //Nova tabela
            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            t = doc.AddTable(rows, 4);
            t.Alignment = Alignment.left;

            w = new float[] { 25.0f, 25.0f, 25.0f, 25.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_TRAINING);
            t.Rows[1].Cells[0].Paragraphs.First().Append(expensesItem.Training);

            t.Rows[0].Cells[1].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_BOOKS);
            t.Rows[1].Cells[1].Paragraphs.First().Append(expensesItem.Books);

            t.Rows[0].Cells[2].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_SERVICES);
            t.Rows[1].Cells[2].Paragraphs.First().Append(expensesItem.Services);

            t.Rows[0].Cells[3].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_EXP_OTHER);
            t.Rows[1].Cells[3].Paragraphs.First().Append(expensesItem.Other);

            doc.InsertTable(t);

            //Nova tabela
            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            t = doc.AddTable(rows, 1);
            t.Alignment = Alignment.left;

            w = new float[] { 50.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_INSTITUTION_EXPENSES);
            t.Rows[1].Cells[0].Paragraphs.First().Append(expensesItem.InstitutionExpenses);

            doc.InsertTable(t);

            //Nova tabela
            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 25.0f, 75.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_TOTAL_EXPENSES);
            t.Rows[1].Cells[0].Paragraphs.First().Append(expensesItem.TotalExpenses);

            t.Rows[0].Cells[1].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_TOTAL_WITHOUT_HR);
            t.Rows[1].Cells[1].Paragraphs.First().Append(expensesItem.TotalWithoutHR);

            doc.InsertTable(t);


            //Investimento em  recursos humanos - FALTA O CABEÇALHO
            var investmentsHR = m_RDASectionView.baseYearHRInvestments;

            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText(PARAGRAPH_HR_INVESTMENTS);

            rows = 4;
            t = doc.AddTable(rows, 6);
            t.Alignment = Alignment.left;

            w = new float[] { 25.0f, 15.0f, 15.0f, 15.0f, 15.0f, 15.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_LEVEL);
            t.Rows[0].Cells[1].Paragraphs.First().Append(PARAGRAPH_SUPERIOR);
            t.Rows[0].Cells[2].Paragraphs.First().Append(PARAGRAPH_MEDIUM);
            t.Rows[0].Cells[3].Paragraphs.First().Append(PARAGRAPH_SUPERIOR);
            t.Rows[0].Cells[4].Paragraphs.First().Append(PARAGRAPH_MEDIUM);
            t.Rows[0].Cells[5].Paragraphs.First().Append(PARAGRAPH_TOTAL);

            t.Rows[1].Cells[0].Paragraphs.First().Append(PARAGRAPH_QTY_EMPLOYEES);
            t.Rows[1].Cells[1].Paragraphs.First().Append(investmentsHR.QtyEmployeesDirectSuperior);
            t.Rows[1].Cells[2].Paragraphs.First().Append(investmentsHR.QtyEmployeesDirectMedium);
            t.Rows[1].Cells[3].Paragraphs.First().Append(investmentsHR.QtyEmployeesIndirectSuperior);
            t.Rows[1].Cells[4].Paragraphs.First().Append(investmentsHR.QtyEmployeesIndirectMedium);
            t.Rows[1].Cells[5].Paragraphs.First().Append(investmentsHR.QtyEmployeesTotal);

            t.Rows[2].Cells[0].Paragraphs.First().Append(PARAGRAPH_EXP_VALUE);
            t.Rows[2].Cells[1].Paragraphs.First().Append(investmentsHR.ValueDirectSuperior);
            t.Rows[2].Cells[2].Paragraphs.First().Append(investmentsHR.ValueDirectMedium);
            t.Rows[2].Cells[3].Paragraphs.First().Append(investmentsHR.ValueIndirectSuperior);
            t.Rows[2].Cells[4].Paragraphs.First().Append(investmentsHR.ValueIndirectMedium);
            t.Rows[2].Cells[5].Paragraphs.First().Append(investmentsHR.ValueTotal);

            t.Rows[3].Cells[0].Paragraphs.First().Append(PARAGRAPH_TOTAL_HOURS);
            t.Rows[3].Cells[1].Paragraphs.First().Append(investmentsHR.TotalHoursDirectSuperior);
            t.Rows[3].Cells[2].Paragraphs.First().Append(investmentsHR.TotalHoursDirectMedium);
            t.Rows[3].Cells[3].Paragraphs.First().Append(investmentsHR.TotalHoursIndirectSuperior);
            t.Rows[3].Cells[4].Paragraphs.First().Append(investmentsHR.TotalHoursIndirectMedium);
            t.Rows[3].Cells[5].Paragraphs.First().Append(investmentsHR.TotalHoursTotal);


            doc.InsertTable(t);

            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            rows = 5;
            t = doc.AddTable(rows, 2);
            t.Alignment = Alignment.left;

            w = new float[] { 60.0f, 40.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_TOTAL_VALUE_PASSED_TO_INSTITUTION);
            t.Rows[0].Cells[1].Paragraphs.First().Append(investmentsHR.TotalValuePassedToInstitution);

            t.Rows[1].Cells[0].Paragraphs.First().Append(PARAGRAPH_ANTICIPATED_VALUE_NEXT_YEAR);
            t.Rows[1].Cells[1].Paragraphs.First().Append(investmentsHR.AnticipatedValueForNextYear);

            t.Rows[2].Cells[0].Paragraphs.First().Append(PARAGRAPH_ANTICIPATED_VALUE_PREVIOUS_YEAR);
            t.Rows[2].Cells[1].Paragraphs.First().Append(investmentsHR.AnticipatedValueFromPreviousYear);

            t.Rows[3].Cells[0].Paragraphs.First().Append(PARAGRAPH_EXPENDED_VALUE_ON_BASE_YEAR);
            t.Rows[3].Cells[1].Paragraphs.First().Append(investmentsHR.ExpendedValueOnBaseYear);

            t.Rows[4].Cells[0].Paragraphs.First().Append(PARAGRAPH_TOTAL_COMPROMISED_ON_BASE_YEAR);
            t.Rows[4].Cells[1].Paragraphs.First().Append(investmentsHR.ValidTotalCompromisedOnBaseYear);

            doc.InsertTable(t);


            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");

            rows = 15;
            t = doc.AddTable(rows, 3);
            t.Alignment = Alignment.left;

            w = new float[] { 60.0f, 20.0f, 20.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_RUBRICA);
            t.Rows[0].Cells[1].Paragraphs.First().Append(PARAGRAPH_RUBRICA_TOTAL);
            t.Rows[0].Cells[2].Paragraphs.First().Append(PARAGRAPH_RUBRICA_PERCENTAGE);

            t.Rows[1].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES);
            t.Rows[1].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearReceivedResourcesTotal);
            t.Rows[1].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearReceivedResourcesPercentage);

            t.Rows[2].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_ANTICIPATED_RESOURCES);
            t.Rows[2].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearAnticipatedResourcesTotal);
            t.Rows[2].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearAnticipatedResourcesPercentage);

            t.Rows[3].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_DIRECT_HR);
            t.Rows[3].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearDirectHRTotal);
            t.Rows[3].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearDirectHRPercentage);

            t.Rows[4].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_INDIRECT_HR);
            t.Rows[4].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearIndirectHRTotal);
            t.Rows[4].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearIndirectHRPercentage);

            t.Rows[5].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_EQUIPMENT);
            t.Rows[5].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearEquipmentTotal);
            t.Rows[5].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearEquipmentPercentage);

            t.Rows[6].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_CIVIL);
            t.Rows[6].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearCivilTotal);
            t.Rows[6].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearCivilPercentage);

            t.Rows[7].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_TRAVEL);
            t.Rows[7].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearTravelTotal);
            t.Rows[7].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearTravelPercentage);

            t.Rows[8].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_MATERIAL);
            t.Rows[8].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearMaterialTotal);
            t.Rows[8].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearMaterialPercentage);

            t.Rows[9].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_TRAINING);
            t.Rows[9].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearTrainingTotal);
            t.Rows[9].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearTrainingPercentage);

            t.Rows[10].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_BOOKS);
            t.Rows[10].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearBooksTotal);
            t.Rows[10].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearBooksPercentage);

            t.Rows[11].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_SERVICES);
            t.Rows[11].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearServicesTotal);
            t.Rows[11].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearServicesPercentage);

            t.Rows[12].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_OTHER);
            t.Rows[12].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearOtherTotal);
            t.Rows[12].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearOtherPercentage);

            t.Rows[13].Cells[0].Paragraphs.First().Append(PARAGRAPH_BASE_YEAR_RECEIVED_RESOURCES_INSTITUTION);
            t.Rows[13].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearInstitutionTotal);
            t.Rows[13].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearInstitutionPercentage);

            t.Rows[14].Cells[0].Paragraphs.First().Append(PARAGRAPH_RUBRICA_REMAINING);
            t.Rows[14].Cells[1].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearRemainingTotal);
            t.Rows[14].Cells[2].Paragraphs.First().Append(m_RDASectionView.baseYearHRInvestments.BaseYearRemainingPercentage);

            doc.InsertTable(t);


            //Linha em branco
            oParagraph = new RDAParagraph(doc);
            oParagraph.AddText("");


            //DESCRIÇÃO DO INVESTIMENTO
            //RECURSOS HUMANOS DIRETOS
            oSection = new RDASection(doc);
            oSection.AddText(SEC_INVESTMENT_DESCRIPTION);

            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_DIRECT_HR);


            //Lista de Atividades do Ano base por RH Direto
            iIndex = 0;
            var directHRList =  m_RDASectionView.HumanResources.List.Where(i => i.Type == Constants.HRType.DirectHR);
            foreach (var directHR in directHRList)
            {
                oParagraph = new RDAParagraph(doc, oSubSection);
                oParagraph.AddText("");

                iIndex++;
                string sText = iIndex.ToString() + ". " + PARAGRAPH_DIRECTHR_NAME + directHR.Name;

                oParagraph = new RDAParagraph(doc, oSubSection);
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_CPF + " " + directHR.CPF;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_EDUCATION_LEVEL + " " + directHR.EducationLevel;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_EDUCATION + " " + directHR.Education;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_ROLE + " " + directHR.ProjectRole;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_HOURS + " " + directHR.ProjectHours;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_EXPENSES + " " + directHR.Expenses;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_START + " " + directHR.StartDate.ToShortDateString() + " " +
                    PARAGRAPH_DIRECTHR_PROJECT_END + " " + directHR.EndDate.ToShortDateString();
                oParagraph.AddText(sText);

                //Atividades do ano base para o RH
                oParagraph.AddText(PARAGRAPH_DIRECTHR_ACTIVITIES);

                char c = 'a';
                foreach (var activity in directHR.GetActivitiesList())
                {
                    //Nome da atividade
                    sText = c.ToString() + ") " + activity.ShortName + ": "; //Talvez seja melhor criar um "short name" com o padrão "Atividade [AT10]" por exemplo
                    c++;

                    oParagraph.AddText(sText);

                    //Descrição da atividade
                    //Convertendo RTB para plain text
                    TextRange textRange = new TextRange(
                    // TextPointer to the start of content in the RichTextBox.
                    activity.Description.Document.ContentStart,
                    // TextPointer to the end of content in the RichTextBox.
                    activity.Description.Document.ContentEnd);

                    sText = textRange.Text;

                    oParagraph.AppendText(sText);

                    //Linha em branco
                    oParagraph.AddText("");
                }
            }


            //RECURSOS HUMANOS INDIRETOS
            oSubSection = new RDASection(doc, oSection);
            oSubSection.AddText(SUBSEC_INDIRECT_HR);


            //Lista de Atividades do Ano base por RH Direto
            iIndex = 0;
            var indirectHRList = m_RDASectionView.HumanResources.List.Where(i => i.Type == Constants.HRType.IndirectHR);
            foreach (var indirectHR in indirectHRList)
            {
                oParagraph = new RDAParagraph(doc, oSubSection);
                oParagraph.AddText("");

                iIndex++;
                string sText = iIndex.ToString() + ". " + PARAGRAPH_DIRECTHR_NAME + indirectHR.Name;

                oParagraph = new RDAParagraph(doc, oSubSection);
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_CPF + " " + indirectHR.CPF;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_EDUCATION_LEVEL + " " + indirectHR.EducationLevel;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_EDUCATION + " " + indirectHR.Education;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_ROLE + " " + indirectHR.ProjectRole;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_HOURS + " " + indirectHR.ProjectHours;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_EXPENSES + " " + indirectHR.Expenses;
                oParagraph.AddText(sText);

                sText = PARAGRAPH_DIRECTHR_PROJECT_START + " " + indirectHR.StartDate.ToShortDateString() + " " +
                    PARAGRAPH_DIRECTHR_PROJECT_END + " " + indirectHR.EndDate.ToShortDateString();
                oParagraph.AddText(sText);

                //Atividades do ano base para o RH
                oParagraph.AddText(PARAGRAPH_DIRECTHR_ACTIVITIES);

                char c = 'a';
                foreach (var activity in indirectHR.GetActivitiesList())
                {
                    //Nome da atividade
                    sText = c.ToString() + ") " + activity.ShortName + ": "; //Talvez seja melhor criar um "short name" com o padrão "Atividade [AT10]" por exemplo
                    c++;

                    oParagraph.AddText(sText);

                    //Descrição da atividade
                    //Convertendo RTB para plain text
                    TextRange textRange = new TextRange(
                    // TextPointer to the start of content in the RichTextBox.
                    activity.Description.Document.ContentStart,
                    // TextPointer to the end of content in the RichTextBox.
                    activity.Description.Document.ContentEnd);

                    sText = textRange.Text;

                    oParagraph.AppendText(sText);

                    //Linha em branco
                    oParagraph.AddText("");
                }
            }


            //SEÇÃO 23.	CRONOGRAMA DE ATIVIDADES EXECUTADAS NO ANO BASE
            oSection = new RDASection(doc);
            oSection.AddText(SEC_BASE_YEAR_SCHEDULE);

            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText("");

            //Lista das Etapas e Atividades 
            rows = m_RDASectionView.BaseYearSchedule.List.Count;
            t = doc.AddTable(rows+1, 3); //adicionando uma linha para o título
            t.Alignment = Alignment.left;

            w = new float[] { 5.0f, 65.0f, 30.0f };
            t.SetWidthsPercentage(w);

            t.Rows[0].Cells[0].Paragraphs.First().Append(PARAGRAPH_NUMBER);
            t.Rows[0].Cells[1].Paragraphs.First().Append(PARAGRAPH_STEP_DECRIPTION);
            t.Rows[0].Cells[2].Paragraphs.First().Append(PARAGRAPH_EXECUTION_SCHEDULE);

            for (int i = 1; i < rows; i++)
            {
                var item = m_RDASectionView.BaseYearSchedule.List[i];

                t.Rows[i].Cells[0].Paragraphs.First().Append(item.Index);
                t.Rows[i].Cells[1].Paragraphs.First().Append(item.Name);
                t.Rows[i].Cells[2].Paragraphs.First().Append(item.StartDate.Value.ToShortDateString() + " a " + item.EndDate.Value.ToShortDateString());
            }
            doc.InsertTable(t);

            //Linha em branco
            oParagraph = new RDAParagraph(doc, oSection);
            oParagraph.AddText("");

            //GERANDO SUBSEÇÕES COM BULLETS (DÁ MAIS TRABALHO, EU NAO RECOMENDO)
            /*
            CustomParagraph sRichtText;

            Formatting f = new Formatting();
            f.Bold = true;

            //SUBSEÇÃO INTRODUÇÃO
            var bulletedList = doc.AddList(SUBSEC_INTRODUCTION, 1, ListItemType.Bulleted, null, false, false, f);
            doc.InsertList(bulletedList);

            sRichtText = new CustomParagraph(doc, oSection);
            sRichtText.InsertParagraph(txtIntroduction);

            //SUBSEÇÃO MOTIVAÇÕES
            bulletedList = doc.AddList(SUBSEC_MOTIVATIONS, 1, ListItemType.Bulleted, null, false, false, f);
            doc.InsertList(bulletedList);

            sRichtText = new CustomParagraph(doc, oSection);
            sRichtText.InsertParagraph(txtMotivation);

            //SUBSEÇÃO OBJETIVOS
            bulletedList = doc.AddList(SUBSEC_OBJECTIVES, 1, ListItemType.Bulleted, null, false, false, f);
            doc.InsertList(bulletedList);

            sRichtText = new CustomParagraph(doc, oSection);
            sRichtText.InsertParagraph(txtObjectives);
            */

            /*
             Geração de RDA - END 
             */

            doc.Save();
            lblStatus.Content = @"Arquivo gerado com sucesso";
        }

        private void btGenerateDebug_Click(object sender, RoutedEventArgs e)
        {
            string fileName = txtPath.Text + @"\" + txtFileName.Text;

            var doc = DocX.Create(fileName);

            //Testes de estilos 
            //Title  
            string title = "Titulo do documento";

            //Text  
            string textParagraph = "" + "Dear Friends, " + Environment.NewLine +
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                Environment.NewLine + "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";

            //Formatting Title  
            Formatting titleFormat = new Formatting();

            //Specify font family  
            titleFormat.FontFamily = new Font("Batang");
            //Specify font size  
            titleFormat.Size = 18;
            titleFormat.Position = 40;
            titleFormat.FontColor = System.Drawing.Color.Orange;
            titleFormat.UnderlineColor = System.Drawing.Color.Gray;
            titleFormat.Italic = true;

            //Formatting Text Paragraph  
            Formatting textParagraphFormat = new Formatting();
            //font family  
            textParagraphFormat.FontFamily = new Font("Century Gothic");
            //font size  
            textParagraphFormat.Size = 10;
            //Spaces between characters  
            textParagraphFormat.Spacing = 2;

            //Custom Paragraph
            RDABaseText oParagraph = new RDABaseText(doc);
            oParagraph.Add("Parágrafo 1 - Lorem ipsum dolor sit amet, consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ");
            oParagraph.Add();

            CustomParagraph sText2 = new CustomParagraph(doc);
            sText2.InsertParagraph(txtContent);
            //oParagraph.Add("Parágrafo 2 " + sText2);

            //Document generation
            //Insert title  
            Xceed.Document.NET.Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;
            //Insert text  
            doc.InsertParagraph(textParagraph, false, textParagraphFormat);


            //Add Table
            //Create Table with 2 rows and 4 columns.  
            Xceed.Document.NET.Table t = doc.AddTable(2, 4);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.ColorfulList;
            //Fill cells by adding text.  
            t.Rows[0].Cells[0].Paragraphs.First().Append("AA");
            t.Rows[0].Cells[1].Paragraphs.First().Append("BB");
            t.Rows[0].Cells[2].Paragraphs.First().Append("CC");
            t.Rows[0].Cells[3].Paragraphs.First().Append("DD");
            t.Rows[1].Cells[0].Paragraphs.First().Append("EE");
            t.Rows[1].Cells[1].Paragraphs.First().Append("FF");
            t.Rows[1].Cells[2].Paragraphs.First().Append("GG");
            t.Rows[1].Cells[3].Paragraphs.First().Append("HH");
            doc.InsertTable(t);

            //Add link
            Xceed.Document.NET.Hyperlink url = doc.AddHyperlink("Google Web Site", new Uri("http://www.google.com"));
            Xceed.Document.NET.Paragraph p1 = doc.InsertParagraph();
            p1.AppendLine("Please check ").Bold().AppendHyperlink(url);

            doc.Save();
            lblStatus.Content = @"Arquivo gerado com sucesso";
        }


        private void btOpen_Click(object sender, RoutedEventArgs e)
        {
            string fileName = txtPath.Text + @"\" + txtFileName.Text;

            lblStatus.Content = @"Abrindo documento " + fileName + @"...";
            Process.Start("WINWORD.EXE", fileName);
        }

        private void btAddAgreement_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.Agreements.List.Add(new AgreementDescriptor(txtAgreementNumber.Text, txtAgreementStartDate.Text, txtAgreementEndDate.Text));
            //lvAgreements.ItemsSource = Agreements;                 
        }

        private void btRemoveSelectedAgreement_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.Agreements.List.RemoveAt(lvAgreements.SelectedIndex);
        }

        private void btRemoveAllAgreement_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.Agreements.List.Clear();
        }

        private void btUpdateAgreement_Click(object sender, RoutedEventArgs e)
        {
            var item = m_RDASectionView.Agreements.List.FirstOrDefault(i => i.AgreementNumber == txtAgreementNumber.Text);// [lvAgreements.SelectedIndex];
            if (item != null)
            {
                item.AgreementNumber = txtAgreementNumber.Text;
                item.StartDate = txtAgreementStartDate.Text;
                item.EndDate = txtAgreementEndDate.Text;
            }

            lvAgreements.Items.Refresh();
        }

        private void lvAgreements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = m_RDASectionView.Agreements.List[lvAgreements.SelectedIndex];
            txtAgreementNumber.Text = item.AgreementNumber;
            txtAgreementStartDate.Text = item.StartDate;
            txtAgreementEndDate.Text = item.EndDate;
        }

        private void cbProjectIP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProjectIP.SelectedValue.ToString() == "Sim")
            {
                //enable
                txtProjectIPDesc.IsEnabled = true;
                txtProjectIPDate.IsEnabled = true;
                txtProjectIPLocal.IsEnabled = true;
                txtProjectIPRegister.IsEnabled = true;
                txtProjectIPType.IsEnabled = true;

                lvProjectIPList.IsEnabled = true;
                btAddIP.IsEnabled = true;
                btUpdateIP.IsEnabled = true;
                btRemoveAllIP.IsEnabled = true;
                btRemoveSelectedIP.IsEnabled = true;
            }
            else
            {
                //disable
                txtProjectIPDesc.IsEnabled = false;
                txtProjectIPDate.IsEnabled = false;
                txtProjectIPLocal.IsEnabled = false;
                txtProjectIPRegister.IsEnabled = false;
                txtProjectIPType.IsEnabled = false;

                lvProjectIPList.IsEnabled = false;
                btAddIP.IsEnabled = false;
                btUpdateIP.IsEnabled = false;
                btRemoveAllIP.IsEnabled = false;
                btRemoveSelectedIP.IsEnabled = false;

                //Limpa dados
                txtProjectIPDesc.Text = "xxxxxxxxxx";
                txtProjectIPDate.Text = "xx/xx/xxxx";
                txtProjectIPLocal.Text = "xxxxxxxxxx";
                txtProjectIPRegister.Text = "xxxxxxxxxx";
                txtProjectIPType.Text = "xxxxxxxxxx";

            }
        }

        private void btAddIP_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.ProjectIPs.List.Add(new ProjectIPDescriptor(txtProjectIPDesc.Text, txtProjectIPType.Text,
                txtProjectIPRegister.Text, txtProjectIPDate.Text, txtProjectIPLocal.Text));
        }

        private void btUpdateIP_Click(object sender, RoutedEventArgs e)
        {
            var item = m_RDASectionView.ProjectIPs.List[lvProjectIPList.SelectedIndex] as ProjectIPDescriptor;

            if (item != null)
            {
                item.Description = txtProjectIPDesc.Text;
                item.Type = txtProjectIPType.Text;
                item.Register = txtProjectIPRegister.Text;
                item.Date = txtProjectIPDate.Text;
                item.Local = txtProjectIPLocal.Text;
            }

            lvProjectIPList.Items.Refresh();
        }

        private void lvProjectIPList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = m_RDASectionView.ProjectIPs.List[lvProjectIPList.SelectedIndex] as ProjectIPDescriptor;

            if (item != null)
            {
                txtProjectIPDesc.Text = item.Description;
                txtProjectIPType.Text = item.Type;
                txtProjectIPRegister.Text = item.Register;
                txtProjectIPDate.Text = item.Date;
                txtProjectIPLocal.Text = item.Local;
            }
        }

        private void btRemoveAllIP_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.ProjectIPs.List.Clear();
        }

        private void btRemoveSelectedIP_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.ProjectIPs.List.RemoveAt(lvProjectIPList.SelectedIndex);
        }

        private void btAddProjectStep_Click(object sender, RoutedEventArgs e)
        {
            ProjectStepDescriptor item = new ProjectStepDescriptor(txtProjectStepName.Text, txtProjectStepDescription.Text);
            m_RDASectionView.ProjectSteps.AddProjectStep(item);
        }

        private void btAddProjectActivity_Click(object sender, RoutedEventArgs e)
        {
            if (lvProjectSteps.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma Etapa para conter esta atividade", "ERRO", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var parentStep = lvProjectSteps.SelectedItem as ProjectStepDescriptor;

            if (parentStep != null)
            {
                ProjectActivityDescriptor item = new ProjectActivityDescriptor(parentStep.Id, txtProjectActivityName.Text, txtProjectActivityDescription.Text,
                    dateProjectActivityStart.SelectedDate, dateProjectActivityEnd.SelectedDate);

                //Obtem indice global da atividade
                int gIndex = m_RDASectionView.ProjectSteps.GetGlobalActivityIndex();
                item.GlobalIndex = gIndex + 1;

                //Inserindo a atividade na etapa "pai"            
                parentStep.RegisterActivity(item);

                //Atualiza a lista COMPLETA DE ATIVIDADES
                m_RDASectionView.ProjectFullActivitiesList.Clear();
                m_RDASectionView.ProjectFullActivitiesList.AddRange(m_RDASectionView.ProjectSteps.GetFullActivitiesList());

                //Atualizar a lista linkada à listview
                m_RDASectionView.ProjectActivities.UpdateActivitiesListView(parentStep);
            }

            //Atualiza o List View de etapas (porque as datas podem ter mudado)
            lvProjectSteps.Items.Refresh();
        }

        private void btUpdateProjectStep_Click(object sender, RoutedEventArgs e)
        {
            var selItem = lvProjectSteps.SelectedItem as ProjectStepDescriptor;

            if (selItem != null)
            {
                var item = m_RDASectionView.ProjectSteps.List.FirstOrDefault(i => i.Id == selItem.Id);
                if (item != null)
                {
                    item.Name = txtProjectStepName.Text;
                    item.Description = txtProjectStepDescription.Text;
                }
            }

            lvProjectSteps.Items.Refresh();
        }

        private void btUpdateProjectActivity_Click(object sender, RoutedEventArgs e)
        {
            //Item do listview
            var selItem = lvProjectActivities.SelectedItem as ProjectActivityDescriptor;

            if (selItem != null)
            {
                //Atualiza item do model
                var item = m_RDASectionView.ProjectActivities.List.FirstOrDefault(i => i.Id == selItem.Id);
                if (item != null)
                {
                    item.Name = txtProjectActivityName.Text;
                    item.Description = txtProjectActivityDescription.Text;
                    item.StartDate = dateProjectActivityStart.SelectedDate;
                    item.EndDate = dateProjectActivityEnd.SelectedDate;
                }

                //Atualiza as datas no objeto pai (lista de Etapas)
                var parentStep = m_RDASectionView.ProjectSteps.List.Single(i => i.Id == item.StepId);

                //Atualiza a lista COMPLETA DE ATIVIDADES
                m_RDASectionView.ProjectFullActivitiesList.Clear();
                m_RDASectionView.ProjectFullActivitiesList.AddRange(m_RDASectionView.ProjectSteps.GetFullActivitiesList());

                parentStep?.UpdateDates();
            }

            //Atualiza a interface gráfica
            lvProjectActivities.Items.Refresh();
            lvProjectSteps.Items.Refresh();
        }

        private void lvProjectSteps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selItem = lvProjectSteps.SelectedItem as ProjectStepDescriptor;

            if (selItem != null)
            {
                //Atualizar a lista linkada à listview
                m_RDASectionView.ProjectActivities.UpdateActivitiesListView(selItem);

                //Atualiza os campos com o item selecionado
                txtProjectStepName.Text = selItem.Name;
                txtProjectStepDescription.Text = selItem.Description;
            }

            //Atualiza o listView
            lvProjectActivities.Items.Refresh();
        }

        private void lvProjectActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selItem = lvProjectActivities.SelectedItem as ProjectActivityDescriptor;

            if (selItem != null)
            {
                txtProjectActivityName.Text = selItem.Name;
                txtProjectActivityDescription.Text = selItem.Description;
                dateProjectActivityStart.SelectedDate = selItem.StartDate;
                dateProjectActivityEnd.SelectedDate = selItem.EndDate;
            }
            else
            {
                txtProjectActivityName.Text = "";
                txtProjectActivityDescription.Text = "";
                dateProjectActivityStart.SelectedDate = null;
                dateProjectActivityEnd.SelectedDate = null;
            }
        }

        private void btAddHR_Click(object sender, RoutedEventArgs e)
        {
            var item = new HumanResource(txtHRName.Text, txtHRCPF.Text, txtHREducationLevel.Text, txtHREducation.Text, m_RDASectionView.HumanResourceType,
                txtHRProjectRole.Text, float.Parse(txtHRProjectHours.Text), dateHRProjectStart.SelectedDate,
                dateHRProjectEnd.SelectedDate, txtHRProjectExpenses.Text);

            m_RDASectionView.HumanResources.List.Add(item);
        }

        private void btUpdateHR_Click(object sender, RoutedEventArgs e)
        {
            var item = m_RDASectionView.HumanResources.List[lvHRs.SelectedIndex] as HumanResource;

            if (item != null)
            {
                item.Name = txtHRName.Text;
                item.CPF = txtHRCPF.Text;
                item.EducationLevel = txtHREducationLevel.Text;
                item.Education = txtHREducation.Text;
                item.ProjectRole = txtHRProjectRole.Text;
                item.ProjectHours = float.Parse(txtHRProjectHours.Text);
                item.StartDate = dateHRProjectStart.SelectedDate ?? DateTime.Now;
                item.EndDate = dateHRProjectEnd.SelectedDate ?? DateTime.Now;
                item.Expenses = txtHRProjectExpenses.Text;
            }

            //Atualiza a interface grafica
            lvHRs.Items.Refresh();
        }

        private void lvHR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = lvHRs.SelectedItem as HumanResource;

            //Acho que o ideal é fazer binding e preencher sempre as variaveis via binding
            //Neste caso teríamos que ter descritores de "current selection" para cada tab
            if (item != null)
            {
                txtHRName.Text = item.Name;
                txtHRCPF.Text = item.CPF;
                txtHREducationLevel.Text = item.EducationLevel;
                txtHREducation.Text = item.Education;
                txtHRProjectRole.Text = item.ProjectRole;
                txtHRProjectHours.Text = item.ProjectHours.ToString();
                dateHRProjectStart.SelectedDate = item.StartDate;
                dateHRProjectEnd.SelectedDate = item.EndDate;
                txtHRProjectExpenses.Text = item.Expenses;
                m_RDASectionView.HumanResourceType = item.Type;
                //parece que radio button nao funciona com two-way binding direito
                rbDirectHR.IsChecked = false;
                rbIndirectHR.IsChecked = false;

                if (item.Type == Constants.HRType.DirectHR)
                {
                    rbDirectHR.IsChecked = true;
                }
                else
                {
                    rbIndirectHR.IsChecked = true;
                }
            }
        }

        private void btRemoveSelectedHR_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.HumanResources.List.RemoveAt(lvHRs.SelectedIndex);
        }

        private void btRemoveAllHR_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.HumanResources.List.Clear();
        }


        //Tela de Atividades de RH Direto
        private void cbHR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selName = cbHR.SelectedValue as string;

            //Seleciona o HR
            var hr = m_RDASectionView.HumanResources.List.Single(i => i.Name == selName);

            //Atualiza a lista de atividades daquele HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(hr);

            //Atualiza GUI
            lvDirectHRActivities.Items.Refresh();
        }

        private void btRemoveSelectedDirectHRActivity_Click(object sender, RoutedEventArgs e)
        {
            //Temos que remover a atividade do objeto que a contém
            string selName = cbHR.SelectedValue as string;

            //Seleciona o HR
            var hr = m_RDASectionView.HumanResources.List.Single(i => i.Name == selName);

            //Id da atividade selecionada no Listview
            var id = m_RDASectionView.DirectHRActivities.List[lvHRs.SelectedIndex].Id;

            hr.UnregisterActivity(id);

            //Atualiza a lista de atividades daquele HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(hr);

            //Atualiza GUI
            lvDirectHRActivities.Items.Refresh();
        }

        private void btRemoveAllDirectHRAcitvities_Click(object sender, RoutedEventArgs e)
        {
            //Temos que remover a atividade do objeto que a contém
            //Seleciona o HR
            string selName = cbHR.SelectedValue as string;
            var hr = m_RDASectionView.HumanResources.List.Single(i => i.Name == selName);

            hr.UnregisterAllActivities();

            //Atualiza a lista de atividades daquele HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(hr);

            //Atualiza GUI
            lvDirectHRActivities.Items.Refresh();
        }

        private void btAddDirectHRActivity_Click(object sender, RoutedEventArgs e)
        {
            //Informações do RH selecionado na tela
            string selHRName = cbHR.SelectedValue as string;
            HumanResource hr = m_RDASectionView.HumanResources.List.Single(i => i.Name == selHRName);

            //Cria a atividade
            ProjectActivityDescriptor selActivity = cbFullActivitiesList.SelectedItem as ProjectActivityDescriptor;
            Guid selActivityId = (Guid) cbFullActivitiesList.SelectedValue; //tem que verificar se a guid é RECRIADA com o mesmo valor do string
            HumanResourceActivity activity = new HumanResourceActivity(selActivityId, selActivity.FullActivityName, selActivity.ShortActivityName, txtDirectHRActivityDescription);

            TextRange textRange = new TextRange(txtDirectHRActivityDescription.Document.ContentStart, txtDirectHRActivityDescription.Document.ContentEnd);
            activity.DescriptionDummy = textRange.Text;

            //Insere as atividade naquele HR
            hr.RegisterActivity(selActivityId, activity);

            //Atualiza a lista de atividades daquele HR
            m_RDASectionView.DirectHRActivities.UpdateActivitiesListView(hr);

            //Atualiza GUI
            lvDirectHRActivities.Items.Refresh();
        }

        private void lvDirectHRActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HumanResourceActivity selHRActivity = m_RDASectionView.DirectHRActivities.List.ElementAtOrDefault(lvDirectHRActivities.SelectedIndex);

            if (selHRActivity == null)
                return;

            //Atualiza o combo da tela para exibir a atividade selecionada.
            var selActivity = m_RDASectionView.ProjectFullActivitiesList.Find(i => i.FullActivityName == selHRActivity.Name);
            cbFullActivitiesList.SelectedIndex = cbFullActivitiesList.Items.IndexOf(selActivity);
        }

        private void cbFullActivitiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Guid id = (Guid)cbFullActivitiesList.SelectedValue;

            //Seleciona o HR
            string selName = cbHR.SelectedValue as string;
            var hr = m_RDASectionView.HumanResources.List.Single(i => i.Name == selName);

            var selHRActivity = hr.GetActivityById(id);

            if (selHRActivity == null)
                return;

            //Atualiza o RichTextBox com a descrição
            //Copiando o conteudo de um ritchTextBox para outro
            var rtfText = GetRtfStringFromRichTextBox(selHRActivity.Description);
            SetRichTextBoxFromRtfString(rtfText, ref txtDirectHRActivityDescription);
        }

        //O ideal é ter essas duas transformações como serviço que fica disponivel e assim as classes model nao precisarão ter objetos RichTextBox
        //(o problema é que teriamos que criar uma classe especial para podermos saber que um string é RTF ou string comum, para nao misturar)
        public static string GetRtfStringFromRichTextBox(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            MemoryStream ms = new MemoryStream();
            textRange.Save(ms, DataFormats.Rtf);

            return Encoding.Default.GetString(ms.ToArray());
        }

        public static void SetRichTextBoxFromRtfString(string richTextString, ref RichTextBox richTextBox)
        {
            FlowDocument fd = new FlowDocument();
            MemoryStream ms = new MemoryStream(Encoding.ASCII.GetBytes(richTextString));
            TextRange textRange = new TextRange(fd.ContentStart, fd.ContentEnd);
            textRange.Load(ms, DataFormats.Rtf);
            richTextBox.Document = fd;
        }

        private void btLoadBaseYearActivities_Click(object sender, RoutedEventArgs e)
        {
            //Obtendo a lista das atividades realizadas no ano base
            //Se a atividade INICIA no ano base ou TERMINA no ano base, será incluida
            //Se a atividade nao inicia e nem termina no ano base, mas o ano base está incluido no intervalo inicio < ano-base < termino
            //a atividade sera incluida 

            DateTime baseYear = new DateTime(int.Parse(txtBaseYear.Text), 1, 1);
            m_RDASectionView.BaseYearActivities.UpdateBaseYearActivitiesList(baseYear, m_RDASectionView.ProjectSteps.List.ToList<ProjectStepDescriptor>());

            lvBaseYearActivities.Items.Refresh();
        }

        private void btAddBaseYearActivity_Click(object sender, RoutedEventArgs e)
        {
            if(lvBaseYearActivities.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma atividade do ano base primeiro!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var selBaseYearActivity = m_RDASectionView.BaseYearActivities.List[lvBaseYearActivities.SelectedIndex];

            //Atualiza o RichTextBox com a descrição
            //Copiando o conteudo de um ritchTextBox para outro
            selBaseYearActivity.BaseYearDescription = txtBaseYearActivityDescription;
            selBaseYearActivity.BaseYearResults = txtBaseYearActivityResults;           
        }

        private void lvBaseYearActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selBaseYearActivity = m_RDASectionView.BaseYearActivities.List[lvBaseYearActivities.SelectedIndex];

            //Atualiza o RichTextBox com a descrição
            //Copiando o conteudo de um ritchTextBox para outro
            txtBaseYearActivityDescription.Document.Blocks.Clear();
            if (selBaseYearActivity.BaseYearDescription != null)
            {
                var rtfText = GetRtfStringFromRichTextBox(selBaseYearActivity.BaseYearDescription);
                SetRichTextBoxFromRtfString(rtfText, ref txtBaseYearActivityDescription);
            }

            txtBaseYearActivityResults.Document.Blocks.Clear();
            if (selBaseYearActivity.BaseYearResults != null)
            {
                var rtfText = GetRtfStringFromRichTextBox(selBaseYearActivity.BaseYearResults);
                SetRichTextBoxFromRtfString(rtfText, ref txtBaseYearActivityResults);
            }
        }

        private void btAddExpenses_Click(object sender, RoutedEventArgs e)
        {
            var item = new BaseYearExpensesDescriptor(txtBaseYearValidTotalExpenses.Text, txtBaseYearEquipmentSoftware.Text, txtBaseYearMaterialExpenses.Text,
                txtBaseYearBooksExpenses.Text, txtBaseYearInstitutionExpenses.Text, txtBaseYearServicesExpenses.Text,
                txtBaseYearOtherExpenses.Text, txtBaseYearTotalWithoutHRExpenses.Text,
                txtBaseYearTotalExpenses.Text, txtBaseYearCivilProjectsExpenses.Text, txtBaseYearTravelExpenses.Text, txtBaseYearTrainingExpenses.Text);

            m_RDASectionView.BaseYearExpenses.List.Add(item);
        }

        private void btUpdateExpenses_Click(object sender, RoutedEventArgs e)
        {
            var selBaseYearExpenses = m_RDASectionView.BaseYearExpenses.List[lvBaseYearExpenses.SelectedIndex];

            //seria bom fazer binding com algum objeto
            if (selBaseYearExpenses != null)
            {
                selBaseYearExpenses.ValidTotalExpenses = txtBaseYearValidTotalExpenses.Text;
                selBaseYearExpenses.EquipmentAndSoftware = txtBaseYearEquipmentSoftware.Text;
                selBaseYearExpenses.Material = txtBaseYearMaterialExpenses.Text;
                selBaseYearExpenses.Books = txtBaseYearBooksExpenses.Text;
                selBaseYearExpenses.InstitutionExpenses = txtBaseYearInstitutionExpenses.Text;
                selBaseYearExpenses.Services = txtBaseYearServicesExpenses.Text;
                selBaseYearExpenses.Other = txtBaseYearOtherExpenses.Text;
                selBaseYearExpenses.TotalWithoutHR = txtBaseYearTotalWithoutHRExpenses.Text;
                selBaseYearExpenses.TotalExpenses = txtBaseYearTotalExpenses.Text;
                selBaseYearExpenses.CivilProjects = txtBaseYearCivilProjectsExpenses.Text;
                selBaseYearExpenses.Travel = txtBaseYearTravelExpenses.Text;
                selBaseYearExpenses.Training = txtBaseYearTrainingExpenses.Text;
            }

            lvBaseYearExpenses.Items.Refresh();
        }

        private void lvBaseYearExpenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selBaseYearExpenses = m_RDASectionView.BaseYearExpenses.List[lvBaseYearExpenses.SelectedIndex];

            //seria bom fazer binding com algum objeto
            if(selBaseYearExpenses != null)
            {
                txtBaseYearValidTotalExpenses.Text = selBaseYearExpenses.ValidTotalExpenses;
                txtBaseYearEquipmentSoftware.Text = selBaseYearExpenses.EquipmentAndSoftware;
                txtBaseYearMaterialExpenses.Text = selBaseYearExpenses.Material;
                txtBaseYearBooksExpenses.Text = selBaseYearExpenses.Books;
                txtBaseYearInstitutionExpenses.Text = selBaseYearExpenses.InstitutionExpenses;
                txtBaseYearServicesExpenses.Text = selBaseYearExpenses.Services;
                txtBaseYearOtherExpenses.Text = selBaseYearExpenses.Other;
                txtBaseYearTotalWithoutHRExpenses.Text = selBaseYearExpenses.TotalWithoutHR;
                txtBaseYearTotalExpenses.Text = selBaseYearExpenses.TotalExpenses;
                txtBaseYearCivilProjectsExpenses.Text = selBaseYearExpenses.CivilProjects;
                txtBaseYearTravelExpenses.Text = selBaseYearExpenses.Travel;
                txtBaseYearTrainingExpenses.Text = selBaseYearExpenses.Training;
            }
        }

        private void btAddUpdateInvestments_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesDirectSuperior = txtQtyEmployeesDirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesDirectMedium = txtQtyEmployeesDirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesIndirectSuperior = txtQtyEmployeesIndirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesIndirectMedium = txtQtyEmployeesIndirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.QtyEmployeesTotal = txtQtyEmployeesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.ValueDirectSuperior = txtValueDirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.ValueDirectMedium = txtValueDirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.ValueIndirectSuperior = txtValueIndirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.ValueIndirectMedium = txtValueIndirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.ValueTotal = txtValueTotal.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursDirectSuperior = txtTotalHoursDirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursDirectMedium = txtTotalHoursDirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursIndirectSuperior = txtTotalHoursIndirectSuperior.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursIndirectMedium = txtTotalHoursIndirectMedium.Text;
            m_RDASectionView.baseYearHRInvestments.TotalHoursTotal = txtTotalHoursTotal.Text;
            m_RDASectionView.baseYearHRInvestments.TotalValuePassedToInstitution = txtTotalValuePassedToInstitution.Text;
            m_RDASectionView.baseYearHRInvestments.AnticipatedValueForNextYear = txtAnticipatedValueForNextYear.Text;
            m_RDASectionView.baseYearHRInvestments.AnticipatedValueFromPreviousYear = txtAnticipatedValueFromPreviousYear.Text;
            m_RDASectionView.baseYearHRInvestments.ExpendedValueOnBaseYear = txtExpendedValueOnBaseYear.Text;
            m_RDASectionView.baseYearHRInvestments.ValidTotalCompromisedOnBaseYear = txtValidTotalCompromisedOnBaseYear.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearReceivedResourcesTotal = txtBaseYearReceivedResourcesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearReceivedResourcesPercentage = txtBaseYearReceivedResourcesPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearAnticipatedResourcesTotal = txtBaseYearAnticipatedResourcesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearAnticipatedResourcesPercentage = txtBaseYearAnticipatedResourcesPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearDirectHRTotal = txtBaseYearDirectHRTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearDirectHRPercentage = txtBaseYearDirectHRPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearIndirectHRTotal = txtBaseYearIndirectHRTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearIndirectHRPercentage = txtBaseYearIndirectHRPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearEquipmentTotal = txtBaseYearEquipmentTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearEquipmentPercentage = txtBaseYearEquipmentPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearCivilTotal = txtBaseYearCivilTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearCivilPercentage = txtBaseYearCivilPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTravelTotal = txtBaseYearTravelTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTravelPercentage = txtBaseYearTravelPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearMaterialTotal = txtBaseYearMaterialTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearMaterialPercentage = txtBaseYearMaterialPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTrainingTotal = txtBaseYearTrainingTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearTrainingPercentage = txtBaseYearTrainingPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearBooksTotal = txtBaseYearBooksTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearBooksPercentage = txtBaseYearBooksPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearServicesTotal = txtBaseYearServicesTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearServicesPercentage = txtBaseYearServicesPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearOtherTotal = txtBaseYearOtherTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearOtherPercentage = txtBaseYearOtherPercentage.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearInstitutionTotal = txtBaseYearInstitutionTotal.Text;
            m_RDASectionView.baseYearHRInvestments.BaseYearInstitutionPercentage = txtBaseYearInstitutionPercentage.Text;
        }

        private void btLoadSchedule_Click(object sender, RoutedEventArgs e)
        {
            m_RDASectionView.BaseYearSchedule.BuildScheduleList(m_RDASectionView.ProjectSteps.List.ToList());
        }
    }
}
