using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

[DisallowMultipleComponent]
public class RandomEventDialog: MonoBehaviour {
  public Text TitleText;
  public Text DescriptionText;
  public List<Button> OptionButtons;

  private RandomEventItem currentRandomEvent;

  void ClickButton(int id) {
    gameObject.SetActive(false);

    Manager.Instance.FollowupDialog.ShowDialog(
      currentRandomEvent.options[id].followupDialog
    );
  }

  public void ShowRandomEvent(RandomEventItem randomEvent) {
    currentRandomEvent = randomEvent;
    gameObject.SetActive(true);

    TitleText.text       = currentRandomEvent.title;
    DescriptionText.text = currentRandomEvent.description;

    // visible options

    for (var i = 0; i < currentRandomEvent.options.Count; i++) {
      var option = currentRandomEvent.options[i];

      OptionButtons[i].gameObject.SetActive(true);
      OptionButtons[i].GetComponentInChildren<Text>().text = option.description;

      var copy = i; // weird c# thing
      OptionButtons[i].onClick.AddListener(() => ClickButton(copy));
    }

    // invisible options

    for (var i = currentRandomEvent.options.Count; i < OptionButtons.Count; i++) {
      OptionButtons[i].gameObject.SetActive(false);
    }
  }

  void Update() {

  }
}
