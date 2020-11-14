using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperNamespace
{
    // Enums to avoid using cryptic ints or having to rely on string comparisons
    #region CustomStateEnums
    public enum SymptomState
    {
        General,
        Head,
        Neck,
        Heart,
        Lungs,
        Extremities,
        Abdomen,
        Oxygen,
        Imaging,
        Bloodwork,
        Skin,
        Nothing,
        MainMenu
    }

    public enum ReasoningState
    {
        Correct,
        Incorrect1,
        Incorrect2,
        Incorrect3,
        Undecided
    }


    public enum DiagnosisState
    {
        Undiagnosed,
        COPD,
        Pneumonia,
        CHF
    }
    #endregion


    // Class to store constants that need to be referenced
    public static class PlayLoopData
    {
        #region ReasoningDictionary
        public static Dictionary<SymptomState, Dictionary<ReasoningState, string>> ReasoningValues =
            new Dictionary<SymptomState, Dictionary<ReasoningState, string>>
            {
                {
                    SymptomState.General,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Pneumonia patients often present with a fever."},
                        {ReasoningState.Incorrect1, "Respiratory failure patients who present with a fever guarantee pnuemonia as the underlying cause"},
                        {ReasoningState.Incorrect2, "High blood pressure is often an indicator of COPD."},
                        {ReasoningState.Incorrect3, "Confusion is often a common symptom of Pneumonia."}
                    }
                },
                {
                    SymptomState.Neck,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "CHF patients often have distended jugular veins."},
                        {ReasoningState.Incorrect1, "Respiratory failure patients with distended jugular veins garuntees CHF as the underlying cause."},
                        {ReasoningState.Incorrect2, "Distended Jugular Veins will not occur in Pnuemonia patients."},
                        {ReasoningState.Incorrect3, "Distended Jugular Veins are a common symptom of COPD."}
                    }
                },
                {
                    SymptomState.Heart,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "CHF patients often have an abnormal heart rate (arrhythmias)."},
                        {ReasoningState.Incorrect1, "Pneumonia patients nearly always present with irregular heart rates."},
                        {ReasoningState.Incorrect2, "CHF patients often have slower than normal heart rates."},
                        {ReasoningState.Incorrect3, "CHF patients always present with irregular heart rhythm."}
                    }
                },
                {
                    SymptomState.Lungs,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Pneumonia and CHF patients often have crackels in their lungs, COPD often have wheezing."},
                        {ReasoningState.Incorrect1, "Pnuemonia patients often wheeze when exhaling."},
                        {ReasoningState.Incorrect2, "COPD patients tend to have crackling sounds in their lungs."},
                        {ReasoningState.Incorrect3, "CHF patients will have crackling in a specific area of the lungs."}
                    }
                },
                {
                    SymptomState.Extremities,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Leg swelling (edema) is a common symptom of CHF"},
                        {ReasoningState.Incorrect1, "Edema is commonly found in the legs of COPD patients"},
                        {ReasoningState.Incorrect2, "CHF patients will always have edema in their extremities"},
                        {ReasoningState.Incorrect3, "Pneumonia patients will not have edema in their extremities"}
                    }
                },
                {
                    SymptomState.Abdomen,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Abdomen distention is a sign of CHF "},
                        {ReasoningState.Incorrect1, "COPD patients frequently present with abdomen distention"},
                        {ReasoningState.Incorrect2, "Pneumonia patients nearly always present with abdomen distention"},
                        {ReasoningState.Incorrect3, "Pneumonia patients will never present with a distended abdomen "}
                    }
                },
                {
                    SymptomState.Oxygen,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "COPD patients often have lower oxygen saturation levels than normal"},
                        {ReasoningState.Incorrect1, "COPD patients often have normal oxygen saturation levels"},
                        {ReasoningState.Incorrect2, "Pneumonia patients often have higher than normal oxygen saturation levels"},
                        {ReasoningState.Incorrect3, "CHF patients often have higher than normal oxygen saturation levels"}
                    }
                },
                {
                    SymptomState.Imaging,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "CHF Patients often have signs of increased fluid in lungs, Pneumonia patients have signs of pneumonia in particular areas of the lung"},
                        {ReasoningState.Incorrect1, "Pneumonia patients will have signs of fluid throughout the lungs"},
                        {ReasoningState.Incorrect2, "COPD patients will have signs of fluid in specific areas of the lungs"},
                        {ReasoningState.Incorrect3, "CHF patients will have signs of fluid only in specific regions of the lungs"}
                    }
                },
                {
                    SymptomState.Bloodwork,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Pneumonia Patients often have high WBC, CHF Patients often have high BNP levels"},
                        {ReasoningState.Incorrect1, "COPD patients often have a high WBC"},
                        {ReasoningState.Incorrect2, "Pneumonia patients often have high BNP"},
                        {ReasoningState.Incorrect3, "CHF patients often have a high WBC"}
                    }
                }
            }; // Outer dictionary definition

        #endregion



    }

    //public enum CoreState
    //{
    //    Menu,
    //    Stats,
    //    Shop,
    //    Play,
    //    Customize
    //}


    //// Enum to know which screen of the game loop they are on 
    //public enum PlayState
    //{
    //    Initial,
    //    Main,
    //    Diagnose,
    //    SymptomList,
    //    SymptomInfo,
    //    Reasoning,
    //    Summary,
    //    Back
    //}


    // Enum to determine which symptom is being investigated




    //public enum ItemType
    //{
    //    Hat,
    //    Labcoat,
    //    Stethescope,
    //    Mask,
    //    Shoes,
    //    Pants
    //}


}