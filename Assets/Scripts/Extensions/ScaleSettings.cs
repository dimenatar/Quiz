using DG.Tweening;

namespace Extensions
{
    [System.Serializable]
    public struct ScaleSettings
    {
        public float _duration;
        public Ease _ease;

        public ScaleSettings(float duration, Ease ease)
        {
            _duration = duration;
            _ease = ease;
        }
    }
}