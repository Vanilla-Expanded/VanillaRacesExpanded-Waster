using Verse;
using System.Collections.Generic;
using System.Linq;

namespace VanillaRacesExpandedWaster
{

    [StaticConstructorOnStartup]
    public class Gene_Randomizer : Gene
    {
        public static List<GeneDef> mutationGenes = DefDatabase<GeneDef>.AllDefs.Where(def => def.HasModExtension<PollutionMutationGene>()).ToList();

        public override void PostAdd()
        {
            base.PostAdd();

            IntRange range = new IntRange(1, 3);

            List<GeneDef> chosenMutations = mutationGenes.InRandomOrder().Take(range.RandomInRange).ToList();

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
