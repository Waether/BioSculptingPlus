using RimWorld;
using Verse;
using Verse.Noise;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_BioOptSoldierCycle : CompBiosculpterPod_Cycle
    {
        public static HediffDef BioOpt_Soldier = HediffDef.Named("BioOptSoldierDef");

        public override void CycleCompleted(Pawn pawn)
        {
            var toAdd = HediffMaker.MakeHediff(BioOpt_Soldier, pawn);

            pawn.health.AddHediff(toAdd);

            return;
        }
    }
}
