﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace FHIR_Test_Client.Services
{
    public class AllergyService
    {
        private FhirClient _client;

        public AllergyService(FhirClient client) { _client = client; }

        public IEnumerable<AllergyIntolerance> GetAllAllergies()
        {
            var patients = new List<AllergyIntolerance>();
            int i = 1;
            bool pastientsExist = true;
            while (pastientsExist)
            {
                try
                {
                    var patient = _client.Read<AllergyIntolerance>(i.ToString());
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
        public IEnumerable<AllergyIntolerance> GetAllergiesByName(string text)
        {
            var searchParameters = new SearchParams();
            searchParameters.Add("name", text);

            var result = _client.Search(searchParameters, ResourceType.AllergyIntolerance.ToString());
            return result.Entry.Select(s => (AllergyIntolerance)s.Resource);
        }
    }
}