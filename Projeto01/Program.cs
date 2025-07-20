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

            //needeed to call functions to know about that ;)

        }

        public static void listAllPatientsUrl(FhirClient c ,Bundle patientsBundle)
        {
            int patientNumber = 1;
            while (patientsBundle != null)
            {
                foreach (Bundle.EntryComponent entry in patientsBundle.Entry)
                {
                    Console.WriteLine($"Entry - {patientNumber,3}:{entry.FullUrl}");
                    patientNumber++;
                }
                patientsBundle = c.Continue(patientsBundle);
            }
        }
        
        public static void listBundlePatientsUrl(Bundle patientsBundle)
        {
            int patientNumber = 1;
            foreach (Bundle.EntryComponent entry in patientsBundle.Entry)
            {
                Console.WriteLine($"Entry - {patientNumber,3}:{entry.FullUrl}");
                patientNumber++;
            }
        }
        
        public static void listAllPatientsInBundle(FhirClient c, Bundle patientsBundle)
        {
            int patientNumber = 1;
            while (patientsBundle != null)
            {
                //list each patients in the bundle
                countPatiensInBundle(patientsBundle);
                foreach (Bundle.EntryComponent entry in patientsBundle.Entry)
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
                patientsBundle = c.Continue(patientsBundle);
            }
        }

        public static void listoneBundle(Bundle patientsBundle)
        {
              int patientNumber = 1;
           
                countPatiensInBundle(patientsBundle);

                foreach (Bundle.EntryComponent entry in patientsBundle.Entry)
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

        public static void countEntries(Bundle patientsBundle)
        {
            Console.WriteLine($"Total Entries: {patientsBundle.Total}\n");
        }
        public static void countPatiensInBundle(Bundle patientsBundle)
        {
            Console.WriteLine($"Total Patients in Bundle: {patientsBundle.Entry.Count}");
        }
    }
}