using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class NameSelectDialog: MonoBehaviour {
  public Button PlayGame;
  public InputField BusinessNameInput;

  void Start() {
    PlayGame.onClick.AddListener(() => ClickPlayGame());
  }

  void ClickPlayGame() {
    GameState.GameStarted = true;
    GameState.BusinessName = BusinessNameInput.text;

    Manager.Instance.NameSelectDialog.gameObject.SetActive(false);
    Manager.Instance.MainMenu.gameObject.SetActive(false);
  }
}
