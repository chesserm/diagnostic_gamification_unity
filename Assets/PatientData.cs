using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using System;



namespace HelperNamespace
{
    [System.Serializable]
    public class PatientData
    {
        /* ******************************************
         *  !!! DO NOT CHANGE ORDER OF VARIABLES !!!
         *      - Dependent on API response format
         * ******************************************
        */

        public String _id;

        public int CaseID;

        public int Age;

        public String Gender;

        public String PastMedHistory1;
        public String PastMedHistory2;
        public String PastMedHistory3;

        public String TobaccoUse;
        public String SymptomOnset;
        public String ProvocatingFactors;
        public String SymptomDescription;

        public double Temperature;
        public double HeartRate;
        public double RespiratoryRate;
        public String BloodPressure;

        public String OxygenSat;
        public String OxygenAmount;

        public String ExamGeneral;
        public String ExamHead;
        public String ExamNeck;
        public String ExamHeart;
        public String ExamLungs;
        public String ExamAbdomen;
        public String ExamExtremities;
        public String ExamSkin;

        public double BloodWBC;
        public double BloodHemoglobin;
        public double BloodHemacrotit;
        public double BloodPlatelets;
        public double BloodSodium;
        public double BloodPotassium;
        public double BloodChloride;
        public double BloodBicarbonate;
        public double BloodBUN;
        public double BloodCreatinine;
        public double BloodGlucose;
        public double BloodBNP;
        public double BloodABG_ph;
        public double BloodABG_pco2;
        public double BloodABG_po2;
        public double BloodLactate;

        public String Diagnosis;

        public String ExpertComments;
        public String RedHerrings;
        public String CXRThoughts;
        public String Narratives;

        public String Hard;

        public String CXRLink;



    }
}

