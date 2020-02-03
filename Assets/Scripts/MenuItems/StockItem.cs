using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockItem : MonoBehaviour {
    public Image iconImage;
    public Text nameText;
    public Text countText;

    public int count;

    public void loadStock(Sprite icon, string title, int count){
        iconImage.sprite = icon;
        nameText.text = title;
        this.count = count;
        updateCount(count);
    }

    public void updateCount(int newCount){
        count = newCount;
        countText.text = count.ToString();
    }

    public void addToCount(int added){
        count += added;
        if(count < 0){
            count = 0;
        }
        countText.text = count.ToString();
    }
}
