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

    public void UpdateGemCount(int count) {

        GemCountHUD.text = "" + count;

    }

    public void OpenShop(int GemCount) {

        GemCountText.text = "" + GemCount + "G";
    }

    public void UpdateShopSelection(int yPos) {

        SelectionImage.rectTransform.anchoredPosition = new Vector2(SelectionImage.rectTransform.anchoredPosition.x, yPos);
        
    }
    public void UpdateLivesRemaining(int livesRemaining) {

        for(int i = 0; i <= livesRemaining; i++) {
            if(i == livesRemaining) {
                healthBars[i].enabled = false;
            }
        }
    }
}
