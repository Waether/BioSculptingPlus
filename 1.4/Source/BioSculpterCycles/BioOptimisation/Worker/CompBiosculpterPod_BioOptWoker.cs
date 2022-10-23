using RimWorld;
using Verse;
using Verse.Noise;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_BioOptWorkerCycle : CompBiosculpterPod_Cycle
    {
        public static HediffDef BioOpt_Worker = HediffDef.Named("BioOptDef");

        public override void CycleCompleted(Pawn pawn)
        {
            var toAdd = HediffMaker.MakeHediff(BioOpt_Worker, pawn);

            pawn.health.AddHediff(toAdd);

            return;
        }
    }
}
