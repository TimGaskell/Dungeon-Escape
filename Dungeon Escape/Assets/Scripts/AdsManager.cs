using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener {

    string gameId = "3624002";
    string myPlacementID = "rewardedVideo";
    bool testMode = true;

    private void Start() {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowRewardedAd() {

        Advertisement.Show(myPlacementID);

        
    }

    public void OnUnityAdsReady(string placementId) {
        Debug.Log("Ad ready");
    }

    public void OnUnityAdsDidError(string message) {
        Debug.Log("Ad Error " + message);
    }

    public void OnUnityAdsDidStart(string placementId) {
        Debug.Log("Started AD");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
       
            switch (showResult) {

                case ShowResult.Finished:

                    break;
                case ShowResult.Skipped:
                    Debug.Log("You skipped the AD. NO gems for you");
                    break;
                case ShowResult.Failed:
                    Debug.Log("Video has failed");
                    break;

            }
        
    }
}