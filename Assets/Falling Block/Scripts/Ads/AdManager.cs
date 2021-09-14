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

    private void OnEnable()
    {
        //MobileAds.Initialize((initStatus) =>
        //{
        //    print("Mobile Ads Initialized");
        //});
        RegisterBannerAds();
        RegisterInterstitialAds();
        RegisterRewardedAds();
    }

    public void ShowAd(AdsType adsType)
    {
        //if (Application.platform != RuntimePlatform.Android)
        //    return;
        switch (adsType)
        {
            case AdsType.Banner:
                bannerView.Show();
                break;
            case AdsType.Interstitial:
                if (InterstitialAd.IsLoaded())
                {
                    InterstitialAd.Show();
                }
                break;
            case AdsType.Rewarded:
                if (rewardedAd.IsLoaded())
                {
                    rewardedAd.Show();
                }
                break;
        }
    }

    private void RegisterBannerAds()
    {
        string bannerId = GetAdsKey(AdsType.Banner);
        bannerView = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Bottom);

        bannerView.OnAdClosed += OnAdsClose;

      //  AdRequest adRequest = new AdRequest.Builder().Build();
        AdRequest adRequest = new AdRequest.Builder().Build();
        bannerView.LoadAd(adRequest);
    }

    private void RegisterInterstitialAds()
    {
        string interstitialId = GetAdsKey(AdsType.Interstitial);
        InterstitialAd = new InterstitialAd(interstitialId);

        InterstitialAd.OnAdClosed += OnAdsClose;
        InterstitialAd.OnAdFailedToShow += OnAdsLoadFailed;

        AdRequest adRequest = new AdRequest.Builder().Build();
        InterstitialAd.LoadAd(adRequest);
    }

    private void RegisterRewardedAds()
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
