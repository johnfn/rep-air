using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class BuyKidDialog: MonoBehaviour {
  public Button LocationButtonToBeCloned;
  public Button Cancel;
  public Text TitleText;

  public List<Button> clonedButtons;

  void Start() {
    LocationButtonToBeCloned.enabled = false;

    Cancel.onClick.AddListener(() => CancelClick());
  }

  void LocationOneClick() {

  }

  public void ShowDialog(Kid kid) {
    gameObject.SetActive(true);

    TitleText.GetComponentInChildren<Text>().text = $"SEND A POOR DEFENSELESS { kid.title } WITH TO GET AIR FOR YOU - ${ kid.price }";

    LocationButtonToBeCloned.enabled = false;

    var i = 0;

    foreach (var pair in GameState.PurchasedSources) {
      var name = pair.Key;
      var info = pair.Value;

      if (!info.bought) { continue; }

      var newButton = GameObject.Instantiate(
        LocationButtonToBeCloned,
        LocationButtonToBeCloned.transform.position,
        Quaternion.identity,
        LocationButtonToBeCloned.transform.parent
      );

      var rectTransform = newButton.GetComponent<RectTransform>();

      rectTransform.anchoredPosition -= new Vector2(0f, i * 100f);

      newButton.enabled = true;
      newButton.GetComponentInChildren<Text>().text = $"{ name }";

      newButton.onClick.AddListener(() => BuyChild(kid, name, info));

      clonedButtons.Add(newButton);

      ++i;
    }
  }

  void BuyChild(Kid whichKid, string airSource, SourceInfo sourceInfo) {
    GameState.Coins -= whichKid.price;
    GameState.PurchasedKids[whichKid.title].amountBought += 1;
    GameManager.instance.AddHarvester(airSource, whichKid.reductionPercent);

    Close();
  }

  void CancelClick() {
    Close();
  }

  void Close() {
    gameObject.SetActive(false);

    foreach (var button in clonedButtons) {
      Destroy(button.gameObject);
    }

    clonedButtons.Clear();
  }
}
