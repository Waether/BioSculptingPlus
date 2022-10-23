using RimWorld;
using Verse;
using UnityEngine;

namespace BioSculptingPlus
{
    public static class ListingStandardExtension
    {
        public static Rect VerticalSplit(this Listing_Standard ls, out Rect leftHalf, out Rect rightHalf, float leftPartPercent = 0.5f, float? height = null)
        {
            Rect rect = ls.GetRect(height);
            leftHalf = rect.LeftPart(leftPartPercent).Rounded();
            rightHalf = rect.RightPart(1f - leftPartPercent).Rounded();
            return rect;
        }

        public static Rect GetRect(this Listing_Standard ls, float? height = null)
        {
            return ls.GetRect(height ?? Text.LineHeight);
        }

        public static void DrawLabelSlider(this Listing_Standard ls, string label, ref float value, float minValue, float maxValue, string leftAlignedLabel = null, string rightAlignedLabel = null, float roundTo = -1f, bool middleAlignment = false, string centeredLabel = null)
        {
            ls.DrawGap();
            ls.VerticalSplit(out Rect leftHalf, out Rect rightHalf, 0.2f);
            Widgets.Label(leftHalf, label);
            float valueCpy = value;
            value = Widgets.HorizontalSlider(rightHalf, valueCpy, minValue, maxValue, middleAlignment, centeredLabel, leftAlignedLabel, rightAlignedLabel, roundTo);
        }

        public static void DrawLabelLine(this Listing_Standard ls, string label, float? height = null)
        {
            ls.DrawGap();
            Rect rect = ls.GetRect(height);
            Widgets.Label(rect, label);
        }

        public static void DrawLabelCheckbox(this Listing_Standard ls, string label, ref bool checkOn, string tooltip = null, float height = 0f, float labelPct = 1f)
        {
            ls.CheckboxLabeled(label, ref checkOn, tooltip, height, labelPct);
        }

        public static void DrawLine(this Listing_Standard ls)
        {
            ls.GapLine();
        }

        public static void DrawGap(this Listing_Standard ls)
        {
            ls.Gap();
        }

        public static void DrawGapLine(this Listing_Standard ls)
        {
            ls.DrawGap();
            ls.DrawLine();
        }
    }
}
