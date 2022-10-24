using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_BioOptSoldierCycle : CompBiosculpterPod_Cycle
    {
        public static HediffDef BioOpt_Soldier = HediffDef.Named("BioOptSoldierDef");

        public static string Key = "biooptsoldierkey";

        public override void CycleCompleted(Pawn pawn)
        {
            var toAdd = HediffMaker.MakeHediff(BioOpt_Soldier, pawn);

            pawn.health.AddHediff(toAdd);
            return;
        }
    }
}
