using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen
{
    public static class ReferenceManager
    {
        private static int m_iSectionNumber = 1;

        private static Dictionary<string, int> m_dictSubSections = new Dictionary<string, int>(); //contabiliza quantas subseções uma dada seção "parent" tem

        public static int GetSectionNumber(string parentSection = null)
        {
            int iRet;
            if(parentSection == null)
            {
                iRet = m_iSectionNumber++;//indice geral de seções-raiz
            }
            else
            {
                //usuario quer o proximo indice se subseção cujo pai é parentSection
                iRet = RegisterSubSection(parentSection);
            }
            return iRet;
        }

        public static void ResetCounter()
        {
            m_iSectionNumber = 1;
        }

        public static int RegisterSubSection(string parentSection)
        {
            if(m_dictSubSections.ContainsKey(parentSection))
            {
                m_dictSubSections[parentSection]++;//incrementa indice da subseção cujo pai é parentSection
            }
            else
            {
                m_dictSubSections.Add(parentSection, 1); //primeira subseção cujo pai é parentSection
            }

            return m_dictSubSections[parentSection];
        }
    }
}
