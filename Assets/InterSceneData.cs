using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using HelperNamespace;

namespace HelperNamespace
{


    public static class InterSceneData 
    { 
        public static PatientData patient = new PatientData();


        // Function to do API call and get data for a record
        public static void get_patient_data()
        {
            // CASE ID is hardcoded, should be passed in
            int caseID = 208;
            string url = "https://diagnostic-gamification-api.herokuapp.com/v1/cases/" + caseID; 

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(url));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            UnityEngine.Debug.Log(jsonResponse);

            patient = JsonUtility.FromJson<PatientData>(jsonResponse);

            // Testing reserializing
            string myVariable = JsonUtility.ToJson(patient);
            //UnityEngine.Debug.Log(myVariable);
            return;
        }


        public static void SetDiagnosisToPoopoo()
        {
            patient.Diagnosis = "poopoo";
        }

 

    }

}
