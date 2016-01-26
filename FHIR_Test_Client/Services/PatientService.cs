using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;

namespace FHIR_Test_Client.Services
{
    public class PatientService
    {
        private FhirClient _client;

        public PatientService(FhirClient client) { _client = client; }

        public IEnumerable<Patient> GetAllPatients()
        {
            var patients = new List<Patient>();
            int i = 1;
            bool pastientsExist = true;
            while(pastientsExist)
            {
                try
                {
                    var patient = _client.Read<Patient>(i.ToString());
                    patients.Add(patient);
                    i++;
                }
                catch (Exception ex)
                {
                    pastientsExist = false;
                }
            }
            return patients;
        }

        public IEnumerable<Patient> GetPatientsByName(string firstName, string lastName)
        {
            var searchParameters = new SearchParams();
            searchParameters.Add("Given", firstName);
            searchParameters.Add("fFamily", lastName);
            
            var matches = new List<Patient>();
            var result = _client.Search(searchParameters, ResourceType.Patient.ToString());
            return result.Entry.Select(x => (Patient) x.Resource);
        }
    }
}