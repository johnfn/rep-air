using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class RandomEventFollowupDialog: MonoBehaviour {
  public Text Text;
  public Button Button;

  void Start() {
  }

  public void ShowDialog(RandomEventFollowup eventItem) {
    gameObject.SetActive(true);

    Text.text = eventItem.description;
    Button.GetComponentInChildren<Text>().text = eventItem.acceptText;

    Button.onClick.AddListener(() => CloseDialog());
  }

  void CloseDialog() {
    gameObject.SetActive(false);
  }
}
