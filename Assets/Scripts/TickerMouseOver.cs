using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TickerMouseOver: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {
  public GameObject Tooltip;
  public SourceInfo SourceItem;

  private Color prevColor;

  void Start() {
  }

  public void OnPointerEnter(PointerEventData eventData) {
    prevColor = GetComponent<Text>().color;

    GetComponent<Text>().color = Color.white;
  }

  public void OnPointerExit(PointerEventData eventData) {
    GetComponent<Text>().color = prevColor;
  }

  public void OnPointerDown(PointerEventData eventData) {
    Manager.Instance.RandomEventDialog.ShowRandomEvent(RandomEvents.ScaryRandomEvent);
  }
}