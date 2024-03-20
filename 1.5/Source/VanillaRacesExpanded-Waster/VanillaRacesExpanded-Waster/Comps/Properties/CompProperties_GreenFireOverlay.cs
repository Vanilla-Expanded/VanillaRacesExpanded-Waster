using RimWorld;
using UnityEngine;
using Verse;
namespace VanillaRacesExpandedWaster
{
    public class CompProperties_GreenFireOverlay : CompProperties
    {
        public float fireSize = 1f;

        public float finalFireSize = 1f;

        public float fireGrowthDurationTicks = -1f;

        public Vector3 offset;

        public CompProperties_GreenFireOverlay()
        {
            compClass = typeof(CompGreenFireOverlay);
        }

        public override void DrawGhost(IntVec3 center, Rot4 rot, ThingDef thingDef, Color ghostCol, AltitudeLayer drawAltitude, Thing thing = null)
        {
            GhostUtility.GhostGraphicFor(CompGreenFireOverlay.FireGraphic, thingDef, ghostCol).DrawFromDef(center.ToVector3ShiftedWithAltitude(drawAltitude), rot, thingDef);
        }
    }
}
