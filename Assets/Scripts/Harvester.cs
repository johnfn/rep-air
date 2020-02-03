using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvester : MonoBehaviour{
    public float tripLength = 1; //in days
    public float days = 0; 
    public string airSource;
    public int harvestQuantity = 5;

    private Vector2 startPos;
    private Vector2 endPos;
    public float reduction;

    public Sprite roundTrip;
    bool flipped;

    void Start(){
        RectTransform start = transform.parent.GetChild(0).GetComponent<RectTransform>();
        RectTransform end = transform.parent.GetChild(1).GetComponent<RectTransform>();
        startPos = start.localPosition;
        endPos = end.localPosition;
    }

    public void setairSource(string airSource){
        this.airSource = airSource;
    }

    public void setReduction(float reduction){
        this.reduction = reduction;
    }

    public void updatePosition(){
        float ratio = days/tripLength;
        if(ratio > .5){
            if(!flipped){
                GetComponent<Image>().sprite = roundTrip;
                flipped = true;
            }
            GetComponent<RectTransform>().localPosition = Vector2.Lerp(endPos, startPos, ratio*2 - 1);
        }
        else{
            GetComponent<RectTransform>().localPosition = Vector2.Lerp(startPos, endPos, ratio*2);
        }
    }
}