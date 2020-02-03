using System;
using UnityEngine;
using UnityEngine.UI;

public enum WeatherTypes {
  Airy,
  Alarming,
  Balmy,
  Chilly,
  Cloudy,
  Flurries,
  Hot,
  LunarEclipse,
  Muggy,
  Raining,
  Snowing,
}

[DisallowMultipleComponent]
public class TopBar: MonoBehaviour {
  public Text ChildrenText;
  public Text CoinText;
  public Text WeatherText;
  public Text StoreNameText;

  void CheckWeatherUpdate() {
    if (Util.Random(1000) == 1) {
      GameState.currentWeatherType = (WeatherTypes) Util.RandomElement<WeatherTypes>(Enum.GetValues(typeof(WeatherTypes)));
    }
  }

  void Update() {
    CheckWeatherUpdate();

    var children    = GameState.ChildrenEmployed;
    var coins       = GameState.Coins;
    var weather     = GameState.GetWeatherDescription();
    var storeName   = GameState.BusinessName;

    ChildrenText.text  = $"{ children } children";
    CoinText.text      = $"{ coins } coins";
    WeatherText.text   = $"Weather: { weather }";
    StoreNameText.text = storeName;
  }
}
