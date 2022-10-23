using System.Collections.Generic;
using System.Xml;
using Verse;

namespace BioSculptingPlus
{
    class PatchOperationCheckSettings : PatchOperation
    {
        private List<string> settings;

        private PatchOperation match;

        private PatchOperation nomatch;

        protected override bool ApplyWorker(XmlDocument xml)
        {
            bool total = true;
            foreach (string setting in settings)
            {
                switch (setting)
                {
                    case "ShowBeautyCycle":
                        total = BioSculptingPlusMod.settings.BeautyCycleSettings.Enabled && total;
                        break;
                    case "ShowVoiceCycle":
                        total = BioSculptingPlusMod.settings.VoiceCycleSettings.Enabled && total;
                        break;
                    case "ShowAgeIncreaseCycle":
                        total = BioSculptingPlusMod.settings.AgeIncreaseCycleSettings.Enabled && total;
                        break;
                    case "ShowToughCycle":
                        total = BioSculptingPlusMod.settings.ToughCycleSettings.Enabled && total;
                        break;
                    case "ShowImmunityCycle":
                        total = BioSculptingPlusMod.settings.ImmunityCycleSettings.Enabled && total;
                        break;
                    case "ShowBioOptWorker":
                        total = BioSculptingPlusMod.settings.BioOptWorkerCycleSettings.Enabled && total;
                        break;
                    case "ShowBioOptSoldier":
                        total = BioSculptingPlusMod.settings.BioOptSoldierCycleSettings.Enabled && total;
                        break;
                    default:
                        total = false;
                        break;
                }
            }

            if (total && match != null)
            {
                return match.Apply(xml);
            }
            else if (nomatch != null)
            {
                return nomatch.Apply(xml);
            }
            return true;
        }
    }
}
