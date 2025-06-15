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
    [HarmonyPatch(typeof(PregnancyUtility))]
    [HarmonyPatch(nameof(PregnancyUtility.ApplyBirthOutcome))]
    public static class VanillaRacesExpandedWaster_PregnancyUtility_ApplyBirthOutcome_Patch
    {
        [HarmonyPostfix]
        public static void IncreaseInstability(RitualOutcomePossibility outcome, float quality, Precept_Ritual ritual, List<GeneDef> genes, Pawn geneticMother, Thing birtherThing, Pawn father , Pawn doctor, LordJob_Ritual lordJobRitual, RitualRoleAssignments assignments, Thing __result)
        {
            Pawn pawn = __result as Pawn;
            if (pawn != null) {
                if (genes.Contains(InternalDefOf.VRE_Instability_Progressive))
                {
                    if (genes.Contains(InternalDefOf.VRE_Instability_Nominal))
                    {
                        pawn.genes.RemoveGene(pawn.genes.GetGene(InternalDefOf.VRE_Instability_Nominal));
                        pawn.genes.AddGene(InternalDefOf.Instability_Mild,false);
                    }else if (genes.Contains(InternalDefOf.Instability_Mild))
                    {
                        pawn.genes.RemoveGene(pawn.genes.GetGene(InternalDefOf.Instability_Mild));
                        pawn.genes.AddGene(InternalDefOf.Instability_Major, false);
                    }
                    else if (genes.Contains(InternalDefOf.Instability_Major))
                    {
                        pawn.genes.RemoveGene(pawn.genes.GetGene(InternalDefOf.Instability_Major));
                        pawn.genes.AddGene(InternalDefOf.VRE_Instability_Extreme, false);
                    }
                    else 
                    {
                       
                        pawn.genes.AddGene(InternalDefOf.VRE_Instability_Nominal, false);
                    }


                }

            }
            
        }
    }
}
