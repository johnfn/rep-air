using UnityEngine;
using UnityEngine.UI;

public class SourceItem : MonoBehaviour {
    public Image iconImage;
    public Text nameText;
    public Text descriptionText;
    public Text buyText;
    public Button buyButton;
    public CanvasGroup canvasGroup;

    private int unlockPrice = 0;
    private string title;
    private bool everCloseToAffordable = false;

    public void loadSource(Source source, bool unlocked) {
        D.Log(source.icon);

        iconImage.sprite     = source.icon;
        nameText.text        = source.title;
        descriptionText.text = source.description;

        this.unlockPrice = source.unlockPrice;
        this.title = source.title;

        if (unlocked) {
            everCloseToAffordable = true;
            setBought();
        } else {
            buyText.text = "$" + source.unlockPrice + " Buy";
            canvasGroup.alpha = .5f;
        }
    }

    public void tryToBuy() {
        var info = GameState.PurchasedSources[title];
        
        if (!info.bought && info.price <= GameState.Coins) {
            GameState.Coins -= info.price;
            info.bought = true;
            setBought();
        }
    }

    public void setBought(){
        buyButton.gameObject.SetActive(false);

        canvasGroup.alpha = 1;

        var info = GameState.PurchasedSources[title];
        info.bought = true;
    }

    void Update() {
        var price  = unlockPrice;
        var canBuy = price < GameState.Coins;

        if (everCloseToAffordable) {
            canvasGroup.alpha      = canBuy ? 1f : 0.5f;
            buyButton.interactable = canBuy;

            transform.localScale   = Vector3.one;
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
