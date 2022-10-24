using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_BioOptWorkerCycle : CompBiosculpterPod_Cycle
    {
        public static HediffDef BioOpt_Worker = HediffDef.Named("BioOptWorkerDef");

        public static string Key = "biooptworkerkey";

        public override void CycleCompleted(Pawn pawn)
        {
            var toAdd = HediffMaker.MakeHediff(BioOpt_Worker, pawn);

            pawn.health.AddHediff(toAdd);
            return;
        }
    }
}
