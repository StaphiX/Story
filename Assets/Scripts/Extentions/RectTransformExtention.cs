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

    public class RectTransformData
    {
        public RectTransformData(RectTransform trans)
        {
            anchoredPosition = trans.anchoredPosition;
            anchorMin = trans.anchorMin;
            anchorMax = trans.anchorMax;
            sizeDelta = trans.sizeDelta;
        }

        public RectTransformData(Vector2 position, AnchorPreset anchor)
        {
            anchoredPosition = position;
            GetAnchor(anchor, out anchorMin, out anchorMax);
        }

        public Vector2 anchoredPosition = Vector2.zero;
        public Vector2 sizeDelta = new Vector2(100, 100);
        public Vector2 anchorMin = new Vector2(0.5f, 0.5f);
        public Vector2 anchorMax = new Vector2(0.5f, 0.5f);

        public static implicit operator RectTransformData(RectTransform trans)
        {
            return new RectTransformData(trans);
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

    public static class RectTransformExtention
    {
        public static void Set(this RectTransform thisTrans, RectTransformData transData)
        {
            thisTrans.SetAnchor(transData.anchorMin, transData.anchorMax);
            thisTrans.anchoredPosition = transData.anchoredPosition;
            thisTrans.sizeDelta = transData.sizeDelta;
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

        public static RectTransformData FromPosition(float x, float y, AnchorPreset anchor)
        {
            RectTransformData rectTransform = new RectTransformData(new Vector2(x, y), anchor);

            return rectTransform;
        }
    }
}
