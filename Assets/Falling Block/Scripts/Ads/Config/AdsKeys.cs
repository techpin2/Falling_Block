using UnityEngine;

[CreateAssetMenu(fileName = "AdsKeysSetting", menuName = "Ads/CreateKey", order = 1)]
public class AdsKeys : ScriptableObject
{
    public Ads[] adsKeys;
}

[System.Serializable]
public class Ads
{
    public AdsType AdsType;
    public string key;
}

public enum AdsType
{
    Banner,
    Interstitial,
    Rewarded
}
