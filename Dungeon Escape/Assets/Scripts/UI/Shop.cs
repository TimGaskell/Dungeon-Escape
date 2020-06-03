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

    /// <summary>
    /// Button function used to determine which item in the shop the player has currently selected. It updates the item cost being selected, the item and repositions the UI to hover the item.
    /// </summary>
    /// <param name="item"> int selected item id </param>
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

    /// <summary>
    /// Button function used for buying the currently selected item in the shop. If the player has enough gems it will award the item, subtract its cost from the players total and exit.
    /// If the player does not have enough gems, the shop will automatically close.
    /// </summary>
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
