using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BigOnHover: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
  public void OnPointerEnter(PointerEventData eventData) {
    DOTween.To(() => gameObject.transform.localScale, x => gameObject.transform.localScale = x, new Vector3(1.1f, 1.1f, 1f), 0.1f);
  }

  public void OnPointerExit(PointerEventData eventData) {
    DOTween.To(() => gameObject.transform.localScale, x => gameObject.transform.localScale = x, new Vector3(1f, 1f, 1f), 0.1f);
  }
}
