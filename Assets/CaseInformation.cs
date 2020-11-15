using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

namespace HelperNamespace
{


    public static class CaseInformation 
    {
        #region MemberVariables

        // Static variable that holds patient information (API response from database)
        public static PatientData patient = new PatientData();


        // Static enum to help track state between requested and delivered reasoning values
        public static SymptomState SelectedSymptom = SymptomState.Nothing;

        // Static enums to track user and true diagnoses
        public static DiagnosisState UserDiagnosis = DiagnosisState.Undiagnosed;
        public static DiagnosisState TrueDiagnosis = DiagnosisState.Undiagnosed;

        // Dictionary to hold resoning choices
        public static Dictionary<SymptomState, ReasoningState> UserReasoning = new Dictionary<SymptomState, ReasoningState>();

        #endregion


        #region HelperFunctions
        // Helper to set the enum for the true diagnosis for easier comparison 
        private static void SetDiagnosisEnum()
        {
            string diagnosis = patient.Diagnosis;
            diagnosis = diagnosis.ToLower();

            if (diagnosis == "pneumonia")
            {
                TrueDiagnosis = DiagnosisState.Pneumonia;
            }
            else if (diagnosis == "copd")
            {
                TrueDiagnosis = DiagnosisState.COPD;
            }
            else if (diagnosis == "heart failure")
            {
                TrueDiagnosis = DiagnosisState.CHF;
            }

            return;
        }

        #endregion



        #region PublicFunctions

        // Function to do API call and get data for a record
        public static void get_patient_data()
        {
            // Construct API endpoint URL
            // CASE ID is currently hardcoded, should be passed in to this function
            int caseID = 208;
            string url = "https://diagnostic-gamification-api.herokuapp.com/v1/cases/" + caseID; 

            // Make HTTP request to URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            // Read in HTTP response from API, which will have our data in JSON format
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            UnityEngine.Debug.Log(jsonResponse);

            // Parse our data from JSON into our C# serializable class (defined in PatientData.cs)
            patient = JsonUtility.FromJson<PatientData>(jsonResponse);

            // Testing reserializing
            string myVariable = JsonUtility.ToJson(patient);

            // Set the true diagnosis enum based on diagnosis string value from API response
            SetDiagnosisEnum();
            
            return;
        }



        // Reset all static information that should only be relevant for this diagnostic session
        public static void ResetCaseInformation()
        {
            patient = new PatientData();

            SelectedSymptom = SymptomState.Nothing;
            
            UserDiagnosis = DiagnosisState.Undiagnosed;
            TrueDiagnosis = DiagnosisState.Undiagnosed;
            
            UserReasoning = new Dictionary<SymptomState, ReasoningState>();
            
            return;
        }


        #endregion
    }

}
