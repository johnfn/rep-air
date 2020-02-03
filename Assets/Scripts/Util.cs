using System;
using System.Collections.Generic;
using System.Linq;

public class Util {
  public static Random rnd = new Random();

  public static T RandomElement<T>(List<T> list) {
    return list[rnd.Next(list.Count)];
  }

  public static object RandomElement<T>(Array list) {
    return list.GetValue(rnd.Next(list.Length));
  }

  public static int Random(int high) {
    return rnd.Next(high);
  }
}