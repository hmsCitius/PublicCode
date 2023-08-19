using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class GecisReklami : MonoBehaviour
{


    private InterstitialAd interstitial;

    private int Reklamsayisi;



    private void Start()
    {
        MobileAds.Initialize(InitStatus => { });
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);


        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;




        RequestInterstitial();
        Reklamsayisi = PlayerPrefs.GetInt("ReklamsizIntKey", 3);
    }




    private void RequestInterstitial()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void ReklamiIzle()
    {
        Show_InterstitialAd();
    }

    public void Show_InterstitialAd()
    {
        if(Reklamsayisi <= 0)
        {
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
                PlayerPrefs.SetInt("ReklamsizIntKey", 3);
            }
            else
            {
                Debug.Log("Ad calismadi.");
            }
        }
        else
        {
            User.ReklamsizMenu();
            Debug.Log(User.ReklamsizInt);
        }

        
    }



    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        /*MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);*/
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpening event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
        User.ReklamsizMenu();
    }




}
