
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

        public int tickCounter = 0;
        public const int tickInterval = 60;

        public override void CompExposeData()
        {
            base.CompExposeData();

            Scribe_Values.Look(ref this.tickCounter, nameof(this.tickCounter));

        }

      

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            tickCounter++;
            if (tickCounter > tickInterval && parent.pawn.Map != null)
            {
                if (parent.pawn.Position.AnyGas(parent.pawn.Map, GasType.ToxGas)) {
                    if (!parent.pawn.health.hediffSet.HasHediff(HediffDefOf.PollutionStimulus))
                    {
                        parent.pawn.health.AddHediff(HediffDefOf.PollutionStimulus);
                    }

                    foreach (Hediff hediff in parent.pawn.health.hediffSet.hediffs)
                    {
                        HediffComp_Pollution comp = hediff.TryGetComp<HediffComp_Pollution>();
                        if (comp!=null) {
                            hediff.Severity += 0.022f;
                        
                        }

                    }


                }
                


                tickCounter = 0;
            }


        }







    }
}