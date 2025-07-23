
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Project01
{
    public static class FhirProject
    {
        private static readonly Dictionary<string, string> fhir_Servers = new Dictionary<string, string>()
        {
            {"PublicHapi","http://hapi.fhir.org/baseDstu3"},
            {"Local","http://localhost:8080/fhir"},
        };
        private static readonly string fhirServer = fhir_Servers["PublicHapi"];
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

            var parameters = new string[] { "_summary=count" };
            var parameters2 = new string[] { "_name=test" };
            Bundle patientTotal = client.Search<Patient>(parameters);
            Bundle patientBundle = client.Search<Patient>(null);
            Bundle patientSearch = client.Search<Patient>(parameters2);

            countEntries(patientTotal);
            countPatiensInBundle(patientBundle);

            Console.WriteLine("\n\n-----LIST ALL PATIENTS-----\n\n");
            listAllPatientsInBundle(client, patientBundle);

            Console.WriteLine("\n\n-----CLIENTS URL IDENTIFICATION:-----\n\n");
            //listAllPatientsUrl(client, patientBundle);

            Console.WriteLine("\n\n-----PATIENTS WITH ENCOUNTERS----\n\n");
            //patientsWithEncounters(client, patientSearch, 3);
        }

        public static void listAllPatientsUrl(FhirClient c, Bundle patientsBundle)
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
        public static void patientsWithEncounters(FhirClient c, Bundle patientsBundle, int maxCount)
        {
            if (patientsBundle == null || patientsBundle.Entry == null || patientsBundle.Entry.Count == 0)
            {
                Console.WriteLine("No patients found in search.");
                return;
            }
            int matchedCount = 0;

            while (patientsBundle != null && matchedCount < maxCount)
            {
                foreach (var entry in patientsBundle.Entry)
                {
                    if (matchedCount >= maxCount)
                        break;

                    if (entry.Resource is Patient patient && patient.Id != null)
                    {
                        Console.WriteLine("Checking Patient ID: " + patient.Id);

                        Bundle encounterBundle = c.Search<Encounter>(
                            new[] { $"patient=Patient/{patient.Id}" }
                        );

                        if (encounterBundle.Entry != null && encounterBundle.Entry.Count > 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Patient ID " + patient.Id);

                            if (patient.Name.Count > 0)
                                Console.WriteLine("Name " + patient.Name[0].ToString());

                            matchedCount++;
                        }
                        else
                        {
                            Console.WriteLine("No encounters for Patient " + patient.Id);
                        }
                    }
                }
                if (matchedCount < maxCount)
                {
                    patientsBundle = c.Continue(patientsBundle);
                }
                else
                {
                    break;
                }
            }
            if (matchedCount == 0)
                Console.WriteLine("No patients with encounters found.");
        }
        public static void countEntries(Bundle patientsBundle)
        {
            Console.WriteLine($"Total Entries: {patientsBundle.Total}");
        }
        public static void countPatiensInBundle(Bundle patientsBundle)
        {
            Console.WriteLine($"Total Patients in Bundle: {patientsBundle.Entry.Count}\n");
        }
    }
}