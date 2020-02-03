using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SourceMouseOver: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  public Image Tooltip;
  public SourceInfo SourceItem;

  void Start() {
    Tooltip.gameObject.SetActive(false);
  }

  public void OnPointerEnter(PointerEventData eventData) {
    Tooltip.gameObject.SetActive(true);

    Tooltip.transform.localScale = Vector3.one;
    DOTween.To(() => Tooltip.transform.localScale, x => Tooltip.transform.localScale = x, new Vector3(1.1f, 1.1f, 1f), 0.3f);
  }

  public void OnPointerExit(PointerEventData eventData) {
    Tooltip.gameObject.SetActive(false);
  }
}
