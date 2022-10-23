using Verse;

namespace BioSculptingPlus
{
    public class CycleSettingsAgeIncrease : CycleSettings
    {
        #region Actual

        public float TimeIncrease;

        #endregion

        #region Storage

        protected float? CheckTimeIncrease;

        #endregion

        public CycleSettingsAgeIncrease(string settingLabel, float potency = 1f, bool enabled = true, float duration = 1f)
            : base(settingLabel, enabled, duration)
        {
            TimeIncrease = potency;
        }

        public void ScribeValues(string label, float potency = 1f, bool enabled = true, float duration = 1f)
        {
            base.ScribeValues(label, enabled, duration);
            Scribe_Values.Look(ref TimeIncrease, label + "AgeIncrease", potency);
        }

        public new void DoCustomCycleSettings(ref Listing_Standard ls)
        {
            ls.DrawLabelLine(SettingLabel.Translate());
            ls.DrawLabelCheckbox("Settings_Enable".Translate(), ref Enabled);
            ls.DrawLabelSlider("Settings_TimeRequired".Translate(), ref Duration, 0f, 60f, null, null, 0.1f, true, Duration.ToString() + "Settings_Days".Translate());
            ls.DrawLabelSlider("Settings_TimeAgeIncreaseCycle".Translate(), ref TimeIncrease, 0f, 1200f, null, null, 15f, true, TimeIncrease.ToString() + "Settings_Days".Translate());
            Store();
        }

        public new void Store()
        {
            base.Store();
            CheckTimeIncrease = CheckTimeIncrease != null ? CheckTimeIncrease : TimeIncrease;
        }

        public new bool NeedPatch()
        {
            return (
                base.NeedPatch() ||
                CheckTimeIncrease != TimeIncrease
                );
        }

        public new bool NeedReload()
        {
            return (
                base.NeedReload()
                );
        }

    }
}
