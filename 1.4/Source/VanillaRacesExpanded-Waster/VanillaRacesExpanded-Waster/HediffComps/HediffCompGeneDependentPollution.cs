using Verse;
namespace VanillaRacesExpandedWaster
{
    public class HediffCompGeneDependentPollution : HediffComp
    {
        public HediffCompProperties_GeneDependentPollution Props => (HediffCompProperties_GeneDependentPollution)props;

        public override void CompPostTick(ref float severityAdjustment)
        {
            Pawn pawn = parent.pawn;
            if (pawn.genes?.HasGene(InternalDefOf.VREW_PollutionRush) == true) {
                if (pawn.IsHashIntervalTick(Props.interval))
                {
                    if (pawn.Spawned && pawn.Position.IsPolluted(pawn.Map))
                    {
                        severityAdjustment += Props.pollutedSeverity;
                    }
                    else
                    {
                        severityAdjustment += Props.unpollutedSeverity;
                    }
                }

            }
            
        }
    }
}
