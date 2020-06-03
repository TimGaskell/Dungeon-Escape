using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _Instance;
    public static UIManager Instance {
        get {
            if (_Instance == null) {
                Debug.LogError("NO UI MANAGER");
            }

            return _Instance;
        }
    }

    public Text GemCountText;
    public Image SelectionImage;
    public Text GemCountHUD;
    public Image[] healthBars;
    private void Awake() {
        _Instance = this;
    }

    /// <summary>
    /// Updates the amount of gems displayed on the HUD.
    /// </summary>
    /// <param name="count"> Int amount of gems being displayed </param>
    public void UpdateGemCount(int count) {

        GemCountHUD.text = "" + count;

    }

    /// <summary>
    /// Updates the amount of gems displayed in the shop UI
    /// </summary>
    /// <param name="count"> Int amount of gems being displayed </param>
    public void OpenShop(int GemCount) {

        GemCountText.text = "" + GemCount + "G";
    }

    /// <summary>
    /// Updates the positioning of the highlight image 
    /// </summary>
    /// <param name="yPos"> int Y position to place the image </param>
    public void UpdateShopSelection(int yPos) {

        SelectionImage.rectTransform.anchoredPosition = new Vector2(SelectionImage.rectTransform.anchoredPosition.x, yPos);
        
    }
    /// <summary>
    /// Function used for updating the Health HUD images to display how much health the player has. E.g. if player loses 1 health, the amount of enabled health images is equal to the players health.
    /// </summary>
    /// <param name="livesRemaining"> How much health the player has</param>
    public void UpdateLivesRemaining(int livesRemaining) {

        for(int i = 0; i <= livesRemaining; i++) {
            if(i == livesRemaining) {
                healthBars[i].enabled = false;
            }
        }
    }
}
