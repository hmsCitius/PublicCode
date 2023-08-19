using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;


public class RewardedSpecial : MonoBehaviour
{
    private RewardedAd odulluReklam;


    

    public GameObject SpecialObj;


    private void Start()
    {
        MobileAds.Initialize(InitStatus => { });
        RequestRewardAds();
    }


    public void RequestRewardAds()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif


        this.odulluReklam = new RewardedAd(adUnitId);
        

        AdRequest request = new AdRequest.Builder().Build();
        this.odulluReklam.LoadAd(request);

        this.odulluReklam.OnUserEarnedReward += OyuncuyaOdulVer;

        this.odulluReklam.OnAdClosed += ReklamiTekrarla;

    }


    public void ReklamIzlee()
    {
        ReklamIzle();
    }


    public void ReklamIzle()
    {
        
        if( (SpecialObj.GetComponent<FCP_ExampleScript>().MainMaterial.color == SpecialObj.GetComponent<FCP_ExampleScript>().material.color) || User.UserGem <= 500 )
        {
            return;
        }
        else
        {
            if (this.odulluReklam.IsLoaded())
            {
                this.odulluReklam.Show();
            }
        }
        
    }


    public void ReklamiTekrarla(object sender, EventArgs args)
    {
        RequestRewardAds();
    }



    private void OyuncuyaOdulVer(object sender, EventArgs args)
    {
        Debug.Log("Oyuncuya odul verildi.");
        Time.timeScale = 0;
        SpecialObj.GetComponent<FCP_ExampleScript>().MainRenk();
        RequestRewardAds();

    }
}