using RimWorld;
using System.Collections.Generic;
using Verse.AI;
using Verse;

namespace BioSculptingPlus
{
    public class JobGiver_GetBioOptimization_Worker : ThinkNode_JobGiver
    {
        public CompBiosculpterPod GetBiosculpterPod(Pawn pawn)
        {
            Log.Message("JobGiver_GetBioOptimization_Worker.GetBiosculpterPod");
            List<CompBiosculpterPod> compBiosculpterPodList = CompBiosculpterPod.BiotunedPods(pawn);
            if (compBiosculpterPodList != null && pawn.CanBioOptimize_Worker())
            {
                foreach (CompBiosculpterPod biosculpterPod in compBiosculpterPodList)
                {
                    if (biosculpterPod.parent.Spawned && biosculpterPod.AutoAgeReversal && biosculpterPod.CanAcceptOnceCycleChosen(pawn) && biosculpterPod.PawnCanUseNow(pawn, biosculpterPod.GetCycle(CompBiosculpterPod_BioOptWorkerCycle.Key)))
                        return biosculpterPod;
                }
            }
            return (CompBiosculpterPod)null;
        }

        public override float GetPriority(Pawn pawn) => !ModsConfig.IdeologyActive || this.GetBiosculpterPod(pawn) == null ? 0.0f : 7.4f;

        protected override Job TryGiveJob(Pawn pawn)
        {
            Log.Message("JobGiver_GetBioOptimization_Worker.TryGiveJob");
            CompBiosculpterPod biosculpterPod = this.GetBiosculpterPod(pawn);
            if (biosculpterPod == null || !pawn.CanReserve((LocalTargetInfo)(Thing)biosculpterPod.parent))
                return (Job)null;
            Job job = biosculpterPod.EnterBiosculpterJob();
            biosculpterPod.ConfigureJobForCycle(job, biosculpterPod.GetCycle(CompBiosculpterPod_BioOptWorkerCycle.Key), (List<ThingCount>)null);
            return job;
        }
    }
}