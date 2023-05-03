using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using HarmonyLib;


namespace VanillaRacesExpandedWaster
{
   /* [HarmonyPatch(typeof(PregnancyUtility), "ApplyBirthOutcome")]
    public static class VanillaRacesExpandedWaster_PregnancyUtility_ApplyBirthOutcome_Patch
    {
        [HarmonyPostfix]
        public static void IncreaseInstability(List<GeneDef> genes, Pawn geneticMother, Pawn father)
        {
            if (geneticMother.genes?.Xenotype == InternalDefOf.Waster || father?.genes?.Xenotype == InternalDefOf.Waster)
            {
                if (genes.Contains(InternalDefOf.VRE_Instability_Nominal))
                {
                    
                }

            }
        }
    }*/
}
