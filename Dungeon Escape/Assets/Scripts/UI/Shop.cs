using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public int CurrentSelectedItem;
    public int CurrentItemCost;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player") {

            player = other.GetComponent<Player>();
            if(player != null) {
                UIManager.Instance.OpenShop(player.Gems);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "Player") {

            shopPanel.SetActive(false);
        }
    }

    public void selectionItem(int item) {
        switch (item) {
            case 0: //Flame sword
                CurrentSelectedItem = 0;
                CurrentItemCost = 200;
                UIManager.Instance.UpdateShopSelection(87);
                break;
            case 1: //Boots
                CurrentSelectedItem = 1;
                CurrentItemCost = 400;
                UIManager.Instance.UpdateShopSelection(-17);
                break;
            case 2: //Key
                CurrentSelectedItem = 2;
                CurrentItemCost = 100;
                UIManager.Instance.UpdateShopSelection(-118);
                break;
        }
    }

    public void BuyItem() {

        if(player.Gems >= CurrentItemCost) {

            switch (CurrentSelectedItem) {
                case 0: //Flame sword
                
                    break;
                case 1: //Boots
                   
                    break;
                case 2: //Key
                    GameManager.Instance.HasKeyToCastle = true;
                    break;
            }

            player.Gems -= CurrentItemCost;
            Debug.Log("Purchased " + CurrentItemCost);
            shopPanel.SetActive(false);
        }
        else {
            Debug.LogError("You do not have enough gems. Closing Shop");
            shopPanel.SetActive(false);
        }
    }
}
