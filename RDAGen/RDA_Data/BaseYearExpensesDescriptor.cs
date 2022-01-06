using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    /// <summary>
    ///  Lista de dispendios para o ListView
    /// </summary>
    public class BaseYearExpensesList
    {
        public ObservableCollection<BaseYearExpensesDescriptor> List { get; set; } = new ObservableCollection<BaseYearExpensesDescriptor>();
    }


    /// <summary>
    /// Classe que descreve dispendios do ano base
    /// </summary>
    public class BaseYearExpensesDescriptor
    {
        public string ValidTotalExpenses { get; set; } //Despesas totais que aparecem no inicio da seção
        public string EquipmentAndSoftware { get; set; }  //Equipamentos e Software

        public string Material { get; set; }              //Material de consumo
        public string Books { get; set; }                 //Livros e Periodicos
        public string InstitutionExpenses { get; set; }   //Custo incorrido pela instituição
        public string Services { get; set; }              //Serviços tecnicos de terceiros
        public string Other { get; set; }                 //Outros correlatos
        public string TotalWithoutHR { get; set; }        //Total de dispendios sem RH
         
        public string TotalExpenses { get; set; }         //Total de dispendios
        public string CivilProjects { get; set; }         //Obras Civis
        public string Travel { get; set; }                //Viagens
        public string Training { get; set; }              //Treinamentos

        public BaseYearExpensesDescriptor()
        {
                
        }

        public BaseYearExpensesDescriptor(string validTotalExpenses, string equipmentAndSoftware, 
            string material, string books, string institutionExpenses, string services, string other, 
            string totalWithoutHR, string totalExpenses, string civilProjects, string travel, string training)
        {
            ValidTotalExpenses = validTotalExpenses;
            EquipmentAndSoftware = equipmentAndSoftware;
            Material = material;
            Books = books;
            InstitutionExpenses = institutionExpenses;
            Services = services;
            Other = other;
            TotalWithoutHR = totalWithoutHR;
            TotalExpenses = totalExpenses;
            CivilProjects = civilProjects;
            Travel = travel;
            Training = training;
        }
    }
}
