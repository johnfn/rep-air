using UnityEngine;
using System.Collections.Generic;

public class SourceInfo {
  public Sprite image;
  public bool bought;
  public int price;
  public int kidsGoingHere;
  public int value;
  public float danger;
}

public class KidInfo {
  public int amountBought;
  public int price;
  public float reduction;
}

public class ShopInfo {
  public bool bought;
  public string[] acceptedSources;
  public float triggerChance;

  // 0 to 3
  public int level;

  public int[] price; //To get to levels 1, 2, 3
}

public class StockInfo {
  public int count;
}

public class GameState {
  public static Dictionary<string, SourceInfo> PurchasedSources = new Dictionary<string, SourceInfo>();
  public static Dictionary<string, KidInfo>    PurchasedKids    = new Dictionary<string, KidInfo>();
  public static Dictionary<string, ShopInfo>   PurchasedShops   = new Dictionary<string, ShopInfo>();
  public static Dictionary<string, StockInfo>  InStock          = new Dictionary<string, StockInfo>();

  public static List<Harvester> Harvesters                      = new List<Harvester>();

  public static WeatherTypes currentWeatherType = WeatherTypes.Airy;

  public static bool GameStarted = false;

  public static string BusinessName = "Unimaginitive Business";

  public static int ChildrenEmployed = 0;

  public static int Coins;

  public static string GetWeatherDescription() {
    if (currentWeatherType == WeatherTypes.Alarming) { return "Alarming!"; }
    if (currentWeatherType == WeatherTypes.Airy) { return "Airy"; }
    if (currentWeatherType == WeatherTypes.Balmy) { return "Balmy"; }
    if (currentWeatherType == WeatherTypes.Chilly) { return "Chilly"; }
    if (currentWeatherType == WeatherTypes.Cloudy) { return "Cloudy"; }
    if (currentWeatherType == WeatherTypes.Flurries) { return "Flurries"; }
    if (currentWeatherType == WeatherTypes.Hot) { return "Hot"; }
    if (currentWeatherType == WeatherTypes.LunarEclipse) { return "Lunar Eclipse!"; }
    if (currentWeatherType == WeatherTypes.Muggy) { return "Muggy"; }
    if (currentWeatherType == WeatherTypes.Raining) { return "Raining"; }
    if (currentWeatherType == WeatherTypes.Snowing) { return "Snowing"; }

    Debug.LogError("unknown weather type " + currentWeatherType.ToString());

    return "";
  }

  // public static bool Purchased

  public static float bonusPerShopLevel = .15f;
  public static int casulties = 0;
}