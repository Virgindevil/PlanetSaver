using System;
using GoogleMobileAds.Api;
using UnityEngine;
using Zenject;

public class AdManager : ITickable
{
    private InterstitialAd _interstitialAd;
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";

    public event Action OnAdClosedMainThread;

    private bool _needsToNotify = false;

    public void LoadInterstitialAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        var adRequest = new AdRequest();
        InterstitialAd.Load(_adUnitId, adRequest, (ad, error) =>
        {
            if (error != null) return;
            _interstitialAd = ad;

            _interstitialAd.OnAdFullScreenContentClosed += () => _needsToNotify = true;
        });
    }

    public void Tick()
    {
        if (_needsToNotify)
        {
            _needsToNotify = false; 
           
            OnAdClosedMainThread?.Invoke(); 

            LoadInterstitialAd(); 
        }
    }

    public void ShowAd() => _interstitialAd?.Show();
    public bool IsAdCanBeShowed() => _interstitialAd != null && _interstitialAd.CanShowAd();
}
