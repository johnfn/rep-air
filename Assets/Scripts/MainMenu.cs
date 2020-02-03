using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MainMenu: MonoBehaviour {
  public Button SelectName;

  void Start() {
    SelectName.onClick.AddListener(() => ClickSelectName());
  }

  void ClickSelectName() {
    Manager.Instance.NameSelectDialog.gameObject.SetActive(true);
  }
}
