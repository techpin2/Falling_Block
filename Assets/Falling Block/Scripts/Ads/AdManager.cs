using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    #region Singletone
    public static AdManager adManager;
    private void Awake()
    {
        if (adManager == null)
        {
            adManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    #endregion

    public AdsKeys AdsKey;

    private BannerView bannerView;
    private InterstitialAd InterstitialAd;
    private RewardedAd rewardedAd;

    private void Start()
    {
        MobileAds.Initialize((initStatus) =>
        {
            print("Mobile Ads Initialized");
        });
    }

    public void ShowAd(AdsType adsType)
    {
        //if (Application.platform != RuntimePlatform.Android)
        //    return;
        switch (adsType)
        {
            case AdsType.Banner:
                ShowBannerAds();
                break;
            case AdsType.Interstitial:
                ShowInterstitialAds();
                break;
            case AdsType.Rewarded:
                ShowRewardedAds();
                break;
        }
    }

    private void ShowBannerAds()
    {
        string bannerId = GetAdsKey(AdsType.Banner);
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);

        bannerView.OnAdClosed += OnAdsClose;

        //AdRequest adRequest = new AdRequest.Builder().Build();
        //bannerView.LoadAd(adRequest);
        bannerView.Show();
    }

    private void ShowInterstitialAds()
    {
        string interstitialId = GetAdsKey(AdsType.Interstitial);
        InterstitialAd = new InterstitialAd(interstitialId);

        InterstitialAd.OnAdClosed += OnAdsClose;
        InterstitialAd.OnAdFailedToShow += OnAdsLoadFailed;

        AdRequest adRequest = new AdRequest.Builder().Build();
        InterstitialAd.LoadAd(adRequest);
        InterstitialAd.Show();
    }

    private void ShowRewardedAds()
    {
        string rewardedId = GetAdsKey(AdsType.Rewarded);
        rewardedAd = new RewardedAd(rewardedId);

        rewardedAd.OnAdLoaded += OnRewardedAdLoaded;
        rewardedAd.OnAdClosed += OnAdsClose;
        rewardedAd.OnAdFailedToShow += OnAdsLoadFailed;

        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
    }


    #region CallBack
    private void OnRewardedAdLoaded(object sender, EventArgs ards)
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    private void OnAdsClose(object sender, EventArgs ards)
    {
        print("Ads Closed By User!!");
    }

    private void OnAdsLoadFailed(object sender, EventArgs ards)
    {
        print("Ads Load Failed");
    }
    #endregion
    private string GetAdsKey(AdsType adsType)
    {
        Ads ads = Array.Find<Ads>(AdsKey.adsKeys, a => a.AdsType == adsType);
        if (ads == null)
        {
            Debug.LogError("Key Not Found Please Check Ads Key Setting!!");
            return "";
        }
        return ads.key;
    }

    private void OnDisable()
    {
        if (bannerView != null)
            bannerView.OnAdClosed -= OnAdsClose;

        if (InterstitialAd != null)
        {
            InterstitialAd.OnAdClosed -= OnAdsClose;
            InterstitialAd.OnAdFailedToShow -= OnAdsLoadFailed;
        }

        if (rewardedAd != null)
        {
            rewardedAd.OnAdLoaded -= OnRewardedAdLoaded;
            rewardedAd.OnAdClosed -= OnAdsClose;
            rewardedAd.OnAdFailedToShow -= OnAdsLoadFailed;
        }
    }

}
