

using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;



namespace fhir1srProject
{
    /// <summary>
    /// 
    /// </summary>
    class Programm
    {
        private const string fhirServer = "http://vonk-fire.ly";
        static void Main(String[] args)
        {
            var settigs = new FhirClientSettings
            {
                PreferredFormat = ResourceFormat.Json,
                ReturnPreference = ReturnPreference.Representation,

            };
        }
    }
}