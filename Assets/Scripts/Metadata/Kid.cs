using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour {
    public Sprite icon;
    public string title;
    [TextArea(3,10)] public string description;
    public int price;
    public float reductionPercent;
}
