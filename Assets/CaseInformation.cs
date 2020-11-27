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

        // Case ID of the current case being diagnosed 
        public static int CaseID;

        // This is used by the PlayMain scene to detect if its the first entry to the PlayMain page
        public static bool isFirstPlayMainVisit = true;

        // This is used by the summary page to determine whether or not to award the player
        // This avoids a bug where the player is awarded coins everytime the user returns to the summary page from the
        // reasoning page
        public static bool hasPlayerBeenAwarded = false;
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


        // Helper to get the next case ID to pass to the API call (next database record to get)
        private static void GetDatabaseCaseID()
        {
            
            // We store the index to this data structure in PlayerPrefs to track the next case ID to fetch.
            // The values stored in the array are the case IDs for the records we were given. THis is a 
            // temporary solution since we were not give the full database and the records are not contiguous.
            int[] caseIDS = new int[] {208, 209, 210, 211, 212, 213, 216, 222, 224, 228, 231, 233, 234, 236, 238, 241, 243, 246, 247 };

            // Return value
            int currentCaseIndex;

            // Get the index of the caseIDs array from PlayerPrefs
            if (PlayerPrefs.HasKey("DatabaseCaseIndex"))
            {
                currentCaseIndex = PlayerPrefs.GetInt("DatabaseCaseIndex");
            }
            else
            {
                currentCaseIndex = 0;
            }

            // Update the PlayerPrefs Index for the next call (check for need to wrap index back to 0)
            int nextIndex =  (currentCaseIndex < 18) ? (currentCaseIndex + 1) : 0;
            PlayerPrefs.SetInt("DatabaseCaseIndex", nextIndex);

            // Set the member variable to be the CaseID
            // We are doing this instead of just returning it, in case it is needed for X-Ray URL parsing.
            CaseID = caseIDS[currentCaseIndex];
        }

        #endregion



        #region PublicFunctions

        // Function to do API call and get data for a record
        public static void get_patient_data()
        {
            // Construct API endpoint URL (case ID is determined using a private helper function)
            GetDatabaseCaseID();
            string url = "https://diagnostic-gamification-api.herokuapp.com/v1/cases/" + CaseID; 

            // Make HTTP request to URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            // Read in HTTP response from API, which will have our data in JSON format
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();

            // Parse our data from JSON into our C# serializable class (defined in PatientData.cs)
            patient = JsonUtility.FromJson<PatientData>(jsonResponse);

            // Set the true diagnosis enum based on diagnosis string value from API response
            SetDiagnosisEnum();
            
            return;
        }



        // Reset all static information that should only be relevant for this diagnostic session
        // Should only be called when player exits play loop to the main menu 
        // (in summary page and from button in main play page)
        public static void ResetCaseInformation()
        {
            patient = new PatientData();

            SelectedSymptom = SymptomState.Nothing;
            
            UserDiagnosis = DiagnosisState.Undiagnosed;
            TrueDiagnosis = DiagnosisState.Undiagnosed;
            
            UserReasoning = new Dictionary<SymptomState, ReasoningState>();

            isFirstPlayMainVisit = true;

            hasPlayerBeenAwarded = false;

            return;
        }


        #endregion
    }

}
