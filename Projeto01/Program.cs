using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;




namespace Project01
{

    public static class FhirProject
    {
        private const string fhirServer = "http://hapi.fhir.org/baseDstu3";
        static void Main(string[] args)
        {
            FhirClient client = new FhirClient(fhirServer)
            {
                PreferredFormat = ResourceFormat.Json,
                PreferredReturn = Prefer.ReturnRepresentation
            };
            Bundle patientBundle = client.Search<Patient>(null);
            Console.WriteLine($"Total:{patientBundle.Total} Entry count: {patientBundle.Entry.Count}");
        }
    }
}