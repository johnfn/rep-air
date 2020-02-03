using UnityEngine;

[DisallowMultipleComponent]
public class Manager: MonoBehaviour {
  public static Manager Instance;

  public RandomEventFollowupDialog FollowupDialog;
  public RandomEventDialog RandomEventDialog;

  public MainMenu MainMenu;
  public NameSelectDialog NameSelectDialog;
  public BuyKidDialog BuyKidDialog;

  public bool DebugRandomEvent;
  public bool DebugMainMenu;
  public bool ProductionBuild;

  public bool PlayMusic;

  public int StartingCoins = 50;

  public static float GameWidthInUnits() {
    return GameHeightInUnits() * Camera.main.aspect;
  }

  public static float GameHeightInUnits() {
    return Camera.main.orthographicSize * 2.0f;
  }

  public static float GameWidthInPixels() {
    return Camera.main.pixelWidth;
  }

  public static float GameHeightInPixels() {
    return Camera.main.pixelHeight;
  }

  void Awake() {
    Screen.fullScreen = false;

    int width = 1920; // or something else
    int height = 1080; // or something else
    bool isFullScreen = false; // should be windowed to run in arbitrary resolution
    int desiredFPS = 60; // or something else

    Screen.SetResolution(width, height, isFullScreen, desiredFPS);

    if (Instance != null) {
      Debug.LogError("There's already a manager");
    }

    Instance = this;
  }

  void Start() {
    if (DebugRandomEvent) {
      RandomEventDialog.ShowRandomEvent(RandomEvents.ScaryRandomEvent);
    }

    GameState.Coins = StartingCoins;

    BuyKidDialog.gameObject.SetActive(false);

    if (DebugMainMenu || ProductionBuild) {
      MainMenu.gameObject.SetActive(true);
    } else {
      MainMenu.gameObject.SetActive(false);
    }

    NameSelectDialog.gameObject.SetActive(false);
  }

  void Update() {
  }
}
