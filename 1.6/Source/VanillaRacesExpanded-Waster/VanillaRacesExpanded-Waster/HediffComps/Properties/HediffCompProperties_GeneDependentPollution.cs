using Verse;
namespace VanillaRacesExpandedWaster
{
    public class HediffCompProperties_GeneDependentPollution : HediffCompProperties
    {
        public float pollutedSeverity;

        public float unpollutedSeverity;

        // 15 recommended as minimum due to VTR
        public int interval = 15;

        public HediffCompProperties_GeneDependentPollution()
        {
            compClass = typeof(HediffCompGeneDependentPollution);
        }
    }
}
