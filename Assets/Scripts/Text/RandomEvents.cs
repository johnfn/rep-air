using System.Collections.Generic;

// TODO: More predicates?

public class RandomEventOption {
  public string description;

  public int airGained      = 0;
  public int childrenGained = 0;

  public RandomEventFollowup followupDialog;
}

public class RandomEventItem {
  public string title;
  public string description;

  public List<RandomEventOption> options;
}


public struct RandomEventFollowup {
  public string description;

  public string acceptText;
}

public class RandomEvents {

  public static RandomEventItem ScaryRandomEvent = new RandomEventItem {
    title   = "A mysterious figure approaches!",
    description = "While you're manning your store, a cloaked figure approaches you. You can't make out any facial features behind the hood, and it speaks in a low gravelly tone that sets your hairs on edge and makes a nearby dog whine and run out of the building. It offers you a deal:",
    options = new List<RandomEventOption>() {
      new RandomEventOption { 
        description = "Give him a child in exchange for 100 coins.",
        followupDialog = new RandomEventFollowup { description = "The hooded figure turns away. One of the children in your employ mysteriously disappears later that night; in his bed all that can be found is a small pile of ash.", acceptText = "Umm... Okay." }
      },

      new RandomEventOption { 
        description = "Do nothing.",
        followupDialog = new RandomEventFollowup { description = "The hooded figure turns away with a disappointed sigh.", acceptText = "Okay." }
      },
    },
  };

  public static List<RandomEventItem> Events = new List<RandomEventItem> { };
}