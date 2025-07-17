using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;





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
            Console.WriteLine($"Entry count: {patientBundle.Entry.Count}");

            int patientNumber = 1;
            foreach (Bundle.EntryComponent entry in patientBundle.Entry)
            {
                System.Console.WriteLine($"Entry - {patientNumber,3}:{entry.FullUrl}");
                patientNumber++;

                if (entry.Resource != null)
                {
                    Patient patient = (Patient)entry.Resource;
                    System.Console.WriteLine($"- {patient.Id,20} {patient.Name}");
                }
            }
        }
    }
}