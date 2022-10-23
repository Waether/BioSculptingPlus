using RimWorld;
using Verse;
using UnityEngine;

namespace BioSculptingPlus
{
    public class Settings : ModSettings
    {
        #region Settings

        public CycleSettings BeautyCycleSettings = new CycleSettings("Settings_BeautyCycle", true, RecommendedValues.BeautyCycle.Duration);
        public CycleSettingsAgeIncrease AgeIncreaseCycleSettings = new CycleSettingsAgeIncrease("Settings_AgeIncreaseCycle", RecommendedValues.AgeIncreaseCycle.Potency, true, RecommendedValues.AgeIncreaseCycle.Duration);
        public CycleSettings VoiceCycleSettings = new CycleSettings("Settings_VoiceCycle", true, RecommendedValues.VoiceCycle.Duration);
        public CycleSettings ToughCycleSettings = new CycleSettings("Settings_ToughCycle", true, RecommendedValues.ToughCycle.Duration);
        public CycleSettings ImmunityCycleSettings = new CycleSettings("Settings_ImmunityCycle", true, RecommendedValues.ImmunityCycle.Duration);
        
        public CycleSettings BioOptWorkerCycleSettings = new CycleSettings("Settings_BioOptWorkerCycleSettingsCycle", true, RecommendedValues.BioOptWorkerCycleSettingsCycle.Duration);
        public CycleSettings BioOptSoldierCycleSettings = new CycleSettings("Settings_BioOptSoldierCycleSettingsCycle", true, RecommendedValues.BioOptSoldierCycleSettingsCycle.Duration);

        private Vector2 scrollPosition;

        #endregion

        public override void ExposeData()
        {
            BeautyCycleSettings.ScribeValues("BeautyCycle");
            AgeIncreaseCycleSettings.ScribeValues("AgeIncreaseCycle");
            VoiceCycleSettings.ScribeValues("VoiceCycle");
            ToughCycleSettings.ScribeValues("ToughCycle");
            ImmunityCycleSettings.ScribeValues("ImmunityCycle");

            BioOptWorkerCycleSettings.ScribeValues("BioOptWorkerCycle");
            BioOptSoldierCycleSettings.ScribeValues("BioOptSoldierCycle");

            base.ExposeData();
        }

        public void DoWindowContents(Rect canvas)
        {
            Rect outRect = canvas.TopPart(0.9f);
            Rect rect = new Rect(0f, 0f, outRect.width - 18f, 820f);
            Widgets.BeginScrollView(outRect, ref scrollPosition, rect);
            Listing_Standard list = new Listing_Standard();
            list.Begin(rect);

            BeautyCycleSettings.DoCustomCycleSettings(ref list);
            list.DrawGapLine();
            AgeIncreaseCycleSettings.DoCustomCycleSettings(ref list);
            list.DrawGapLine();
            VoiceCycleSettings.DoCustomCycleSettings(ref list);
            list.DrawGapLine();
            ToughCycleSettings.DoCustomCycleSettings(ref list);
            list.DrawGapLine();
            ImmunityCycleSettings.DoCustomCycleSettings(ref list);
            list.DrawGapLine();
            BioOptWorkerCycleSettings.DoCustomCycleSettings(ref list);
            list.DrawGapLine();
            BioOptSoldierCycleSettings.DoCustomCycleSettings(ref list);

            list.End();
            Widgets.EndScrollView();

            Rect rect2 = canvas.BottomPart(0.075f).LeftPart(0.3f);
            rect2.height = canvas.height * 0.05f;
            if (Widgets.ButtonText(rect2, "Apply_Custom_Values".Translate()))
            {
                ApplySettings();
            }
            rect2.x += canvas.width * 0.7f;
            if (Widgets.ButtonText(rect2, "Apply_Recommended_Values".Translate()))
            {
                // Beauty Cycle
                BeautyCycleSettings.Duration = RecommendedValues.BeautyCycle.Duration;
                
                // Age Increase Cycle
                AgeIncreaseCycleSettings.Duration = RecommendedValues.AgeIncreaseCycle.Duration;
                AgeIncreaseCycleSettings.TimeIncrease = RecommendedValues.AgeIncreaseCycle.Potency;

                // Voice Fix Cycle
                VoiceCycleSettings.Duration = RecommendedValues.VoiceCycle.Duration;

                // Tough Cycle
                ToughCycleSettings.Duration = RecommendedValues.ToughCycle.Duration;

                // Immunity Cycle
                ImmunityCycleSettings.Duration = RecommendedValues.ImmunityCycle.Duration;

                // BioOptWorker Cycle
                BioOptWorkerCycleSettings.Duration = RecommendedValues.BioOptWorkerCycleSettingsCycle.Duration;

                // BioOptSoldier Cycle
                BioOptSoldierCycleSettings.Duration = RecommendedValues.BioOptSoldierCycleSettingsCycle.Duration;

                ApplySettings();
            }
        }

        private R GetBiosculpterCompPropertiesAs<T, R>()
            where T : CompBiosculpterPod_Cycle
            where R : CompProperties_BiosculpterPod_BaseCycle
        {
            return DefDatabase<ThingDef>.GetNamed("BiosculpterPod").comps.Find((CompProperties x) => x.GetType() == typeof(R) && x.compClass == typeof(T)) as R;
        }

        public void ApplySettings()
        {
            // Beauty Cycle
            var CompBeautyCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_BeautyCycle, CompProperties_BiosculpterPod_BeautyCycle> ();
            if (CompBeautyCycle != null)
            {
                CompBeautyCycle.durationDays = BeautyCycleSettings.Duration;
            }

            // Age Increase Cycle
            var CompAgeIncreaseCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_AgeIncreaseCycle, CompProperties_BiosculpterPod_AgeIncreaseCycle>();
            if (CompAgeIncreaseCycle != null)
            {
                CompAgeIncreaseCycle.durationDays = AgeIncreaseCycleSettings.Duration;
            }

            // Voice Fix Cycle
            var CompVoiceCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_VoiceCycle, CompProperties_BiosculpterPod_VoiceCycle>();
            if (CompVoiceCycle != null)
            {
                CompVoiceCycle.durationDays = VoiceCycleSettings.Duration;
            }

            // Tough Cycle
            var CompToughCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_ToughCycle, CompProperties_BiosculpterPod_ToughCycle>();
            if (CompToughCycle != null)
            {
                CompToughCycle.durationDays = ToughCycleSettings.Duration;
            }

            // Immunity Cycle
            var CompImmunityCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_ImmunityCycle, CompProperties_BiosculpterPod_ImmunityCycle>();
            if (CompImmunityCycle != null)
            {
                CompImmunityCycle.durationDays = ImmunityCycleSettings.Duration;
            }

            // BioOpt Worker Cycle
            var CompBioOptWorkerCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_BioOptWorkerCycle, CompProperties_BiosculpterPod_BioOptWorkerCycle>();
            if (CompBioOptWorkerCycle != null)
            {
                CompBioOptWorkerCycle.durationDays = BioOptWorkerCycleSettings.Duration;
            }

            // BioOpt Soldier Cycle
            var CompBioOptSoldierCycle = GetBiosculpterCompPropertiesAs<CompBiosculpterPod_BioOptSoldierCycle, CompProperties_BiosculpterPod_BioOptSoldierCycle>();
            if (CompBioOptSoldierCycle != null)
            {
                CompBioOptSoldierCycle.durationDays = BioOptSoldierCycleSettings.Duration;
            }
        }
    }
}
