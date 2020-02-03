using System.Collections.Generic;
using UnityEngine;

// TODO: Add some sort of predicate thing
// TODO: Interpolate $ShopName and maybe other variables
public class TickerTextItem {
  public string message;
  public RandomEventItem randomEvent = null;
  public Color color = Color.white;

  public bool showOnlyOnce = false;
  public string id = null;
  public string requiredId = null;
}

public class NewsTickerText {
  public static List<TickerTextItem> AllText = new List<TickerTextItem> {
    new TickerTextItem { 
      message     = "A cloaked figure beckons you near...",
      randomEvent = RandomEvents.ScaryRandomEvent,
      color       = new Color(1f, 0.5f, 0.5f, 1f),
    },

    new TickerTextItem { message = "$ShopName opens new air store; citizens of nearby town mostly confused" },
    new TickerTextItem { message = "Citizen of Shacktown purchases air, tells friend 'it's pretty much just air'" },
    new TickerTextItem { message = "Citizen of Shacktown confuses ziploc bag of air for empty ziploc bag, wanders out of store" },
    new TickerTextItem { message = "Citizen of Shacktown considers purchasing air, changes mind" },
    new TickerTextItem { message = "Citizen of Shacktown considers $ShopName a bunch of hot air, but in a bad way" },
    new TickerTextItem { message = "Shaq visits Shacktown; hundreds confused" },
    new TickerTextItem { message = "Scientists ponder potentially curative effects of brocolli" },
    new TickerTextItem { message = "Weather in the Himalayas looks beautiful today" },
    new TickerTextItem { message = "New scientific study finds certain authors of news tickers could really use a vacation right about now" },
    new TickerTextItem { message = "$ShopName's success causes despair in famous air heir" },
    new TickerTextItem { message = "Famous air CEO accused of putting on airs!" },

    new TickerTextItem { message = "Did you know? If this message is colored, you can click on it!" },
    new TickerTextItem { message = "Did you know? Different citizens have different air preferences." },
    new TickerTextItem { message = "Did you know? Child labor is unlawful." },
    new TickerTextItem { message = "Did you know? Nobody could make a game in 48 hours." },
    new TickerTextItem { message = "Did you know? Juneau is the capital of Alaska." },
    new TickerTextItem { message = "Did you know? Lamps are a source of light." },
    new TickerTextItem { message = "Did you know? Light is a source of lamps." },
    new TickerTextItem { message = "Did you know? There are many things you can do with air." },
    new TickerTextItem { message = "Did you know? You can breathe air." },
    new TickerTextItem { message = "Did you know? Don't despAIR." },
    new TickerTextItem { message = "Did you know? Brocolli is spelled brocolli." },

    new TickerTextItem { id="air1",                    message = "Did you know? Air consists of an oxygen molecule, and an oxygen molecule." },
    new TickerTextItem { id="air2", requiredId="air1", message = "Did you know? Air is 20% air." },
    new TickerTextItem { id="air3", requiredId="air2", message = "Did you know? Air is all you need to live." },
    new TickerTextItem { id="air4", requiredId="air3", message = "Did you know? Air is a gas." },
    new TickerTextItem { id="air5", requiredId="air4", message = "Did you know? Air is one of the four classical elements, along with fire, water, and air." },
    new TickerTextItem { id="air6", requiredId="air5", message = "Did you know? Air is made of 100% air." },
    new TickerTextItem { id="air7", requiredId="air6", message = "Did you know? Air is made of 50% air." },
    new TickerTextItem { id="air8", requiredId="air7", message = "Did you know? Air is air.        I think." },
    new TickerTextItem { id="air9", requiredId="air8", message = "Did you know? Air consists of two air orbiting around a central air, all bound together by the strong electroair force." },

    new TickerTextItem { id="red1",                    showOnlyOnce=true, message = "Did you know? Red is a color." },
    new TickerTextItem { id="red2", requiredId="red1", showOnlyOnce=true, message = "Did you know? The previous message was wrong. Red isn't a color." },
    new TickerTextItem { id="red3", requiredId="red2", showOnlyOnce=true, message = "Did you know? Disregard all previously seen messages about red. Red is in fact a color." },
    new TickerTextItem { id="red4", requiredId="red3", showOnlyOnce=true, message = "Did you know? Scientists consider red to be a rare breed of dog." },
    new TickerTextItem { id="red5", requiredId="red4", showOnlyOnce=true, message = "Did you know? Please, please ignore all messages you've seen about red. Red is not a dog." },
    new TickerTextItem { id="red6", requiredId="red5", showOnlyOnce=true, message = "Did you know? Children love the color red." },
    new TickerTextItem { id="red7", requiredId="red6", showOnlyOnce=true, message = "Did you know? Children are actually pretty neutral about red." },
    new TickerTextItem { id="red8", requiredId="red7", showOnlyOnce=true, message = "Did you know? Children HATE red." },

    new TickerTextItem { message = "Mysterious air shortages reported in Beijing!" },
    new TickerTextItem { message = "Mysterious air shortages reported in the Pacific Ocean!" },

    new TickerTextItem { message = "Harvesting air from water still out of the reach of science" },

    new TickerTextItem { message = "New scientific report just in: Oxford comma deemed useful and handy!" },
    new TickerTextItem { message = "New scientific report just in: Breathing is useful." },
    new TickerTextItem { message = "New scientific report just in: Water is air for fish." },
    new TickerTextItem { message = "New scientific report just in: Polluted air may shorten lifespan!" },
    new TickerTextItem { message = "New scientific report just in: Fancy air has no obvious health benefits!" },

    new TickerTextItem { message = "Reading tickers too much considered bad for health!" },

    new TickerTextItem { id="paper1" ,                      showOnlyOnce = true, message = "This just in: scientists finish first page of 10 page paper about air." },
    new TickerTextItem { id="paper2" , requiredId="paper1", showOnlyOnce = true, message = "This just in: scientists finish second page of 10 page paper about air." },
    new TickerTextItem { id="paper3" , requiredId="paper2", showOnlyOnce = true, message = "This just in: scientists finish third page of 10 page paper about air." },
    new TickerTextItem { id="paper4" , requiredId="paper3", showOnlyOnce = true, message = "This just in: scientists finish fourth page of 10 page paper about air." },
    new TickerTextItem { id="paper5" , requiredId="paper4", showOnlyOnce = true, message = "This just in: scientists finish fifth page of 10 page paper about air." },
    new TickerTextItem { id="paper6" , requiredId="paper5", showOnlyOnce = true, message = "This just in: scientists finish sixth page of 10 page paper about air." },
    new TickerTextItem { id="paper7" , requiredId="paper6", showOnlyOnce = true, message = "This just in: scientists have breakthrough, finish seventh and eighth page of 10 page paper about air." },
    new TickerTextItem { id="paper8" , requiredId="paper7", showOnlyOnce = true, message = "This just in: scientists finish ninth page of 10 page paper about air." },
    new TickerTextItem { id="paper9" , requiredId="paper8", showOnlyOnce = true, message = "This just in: scientists finish tenth page of 10 page paper about air, but other scientist loses it!" },
    new TickerTextItem { id="paper10", requiredId="paper9", 
      message = "This just in: scientists finish tenth page of 10 page paper again, invent incredible air producing machine!" 
    },



    // // new TickerTextItem { message = "Small child swims across Pacific ocean to climb Mt. Everest for a bag of air" },
  };
}