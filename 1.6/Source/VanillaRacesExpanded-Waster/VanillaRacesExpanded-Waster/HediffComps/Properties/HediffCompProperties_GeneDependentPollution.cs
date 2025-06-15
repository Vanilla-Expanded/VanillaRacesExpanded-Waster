using Verse;
namespace VanillaRacesExpandedWaster
{
    public class HediffCompProperties_GeneDependentPollution : HediffCompProperties
    {
        public float pollutedSeverity;

        public float unpollutedSeverity;

        public int interval = 1;

        public HediffCompProperties_GeneDependentPollution()
        {
            compClass = typeof(HediffCompGeneDependentPollution);
        }
    }
}
