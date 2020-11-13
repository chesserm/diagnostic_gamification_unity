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
        /* ******************************************************
         *  !!! DO NOT CHANGE ORDER OR NAMES OF VARIABLES !!!
         *      - Dependent on API response order and names
         * ******************************************************
        */

        public String _id;
        public int Age;
        public String Gender;
        
        public String Diagnosis;
        public String Narratives;

        public String PastMedHistory1;
        public int CaseID;
        public String PastMedHistory2;
        
        public double BloodABG_pco2;
        public double BloodABG_ph;
        public double BloodABG_po2;
        public double BloodBNP;
        public double BloodBUN;
        public double BloodBicarbonate;
        public double BloodChloride;
        public double BloodCreatinine;
        public double BloodGlucose;
        public double BloodHemacrotit;
        public double BloodHemoglobin;
        public double BloodLactate;
        public double BloodPlatelets;
        public double BloodPotassium;
        public String BloodPressure;
        public double BloodSodium;
        public double BloodWBC;



        public String CXRLink;
        public String CXRThoughts;

        public String Difficulty;


        public String ExamAbdomen;
        public String ExamExtremities;
        public String ExamGeneral;
        public String ExamHead;
        public String ExamHeart;
        public String ExamLungs;
        public String ExamNeck;
        public String ExamSkin;


        public String ExpertComments;


        public double HeartRate;

        public String OxygenAmount;
        public String OxygenSat;


        public String PastMedHistory3;


        public String ProvocatingFactors;

        public String RedHerrings;

        public double RespiratoryRate;


        public String SymptomDescription;
        public String SymptomOnset;


        public double Temperature;

        public String TobaccoUse;
        
       


    }
}

