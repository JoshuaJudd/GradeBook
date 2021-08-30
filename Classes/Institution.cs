using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.Classes {
    public class Institution {
        public string InstitutionName;
        public string District;

        private readonly Dictionary<InstitutionCode, string> InstitutionNameMap = new();
        private readonly Dictionary<DistrictCode, string> DistrictMap = new();
        
        public Institution(InstitutionCode _name, DistrictCode _district) {
            InitializeInstitutionNameMap();
            InitializeDistrictMap();
            
            InstitutionName = InstitutionNameMap[_name];
            District = DistrictMap[_district];
        }

        private void InitializeInstitutionNameMap() {
            InstitutionNameMap.Add(InstitutionCode.AA,"Accelerated Academy");
            InstitutionNameMap.Add(InstitutionCode.SS,"Schooled In Success");
            InstitutionNameMap.Add(InstitutionCode.MU,"Meadows University");
            InstitutionNameMap.Add(InstitutionCode.WC,"Winters College");
            InstitutionNameMap.Add(InstitutionCode.CS,"Granite Bay School");
            InstitutionNameMap.Add(InstitutionCode.FT,"Forward Thinking");
            InstitutionNameMap.Add(InstitutionCode.GO,"Golden Oak Secondary School");
            InstitutionNameMap.Add(InstitutionCode.EMC,"Schooled In Success");
            InstitutionNameMap.Add(InstitutionCode.ST,"Somerset Technical School");
            InstitutionNameMap.Add(InstitutionCode.EMU,"Eagle Mountain University");
            InstitutionNameMap.Add(InstitutionCode.RH,"Ravenwood High");
            InstitutionNameMap.Add(InstitutionCode.NO,"New Opportunities");
            InstitutionNameMap.Add(InstitutionCode.FA,"Foundations Academy");
            InstitutionNameMap.Add(InstitutionCode.SFA,"Summerfield School of Fine Arts");
            InstitutionNameMap.Add(InstitutionCode.DSH,"Desert Sands High");
            InstitutionNameMap.Add(InstitutionCode.MRS,"Maple Ridge School for Boys");
            InstitutionNameMap.Add(InstitutionCode.CU,"Cypress University");
            InstitutionNameMap.Add(InstitutionCode.CC,"Chalkboard Champions");
            InstitutionNameMap.Add(InstitutionCode.FSS,"Five Star Students");
            InstitutionNameMap.Add(InstitutionCode.OG,"Oakwood Grammar School");
            InstitutionNameMap.Add(InstitutionCode.MLKU,"Martin Luther King University");
            InstitutionNameMap.Add(InstitutionCode.WK,"Westview Kindergarten");
            InstitutionNameMap.Add(InstitutionCode.FS,"Foothill School for Boys");
        }

        private void InitializeDistrictMap() {
            DistrictMap.Add(DistrictCode.HCSD, "Holmes County School District");
            DistrictMap.Add(DistrictCode.JCSD, "Jackson County School District");
            DistrictMap.Add(DistrictCode.LCSD, "Lafayette County School District");
            DistrictMap.Add(DistrictCode.MCSD, "Madison County School District");
        }
    }
}