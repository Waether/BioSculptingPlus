using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    public static class PawnExtension
    {
        public static bool CanBioOptimize_Soldier(this Pawn pawn)
        {
            Log.Message("PawnExtension.CanBioOptimize_Soldier");
            var hed = pawn.health.hediffSet.GetFirstHediffOfDef(CompBiosculpterPod_BioOptSoldierCycle.BioOpt_Soldier);

            if (hed != null)
            {
                if (hed.CurStageIndex == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CanBioOptimize_Worker(this Pawn pawn)
        {
            Log.Message("PawnExtension.CanBioOptimize_Worker");
            var hed = pawn.health.hediffSet.GetFirstHediffOfDef(CompBiosculpterPod_BioOptWorkerCycle.BioOpt_Worker);

            if (hed != null)
            {
                if (hed.CurStageIndex == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
