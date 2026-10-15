namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    // Adapts OutNetworkPatient so it can be used anywhere
    // the InsuranceInterface is expected.
    public class OutNetworkAdapter : InsuranceInterface
    {
        private readonly OutNetworkPatient patient;

        public OutNetworkAdapter(string newName, int newPolicyNumber)
        {
            patient = new OutNetworkPatient(newName, newPolicyNumber);
        }

        public string getPatientName()
        {
            return patient.getPatientName();
        }

        public string getPolicyNumber()
        {
            return patient.PolicyNumber.ToString();
        }

        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            decimal coveragePercent = patient.CoveragePercent(ProcedureCost);
            return coveragePercent * ProcedureCost;
        }

        public bool IsCovered(string patientName, string policyNumber)
        {
            if (!int.TryParse(policyNumber, out int convertedPolicyNumber))
            {
                return false;
            }

            string covered = patient.IsCovered(patientName, convertedPolicyNumber);
            return covered == "yes";
        }
    }
}
