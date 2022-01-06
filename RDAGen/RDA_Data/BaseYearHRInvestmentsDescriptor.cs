using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    /// <summary>
    /// Descreve a tabela Investimento em recursos humanos
    /// </summary>
    public class BaseYearHRInvestmentsDescriptor
    {
        public string QtyEmployeesDirectSuperior { get; set; }
        public string QtyEmployeesDirectMedium { get; set; }
        public string QtyEmployeesIndirectSuperior { get; set; }
        public string QtyEmployeesIndirectMedium { get; set; }
        public string QtyEmployeesTotal { get; set; }

        public string ValueDirectSuperior { get; set; }
        public string ValueDirectMedium { get; set; }
        public string ValueIndirectSuperior { get; set; }
        public string ValueIndirectMedium { get; set; }
        public string ValueTotal { get; set; }

        public string TotalHoursDirectSuperior { get; set; }
        public string TotalHoursDirectMedium { get; set; }
        public string TotalHoursIndirectSuperior { get; set; }
        public string TotalHoursIndirectMedium { get; set; }
        public string TotalHoursTotal { get; set; }

        public string TotalValuePassedToInstitution { get; set; }
        public string AnticipatedValueForNextYear { get; set; }
        public string AnticipatedValueFromPreviousYear { get; set; }
        public string ExpendedValueOnBaseYear { get; set; }
        public string ValidTotalCompromisedOnBaseYear { get; set; }

        public string BaseYearReceivedResourcesTotal { get; set; }
        public string BaseYearReceivedResourcesPercentage { get; set; }
        public string BaseYearAnticipatedResourcesTotal { get; set; }
        public string BaseYearAnticipatedResourcesPercentage { get; set; }

        public string BaseYearDirectHRTotal { get; set; }
        public string BaseYearDirectHRPercentage { get; set; }

        public string BaseYearIndirectHRTotal { get; set; }
        public string BaseYearIndirectHRPercentage { get; set; }

        public string BaseYearEquipmentTotal { get; set; }
        public string BaseYearEquipmentPercentage { get; set; }

        public string BaseYearCivilTotal { get; set; }
        public string BaseYearCivilPercentage { get; set; }

        public string BaseYearTravelTotal { get; set; }
        public string BaseYearTravelPercentage { get; set; }

        public string BaseYearMaterialTotal { get; set; }
        public string BaseYearMaterialPercentage { get; set; }

        public string BaseYearTrainingTotal { get; set; }
        public string BaseYearTrainingPercentage { get; set; }

        public string BaseYearBooksTotal { get; set; }
        public string BaseYearBooksPercentage { get; set; }

        public string BaseYearServicesTotal { get; set; }
        public string BaseYearServicesPercentage { get; set; }

        public string BaseYearOtherTotal { get; set; }
        public string BaseYearOtherPercentage { get; set; }

        public string BaseYearInstitutionTotal { get; set; }
        public string BaseYearInstitutionPercentage { get; set; }

        public string BaseYearRemainingTotal { get => CalcAccumulatedTotal().ToString(); }
        public string BaseYearRemainingPercentage { get => CalcAccumulatedPercentage().ToString(); }


        public float CalcAccumulatedPercentage()
        {
            float fBaseYearRemainingPercentage = float.Parse(BaseYearReceivedResourcesPercentage) +
                              float.Parse(BaseYearAnticipatedResourcesPercentage) +
                              float.Parse(BaseYearDirectHRPercentage) +
                              float.Parse(BaseYearIndirectHRPercentage) +
                              float.Parse(BaseYearEquipmentPercentage) +
                              float.Parse(BaseYearCivilPercentage) +
                              float.Parse(BaseYearTravelPercentage) +
                              float.Parse(BaseYearMaterialPercentage) +
                              float.Parse(BaseYearTrainingPercentage) +
                              float.Parse(BaseYearBooksPercentage) +
                              float.Parse(BaseYearServicesPercentage) +
                              float.Parse(BaseYearOtherPercentage) +
                              float.Parse(BaseYearInstitutionPercentage);

            return fBaseYearRemainingPercentage;
        }

        public float CalcAccumulatedTotal()
        {
            float fBaseYearRemainingTotal = float.Parse(BaseYearReceivedResourcesTotal) +
                         float.Parse(BaseYearAnticipatedResourcesTotal) +
                         float.Parse(BaseYearDirectHRTotal) +
                         float.Parse(BaseYearIndirectHRTotal) +
                         float.Parse(BaseYearEquipmentTotal) +
                         float.Parse(BaseYearCivilTotal) +
                         float.Parse(BaseYearTravelTotal) +
                         float.Parse(BaseYearMaterialTotal) +
                         float.Parse(BaseYearTrainingTotal) +
                         float.Parse(BaseYearBooksTotal) +
                         float.Parse(BaseYearServicesTotal) +
                         float.Parse(BaseYearOtherTotal) +
                         float.Parse(BaseYearInstitutionTotal);

            return fBaseYearRemainingTotal;
        }

        public BaseYearHRInvestmentsDescriptor()
        {

        }

        public BaseYearHRInvestmentsDescriptor(string qtyEmployeesDirectSuperior, string qtyEmployeesDirectMedium, 
            string qtyEmployeesIndirectSuperior, string qtyEmployeesIndirectMedium, string qtyEmployeesTotal, 
            string valueDirectSuperior, string valueDirectMedium, string valueIndirectSuperior, 
            string valueIndirectMedium, string valueTotal, string totalHoursDirectSuperior, 
            string totalHoursDirectMedium, string totalHoursIndirectSuperior, string totalHoursIndirectMedium, 
            string totalHoursTotal, string totalValuePassedToInstitution, string anticipatedValueForNextYear, 
            string anticipatedValueFromPreviousYear, string expendedValueOnBaseYear, 
            string validTotalCompromisedOnBaseYear, string baseYearReceivedResourcesTotal, 
            string baseYearReceivedResourcesPercentage, string baseYearAnticipatedResourcesTotal, 
            string baseYearAnticipatedResourcesPercentage, string baseYearDirectHRTotal, 
            string baseYearDirectHRPercentage, string baseYearIndirectHRTotal, string baseYearIndirectHRPercentage, 
            string baseYearEquipmentTotal, string baseYearEquipmentPercentage, string baseYearCivilTotal, 
            string baseYearCivilPercentage, string baseYearTravelTotal, string baseYearTravelPercentage, 
            string baseYearMaterialTotal, string baseYearMaterialPercentage, string baseYearTrainingTotal,
            string baseYearTrainingPercentage, string baseYearBooksTotal, string baseYearBooksPercentage, 
            string baseYearServicesTotal, string baseYearServicesPercentage, string baseYearOtherTotal, 
            string baseYearOtherPercentage, string baseYearInstitutionTotal, string baseYearInstitutionPercentage)
        {
            QtyEmployeesDirectSuperior = qtyEmployeesDirectSuperior;
            QtyEmployeesDirectMedium = qtyEmployeesDirectMedium;
            QtyEmployeesIndirectSuperior = qtyEmployeesIndirectSuperior;
            QtyEmployeesIndirectMedium = qtyEmployeesIndirectMedium;
            QtyEmployeesTotal = qtyEmployeesTotal;
            ValueDirectSuperior = valueDirectSuperior;
            ValueDirectMedium = valueDirectMedium;
            ValueIndirectSuperior = valueIndirectSuperior;
            ValueIndirectMedium = valueIndirectMedium;
            ValueTotal = valueTotal;
            TotalHoursDirectSuperior = totalHoursDirectSuperior;
            TotalHoursDirectMedium = totalHoursDirectMedium;
            TotalHoursIndirectSuperior = totalHoursIndirectSuperior;
            TotalHoursIndirectMedium = totalHoursIndirectMedium;
            TotalHoursTotal = totalHoursTotal;
            TotalValuePassedToInstitution = totalValuePassedToInstitution;
            AnticipatedValueForNextYear = anticipatedValueForNextYear;
            AnticipatedValueFromPreviousYear = anticipatedValueFromPreviousYear;
            ExpendedValueOnBaseYear = expendedValueOnBaseYear;
            ValidTotalCompromisedOnBaseYear = validTotalCompromisedOnBaseYear;
            
            BaseYearReceivedResourcesTotal = baseYearReceivedResourcesTotal;
            BaseYearReceivedResourcesPercentage = baseYearReceivedResourcesPercentage;
            BaseYearAnticipatedResourcesTotal = baseYearAnticipatedResourcesTotal;
            BaseYearAnticipatedResourcesPercentage = baseYearAnticipatedResourcesPercentage;
            BaseYearDirectHRTotal = baseYearDirectHRTotal;
            BaseYearDirectHRPercentage = baseYearDirectHRPercentage;
            BaseYearIndirectHRTotal = baseYearIndirectHRTotal;
            BaseYearIndirectHRPercentage = baseYearIndirectHRPercentage;
            BaseYearEquipmentTotal = baseYearEquipmentTotal;
            BaseYearEquipmentPercentage = baseYearEquipmentPercentage;
            BaseYearCivilTotal = baseYearCivilTotal;
            BaseYearCivilPercentage = baseYearCivilPercentage;
            BaseYearTravelTotal = baseYearTravelTotal;
            BaseYearTravelPercentage = baseYearTravelPercentage;
            BaseYearMaterialTotal = baseYearMaterialTotal;
            BaseYearMaterialPercentage = baseYearMaterialPercentage;
            BaseYearTrainingTotal = baseYearTrainingTotal;
            BaseYearTrainingPercentage = baseYearTrainingPercentage;
            BaseYearBooksTotal = baseYearBooksTotal;
            BaseYearBooksPercentage = baseYearBooksPercentage;
            BaseYearServicesTotal = baseYearServicesTotal;
            BaseYearServicesPercentage = baseYearServicesPercentage;
            BaseYearOtherTotal = baseYearOtherTotal;
            BaseYearOtherPercentage = baseYearOtherPercentage;
            BaseYearInstitutionTotal = baseYearInstitutionTotal;
            BaseYearInstitutionPercentage = baseYearInstitutionPercentage;

            CalcAccumulatedPercentage();
            CalcAccumulatedTotal();
        }
    }
}