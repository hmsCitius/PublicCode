using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class BonusRewarded : MonoBehaviour
{
    private RewardedAd rewardedAd;
    

    private void Start()
    {
        MobileAds.Initialize(InitStatus => { });
        CreateAndLoadRewardedAd();
    }


    public void CreateAndLoadRewardedAd()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
        this.rewardedAd.OnUserEarnedReward += OyuncuyaOdulVer;
        this.rewardedAd.OnAdClosed += ReklamiTekrarla;

    }


    public void UserChoseToWatchAd()
    {
        

        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }






   
    public void OyuncuyaOdulVer(object sender, EventArgs args)
    {
        GetComponent<User>().BonusOdul();
        
        Time.timeScale = 0;
    }


    public void ReklamiTekrarla(object sender,EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }


}