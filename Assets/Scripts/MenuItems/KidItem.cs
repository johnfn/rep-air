using UnityEngine;
using UnityEngine.UI;

public class KidItem: MonoBehaviour {
    public Image iconImage;
    public Text nameText;
    public Text descriptionText;
    public Text buyText;
    public Button buyButton;

    private Kid kid;
    private CanvasGroup canvasGroup;

    // has this ever been in the range of affordability? we will use this to determine if we can see this kid.
    private bool everCloseToAffordable = false;

    void Start() {
        buyButton.onClick.AddListener(() => ClickBuy());
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void loadKid(Kid kid) {
        iconImage.sprite     = kid.icon;
        nameText.text        = kid.title;
        descriptionText.text = kid.description;
        buyText.text         = "$" + kid.price + " Buy";
        this.kid = kid;
    }

    public void ClickBuy() {
        Manager.Instance.BuyKidDialog.ShowDialog(kid);
    }

    void Update() {
        var canBuy = kid.price < GameState.Coins;

        if (everCloseToAffordable) {
            canvasGroup.alpha = canBuy ? 1f : 0.5f;
            buyButton.interactable = canBuy;

            canvasGroup.transform.localScale = Vector3.one;
        } 

        if (!everCloseToAffordable) {
            if (((float) GameState.Coins) / ((float) kid.price) > 0.5f) {
                everCloseToAffordable = true;
            }

            if (canBuy) {
                canvasGroup.alpha = 1;
                canvasGroup.transform.localScale = Vector3.one;
            } else {
                canvasGroup.transform.localScale = Vector3.zero;
            }
        }
    }
}