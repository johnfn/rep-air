using UnityEngine;
using UnityEngine.UI;

public class ParallaxIt: MonoBehaviour {
  public Image Layer1;
  public Image Layer2;
  public Image Layer3;
  public Image Layer4;

  private float initialX1;
  private float initialX2;
  private float initialX3;
  private float initialX4;

  private float initialY1;
  private float initialY2;
  private float initialY3;
  private float initialY4;

  void Start() {
    initialX1 = Layer1.rectTransform.anchoredPosition.x;
    initialX2 = Layer2.rectTransform.anchoredPosition.x;
    initialX3 = Layer3.rectTransform.anchoredPosition.x;
    initialX4 = Layer4.rectTransform.anchoredPosition.x;

    initialY1 = Layer1.rectTransform.anchoredPosition.y;
    initialY2 = Layer2.rectTransform.anchoredPosition.y;
    initialY3 = Layer3.rectTransform.anchoredPosition.y;
    initialY4 = Layer4.rectTransform.anchoredPosition.y;
  }

  void Update() {
    if (Manager.Instance.NameSelectDialog.isActiveAndEnabled) { return; }
    var screenWidth = 1920;
    var screenHeight = 1080;

    var parallaxAmount = ((float) Input.mousePosition.x) / ((float) screenWidth) - 0.5f;
    var parallaxAmountY = ((float) Input.mousePosition.y) / ((float) screenHeight) - 0.5f;

    Layer1.rectTransform.anchoredPosition = new Vector2(initialX1 + parallaxAmount * 10f , initialY1 + parallaxAmountY * 10f);
    Layer2.rectTransform.anchoredPosition = new Vector2(initialX2 + parallaxAmount * 50f , initialY2 + parallaxAmountY * 20f);
    Layer3.rectTransform.anchoredPosition = new Vector2(initialX3 + parallaxAmount * 100f, initialY3 + parallaxAmountY * 30f);
    Layer4.rectTransform.anchoredPosition = new Vector2(initialX4 + parallaxAmount * 300f, initialY4 + parallaxAmountY * 40f);
  }
}
