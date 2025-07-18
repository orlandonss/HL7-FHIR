using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Hl7.FhirPath.Expressions;

namespace Project01
{

    public static class FhirProject
    {
        private const string fhirServer = "http://hapi.fhir.org/baseDstu3";
        static void Main(string[] args)
        {
            FhirClient client = new FhirClient(fhirServer)
            {
                Settings =
                {
                    PreferredFormat = ResourceFormat.Json,
                    PreferredReturn = Prefer.ReturnRepresentation
                }
            };

            var parametes = new string[] { "_summary=count" };
            Bundle patientTotal = client.Search<Patient>(parametes);
            Bundle patientBundle = client.Search<Patient>(null);

            countEntries(patientTotal);
            countPatiensInBundle(patientBundle);
            listPatientsInBundle(patientBundle);
            //searchPatientsUrl(patientBundle);
        }


        public static void searchPatientsUrl(Bundle patients)
        {
            int patientNumber = 1;

            foreach (Bundle.EntryComponent entry in patients.Entry)
            {
                Console.WriteLine($"Entry - {patientNumber,3}:{entry.FullUrl}");
                patientNumber++;
            }
        }
        
        public static void listPatientsInBundle(Bundle patients)
        {
            int patientNumber = 1;
            foreach (Bundle.EntryComponent entry in patients.Entry)
            {

                Console.WriteLine($"Entry: {patientNumber}");

                if (entry.Resource != null)
                {
                    Patient temp = (Patient)entry.Resource;
                    Console.WriteLine($"Id:{temp.Id}");
                    if (temp.Name.Count > 0)
                    {
                        Console.WriteLine("Url: " + entry.FullUrl);
                        Console.WriteLine($"Name:{temp.Name[0].ToString()}\n");
                    }
                }
                patientNumber++;
            }
        }
        public static void countEntries(Bundle patients)
        {
            Console.WriteLine($"Total Entries: {patients.Total}\n");
        }
        public static void countPatiensInBundle(Bundle patients)
        {
            Console.WriteLine($"Total Patients in Bundle: {patients.Entry.Count}");
        }
    }
}