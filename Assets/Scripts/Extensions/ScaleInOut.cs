using DG.Tweening;

[System.Serializable]
public struct ScaleInOut
{
    public float scaleInDuration;
    public float scaleOutDuration;
    public Ease easeIn;
    public Ease easeOut;

    public ScaleInOut(float inDuration, float outDuration, Ease easeIn, Ease easeOut)
    {
        scaleInDuration = inDuration;
        scaleOutDuration = outDuration;
        this.easeIn = easeIn;
        this.easeOut = easeOut;
    }
}
