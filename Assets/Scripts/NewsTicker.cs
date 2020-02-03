using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

struct NewsTickerItem {
  public string message;

  public float pixelWidth;

  public Text textObject;
}

[DisallowMultipleComponent]
public class NewsTicker: MonoBehaviour {
  public Text textToBeCloned;

  public float newsTickerSpeed = 1f;

 [Header("Spacing between ticker elements")]
  public float paddingWidthInPixels = 10f;

  private List<NewsTickerItem> texts = new List<NewsTickerItem>();

  private Vector3 tickerTopLeft;

  private float screenWidthInPixels;

  public Dictionary<string, bool> allSeenIds    = new Dictionary<string, bool>();

  void Start() {
    screenWidthInPixels = Manager.GameWidthInPixels();

    tickerTopLeft = textToBeCloned.transform.position;
    textToBeCloned.enabled = false;

    AddNewNewsTickerText();
  }

  private TickerTextItem ChooseTickerText() {
    TickerTextItem candidate;
    bool valid = true;

    do {
      candidate = Util.RandomElement(NewsTickerText.AllText);
      valid = true;

      if (candidate.requiredId != null) {
        if (!allSeenIds.ContainsKey(candidate.requiredId)) {
          valid = false;
        }
      }

      if (candidate.id != null && allSeenIds.ContainsKey(candidate.id) && candidate.showOnlyOnce) {
        valid = false;
      }
    } while (!valid);

    if (candidate.id != null) {
      allSeenIds[candidate.id] = true;
    }

    return candidate;
  }

  void AddNewNewsTickerText() {
    var textItem = ChooseTickerText();
    var newMessage = textItem.message.Replace("$ShopName", GameState.BusinessName);

    var newText = GameObject.Instantiate(
      textToBeCloned,
      tickerTopLeft,
      Quaternion.identity,
      textToBeCloned.transform.parent
    );

    newText.enabled = true;
    newText.text = newMessage;

    newText.rectTransform.anchoredPosition = new Vector3(
      rightMostTickerTextPosition() + paddingWidthInPixels, 
      10f, 
      0f
    );

    newText.color = textItem.color;

    if (textItem.randomEvent != null) {
      newText.gameObject.AddComponent(typeof(TickerMouseOver));
    } 

    textToBeCloned.enabled = false;

    var textGen = new TextGenerator();
    var generationSettings = newText.GetGenerationSettings(newText.rectTransform.rect.size); 
    var pixelWidth = textGen.GetPreferredWidth(newMessage, generationSettings);

    texts.Add(
      new NewsTickerItem {
        message    = newMessage,
        pixelWidth = pixelWidth,
        textObject = newText,
      }
    );
  }

  float totalTickerWidth() {
    var width = 0f;

    foreach (var obj in texts) {
      width += obj.pixelWidth;
    }

    return width;
  }

  float getTextRight(NewsTickerItem text) {
    return (
      text.textObject.rectTransform.anchoredPosition.x + 
      text.pixelWidth
    );
  }

  float rightMostTickerTextPosition() {
    if (texts.Count == 0) {
      return 0f;
    }

    return getTextRight(texts.Last());
  }

  void Update() {
    // Do we need to add more items to the ticker?

    var count = 0;

    while (rightMostTickerTextPosition() < screenWidthInPixels) {
      AddNewNewsTickerText();

      if (++count > 5) {
        break;
      }
    }

    // Animate

    foreach (var obj in texts) {
      obj.textObject.rectTransform.anchoredPosition += new Vector2(newsTickerSpeed * Time.deltaTime, 0f);
    }

    // Remove texts which are off the side of the screen

    var textsToRemove = texts.Where(text => getTextRight(text) < 0).ToList(); 

    foreach (var textToRemove in textsToRemove) {
      Destroy(
        textToRemove.textObject.gameObject
      );
    }

    texts = texts.Where(text => getTextRight(text) > 0).ToList();
  }
}
