using UnityEngine;

namespace UnityExtentions
{
    public enum AnchorPreset
    {
        TopLeft,
        TopCenter,
        TopRight,

        MiddleLeft,
        MiddleCenter,
        MiddleRight,

        BottomLeft,
        BottonCenter,
        BottomRight,
        BottomStretch,

        VertStretchLeft,
        VertStretchRight,
        VertStretchCenter,

        HorStretchTop,
        HorStretchMiddle,
        HorStretchBottom,

        StretchAll
    }

    public static class RectTransformExtention
    {
        public static void Set(this RectTransform thisTrans, float x, float y, AnchorPreset anchor)
        {
            thisTrans.anchoredPosition = new Vector2(x, y);
            GetAnchor(anchor, out Vector2 anchorMin, out Vector2 anchorMax);
            SetAnchor(thisTrans, anchorMin, anchorMax);
        }

        public static void Set(this RectTransform thisTrans, float anchorX, float anchorY, float offsetX, float offsetY, AnchorPreset anchor)
        {
            thisTrans.anchoredPosition = new Vector2(anchorX, anchorY);
            thisTrans.offsetMin = new Vector2(offsetX, offsetY);
            thisTrans.offsetMax = new Vector2(offsetX, offsetY);
            GetAnchor(anchor, out Vector2 anchorMin, out Vector2 anchorMax);
            SetAnchor(thisTrans, anchorMin, anchorMax);
        }

        public static void Set(this RectTransform thisTrans, RectTransform trans)
        {
            thisTrans.anchorMax = trans.anchorMax;
            thisTrans.anchorMin = trans.anchorMin;
            thisTrans.anchoredPosition = trans.anchoredPosition;
            thisTrans.sizeDelta = trans.sizeDelta;
        }

        public static void SetAnchor(this RectTransform thisTrans, RectTransform trans)
        {
            thisTrans.anchorMin = trans.anchorMin;
            thisTrans.anchorMax = trans.anchorMax;
        }

        public static void SetAnchor(this RectTransform thisTrans, Vector2 anchorMin, Vector2 anchorMax)
        {
            thisTrans.anchorMin = anchorMin;
            thisTrans.anchorMax = anchorMax;
        }

        public static void GetAnchor(AnchorPreset anchorPreset, out Vector2 anchorMin, out Vector2 anchorMax)
        {
            anchorMin = new Vector2(0.0f, 0.0f);
            anchorMax = new Vector2(1.0f, 1.0f);

            if (anchorPreset == AnchorPreset.TopLeft ||
               anchorPreset == AnchorPreset.MiddleLeft ||
               anchorPreset == AnchorPreset.BottomLeft ||
               anchorPreset == AnchorPreset.VertStretchLeft)
            {
                anchorMin.x = 0.0f;
                anchorMax.x = 0.0f;
            }

            if (anchorPreset == AnchorPreset.TopRight ||
               anchorPreset == AnchorPreset.MiddleRight ||
               anchorPreset == AnchorPreset.BottomRight ||
               anchorPreset == AnchorPreset.VertStretchRight)
            {
                anchorMin.x = 1.0f;
                anchorMax.x = 1.0f;
            }

            if (anchorPreset == AnchorPreset.TopCenter ||
               anchorPreset == AnchorPreset.MiddleCenter ||
               anchorPreset == AnchorPreset.BottonCenter ||
               anchorPreset == AnchorPreset.VertStretchCenter)
            {
                anchorMin.x = 0.5f;
                anchorMax.x = 0.5f;
            }

            if (anchorPreset == AnchorPreset.TopLeft ||
               anchorPreset == AnchorPreset.TopCenter ||
               anchorPreset == AnchorPreset.TopRight ||
               anchorPreset == AnchorPreset.HorStretchTop)
            {
                anchorMin.y = 1.0f;
                anchorMax.y = 1.0f;
            }

            if (anchorPreset == AnchorPreset.BottomLeft ||
               anchorPreset == AnchorPreset.BottonCenter ||
               anchorPreset == AnchorPreset.BottomRight ||
               anchorPreset == AnchorPreset.HorStretchBottom)
            {
                anchorMin.y = 0.0f;
                anchorMax.y = 0.0f;
            }

            if (anchorPreset == AnchorPreset.MiddleLeft ||
               anchorPreset == AnchorPreset.MiddleCenter ||
               anchorPreset == AnchorPreset.MiddleRight ||
               anchorPreset == AnchorPreset.HorStretchMiddle)
            {
                anchorMin.y = 0.5f;
                anchorMax.y = 0.5f;
            }

            if (anchorPreset == AnchorPreset.VertStretchLeft ||
                anchorPreset == AnchorPreset.VertStretchCenter ||
                anchorPreset == AnchorPreset.VertStretchRight ||
                anchorPreset == AnchorPreset.StretchAll)
            {
                anchorMin.y = 0.0f;
                anchorMax.y = 1.0f;
            }

            if (anchorPreset == AnchorPreset.HorStretchTop ||
                anchorPreset == AnchorPreset.HorStretchMiddle ||
                anchorPreset == AnchorPreset.HorStretchBottom ||
                anchorPreset == AnchorPreset.StretchAll)
            {
                anchorMin.x = 0.0f;
                anchorMax.x = 1.0f;
            }
        }
    }
}
