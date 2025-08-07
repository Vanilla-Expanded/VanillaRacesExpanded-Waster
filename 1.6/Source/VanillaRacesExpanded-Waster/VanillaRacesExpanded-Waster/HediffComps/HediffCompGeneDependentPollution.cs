using Verse;
namespace VanillaRacesExpandedWaster
{
    public class HediffCompGeneDependentPollution : HediffComp
    {
        public HediffCompProperties_GeneDependentPollution Props => (HediffCompProperties_GeneDependentPollution)props;

        public override void CompPostTickInterval(ref float severityAdjustment, int delta)
        {
            Pawn pawn = parent.pawn;
            if (pawn.genes?.HasActiveGene(InternalDefOf.VRE_ToxAbsorption) == true) {
                if (pawn.IsHashIntervalTick(Props.interval, delta))
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
