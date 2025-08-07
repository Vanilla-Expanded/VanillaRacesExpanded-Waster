
using RimWorld;
using System;
using UnityEngine;
using Verse;
namespace VanillaRacesExpandedWaster
{
    [StaticConstructorOnStartup]
    public class CompGasProducer : ThingComp
    {
        protected CompRefuelable refuelableComp;

        public CompProperties_GasProducer Props => (CompProperties_GasProducer)props;

       

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            refuelableComp = parent.GetComp<CompRefuelable>();
        }

        public override void CompTickInterval(int delta)
        {
            if (parent.IsHashIntervalTick(500, delta)) {
                if ((refuelableComp != null && refuelableComp.HasFuel))
                {
                    GasUtility.AddGas(parent.PositionHeld, parent.MapHeld, GasType.ToxGas, 300);
                }

            }
            if (parent.IsHashIntervalTick(60000, delta))
            {
                if ((refuelableComp != null && refuelableComp.HasFuel))
                {
                    PollutionUtility.GrowPollutionAt(parent.PositionHeld, parent.MapHeld, 6);
                }

            }

        }
    }
}