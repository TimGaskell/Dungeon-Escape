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

    /// <summary>
    /// Launches a Unity Ad to be played in the scene.
    /// </summary>
    public void ShowRewardedAd() {
        Advertisement.Show(myPlacementID);
        
    }

    /// <summary>
    /// Determines if an Ad is ready to be played in the game.
    /// </summary>
    /// <param name="placementId"> String type of video ad </param>
    public void OnUnityAdsReady(string placementId) {
        Debug.Log("Ad ready");
    }

    /// <summary>
    /// Gives an error message based on what went wrong with the Ad
    /// </summary>
    /// <param name="message"> String error message </param>
    public void OnUnityAdsDidError(string message) {
        Debug.Log("Ad Error " + message);
    }

    /// <summary>
    /// Determines if the Ad has started playing yet.
    /// </summary>
    /// <param name="placementId">String type of video ad </param>
    public void OnUnityAdsDidStart(string placementId) {
        Debug.Log("Started AD");
    }

    /// <summary>
    /// Gives the result of the Unity Ad. Determines if the Ad finished, was skipped or failed to be played.
    /// </summary>
    /// <param name="placementId"> String type of video ad </param>
    /// <param name="showResult"> Enum ShowResult of the Ads result </param>
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) {
       
            switch (showResult) {

                case ShowResult.Finished:
                    GameManager.Instance.player.AddGems(100);
                    UIManager.Instance.OpenShop(GameManager.Instance.player.Gems);
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