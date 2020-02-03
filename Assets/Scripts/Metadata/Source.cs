using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source: MonoBehaviour {
    public Sprite icon;
    public string title;
    [TextArea(3,10)] public string description;
    public int unlockPrice;
    public int value;
    public float dangerPercent;
}
