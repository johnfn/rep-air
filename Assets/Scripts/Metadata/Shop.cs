using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Sprite icon;
    public string title;
    [TextArea(3,10)] public string description;
    public int unlockPrice;
    public int twoStarPrice;
    public int threeStarPrice;
    public Source[] acceptedSources;
    public float triggerChance;
}
