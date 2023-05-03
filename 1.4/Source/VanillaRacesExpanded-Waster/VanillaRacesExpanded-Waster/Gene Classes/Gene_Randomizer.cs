
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.Analytics;

namespace VanillaRacesExpandedWaster
{

    public class Gene_Randomizer : Gene
    {
        public List<GeneDef> mutationGenes = new List<GeneDef>() { InternalDefOf.VREW_PollutionRage,InternalDefOf.VREW_PollutionSustenance,
        InternalDefOf.VREW_PollutionRegeneration,InternalDefOf.VREW_PollutionRush};

        public override void PostAdd()
        {
            base.PostAdd();

            IntRange range = new IntRange(1, 3);

            List<GeneDef> chosenMutations = mutationGenes.OrderBy(x => Rand.Value).Take(range.RandomInRange).ToList();

            foreach(GeneDef chosenMutation in chosenMutations)
            {
                if (!pawn.genes.HasGene(chosenMutation))
                {
                    pawn.genes.AddGene(chosenMutation, false);
                }
                
            }

            pawn.genes.RemoveGene(this);






        }

       


    }
}
