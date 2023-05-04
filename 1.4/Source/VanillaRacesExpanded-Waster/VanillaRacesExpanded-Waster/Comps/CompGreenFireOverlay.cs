
using RimWorld;
using UnityEngine;
using Verse;
namespace VanillaRacesExpandedWaster
{
    [StaticConstructorOnStartup]
    public class CompGreenFireOverlay : ThingComp
    {
        protected CompRefuelable refuelableComp;

        protected int startedGrowingAtTick = -1;

        public static readonly Graphic FireGraphic = GraphicDatabase.Get<Graphic_Flicker_Green>("Things/Mote/Toxfire", ShaderDatabase.TransparentPostLight, Vector2.one, Color.white);

        public CompProperties_GreenFireOverlay Props => (CompProperties_GreenFireOverlay)props;

        public float FireSize
        {
            get
            {
                if (startedGrowingAtTick < 0)
                {
                    return Props.fireSize;
                }
                return Mathf.Lerp(Props.fireSize, Props.finalFireSize, (float)(GenTicks.TicksAbs - startedGrowingAtTick) / Props.fireGrowthDurationTicks);
            }
        }

        public override void PostDraw()
        {
            base.PostDraw();
            if (refuelableComp == null || refuelableComp.HasFuel)
            {
                Vector3 drawPos = parent.DrawPos;
                drawPos.y += 3f / 74f;
                FireGraphic.Draw(drawPos, Rot4.North, parent);
            }
        }

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            refuelableComp = parent.GetComp<CompRefuelable>();
        }

        public override void CompTick()
        {
            if ((refuelableComp == null || refuelableComp.HasFuel) && startedGrowingAtTick < 0)
            {
                startedGrowingAtTick = GenTicks.TicksAbs;
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref startedGrowingAtTick, "startedGrowingAtTick", -1);
        }
    }
}