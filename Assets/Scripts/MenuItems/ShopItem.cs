using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Image iconImage;
    public Text nameText;
    public Text descriptionText;
    public Text buyText;
    public Image starImage;
    public CanvasGroup canvasGroup;
    public Button buyButton;

    public Sprite[] starImages = new Sprite[3];

    private int[] purchaseCost = { 0, 0, 0 }; //(0 = unlock, 1 = 2star, 2 = 3star)
    private string title;

    private bool everCloseToAffordable = false;

    public void loadShop(Shop shop, bool unlocked){
        iconImage.sprite = shop.icon;
        nameText.text = shop.title;
        descriptionText.text = shop.description;

        if (!unlocked){
            buyText.text = "$" + shop.unlockPrice + " Buy";
            canvasGroup.alpha = .5f;
        } else {
            everCloseToAffordable = true;

            buyText.text = "$" + shop.twoStarPrice + " Upgrade";
            starImage.sprite = starImages[0];
            canvasGroup.alpha = 1;
        }

        this.purchaseCost[0] = shop.unlockPrice;
        this.purchaseCost[1] = shop.twoStarPrice;
        this.purchaseCost[2] = shop.threeStarPrice;

        this.title = shop.title;
    }

    public void tryToBuy(){
        int currentLevel = GameState.PurchasedShops[title].level;

        if (currentLevel < 3){
            if (GameState.PurchasedShops[title].price[currentLevel] <= GameState.Coins){
                GameState.Coins -= GameState.PurchasedShops[title].price[currentLevel];
                currentLevel = ++GameState.PurchasedShops[title].level;
                starImage.sprite = starImages[currentLevel - 1];

                if (!GameState.PurchasedShops[title].bought){
                    GameState.PurchasedShops[title].bought = true;
                    buyText.text = "$" + GameState.PurchasedShops[title].price[currentLevel] + " Buy";
                    canvasGroup.alpha = 1;
                }

                if (currentLevel == 3) {
                    buyText.text = "MAXED";
                    buyText.transform.GetComponentInParent<Button>().interactable = false;
                }
            }
        }
    }

    int getPrice() {
        int currentLevel = GameState.PurchasedShops[title].level;

        if (currentLevel == 3) {
            // nothing to do
            return -1;
        }

        return purchaseCost[currentLevel];
    }

    void Update() {
        var price  = getPrice();
        var canBuy = price < GameState.Coins;

        if (everCloseToAffordable) {
            canvasGroup.alpha      = canBuy ? 1f : 0.5f;
            buyButton.interactable = canBuy;

            transform.localScale = Vector3.one;
        } 

        if (!everCloseToAffordable) {
            if (((float) GameState.Coins) / ((float) price) > 0.5f) {
                everCloseToAffordable = true;
            }

            if (canBuy) {
                canvasGroup.alpha = 1;
                transform.localScale = Vector3.one;
            } else {
                transform.localScale = Vector3.zero;
            }
        }
    }
}
