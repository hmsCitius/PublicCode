using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;


public class RewardedManager : MonoBehaviour
{
    private RewardedAd odulluReklam;
    
    
    private int KalanReklamInt;

    



    private void Start()
    {
        MobileAds.Initialize(InitStatus => { });
        RequestAd();
    }


    private void RequestAd()
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

        
        

        KalanReklamInt = PlayerPrefs.GetInt("ReklamKey", 10);
    }
    



    public void ReklamIzle()
    {
        
        if (this.odulluReklam.IsLoaded())
        {
            this.odulluReklam.Show();
        }
    }

    


    private void OyuncuyaOdulVer(object sender,Reward e)
    {
        Debug.Log("Oyuncuya odul verildi.");
        Time.timeScale = 0;
        KalanReklamInt -= 1;
        PlayerPrefs.SetInt("ReklamKey", KalanReklamInt);
        User.UserGem -= 100;
        RequestAd();
    }


    


}
