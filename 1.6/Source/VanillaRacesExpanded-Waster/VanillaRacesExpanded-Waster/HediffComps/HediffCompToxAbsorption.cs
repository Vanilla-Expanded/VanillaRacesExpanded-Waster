
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;
using static HarmonyLib.Code;


namespace VanillaRacesExpandedWaster
{
    public class HediffCompToxAbsorption : HediffComp
    {
        private HediffCompProperties_ToxAbsorption Props => (HediffCompProperties_ToxAbsorption)props;

        public const int tickInterval = 60;

        public override void CompPostTickInterval(ref float severityAdjustment, int delta)
        {
            base.CompPostTickInterval(ref severityAdjustment, delta);

            if (parent.pawn.IsHashIntervalTick(tickInterval, delta) && parent.pawn.Map != null)
            {
                if (parent.pawn.Position.AnyGas(parent.pawn.Map, GasType.ToxGas))
                {
                    if (!parent.pawn.health.hediffSet.HasHediff(HediffDefOf.PollutionStimulus) && parent.pawn.genes?.HasActiveGene(InternalDefOf.VREW_PollutionRush) == true)
                    {
                        parent.pawn.health.AddHediff(HediffDefOf.PollutionStimulus);
                    }
                }

                foreach (Hediff hediff in parent.pawn.health.hediffSet.hediffs)
                {
                    HediffComp_Pollution comp = hediff.TryGetComp<HediffComp_Pollution>();
                    if (comp != null)
                    {
                        if (parent.pawn.Position.AnyGas(parent.pawn.Map, GasType.ToxGas))
                        {
                            hediff.Severity += 0.022f;
                        }
                      

                    }
                    HediffCompGeneDependentPollution comp2 = hediff.TryGetComp<HediffCompGeneDependentPollution>();
                    if (comp2 != null)
                    {
                        if (parent.pawn.Position.AnyGas(parent.pawn.Map, GasType.ToxGas))
                        {
                            hediff.Severity += 0.022f;
                        }
                       

                    }

                }





            }


        }







    }
}