using Verse;

namespace BioSculptingPlus
{
    public class CycleSettings
    {
        #region Actual

        public string SettingLabel;
        public bool Enabled;
        public float Duration;

        #endregion

        #region Storage

        protected bool? CheckEnabled;
        protected float? CheckDuration;

        #endregion

        public CycleSettings(string settingLabel, bool enabled = true, float duration = 1f)
        {
            SettingLabel = settingLabel;
            Enabled = enabled;
            Duration = duration;
        }

        public void ScribeValues(string label, bool enabled = true, float duration = 1f)
        {
            Scribe_Values.Look(ref Enabled, label + "Enabled", enabled);
            Scribe_Values.Look(ref Duration, label + "Duration", duration);
        }

        public void DoCustomCycleSettings(ref Listing_Standard ls)
        {
            ls.DrawLabelLine(SettingLabel.Translate());
            ls.DrawLabelCheckbox("Settings_Enable".Translate(), ref Enabled);
            ls.DrawLabelSlider("Settings_TimeRequired".Translate(), ref Duration, 0f, 60f, null, null, 0.1f, true, Duration.ToString() + "Settings_Days".Translate());
            Store();
        }

        public void Store()
        {
            CheckEnabled = CheckEnabled != null ? CheckEnabled : Enabled;
            CheckDuration = CheckDuration != null ? CheckDuration : Duration;
        }

        public bool NeedPatch()
        {
            return (
                CheckDuration != Duration
                );
        }

        public bool NeedReload()
        {
            return (CheckEnabled != Enabled);
        }

    }
}
