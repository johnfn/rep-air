using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockItemGroup : MonoBehaviour {
    
    public GameObject stockItem;

    private Dictionary<string, StockItem> stockItems = new Dictionary<string, StockItem>();

    public void addToStock(string airSource, int count){
        if(stockItems.ContainsKey(airSource)){
            stockItems[airSource].addToCount(count);
        }
        else{
            genStock(airSource, count);
        }
    }

    public void setStock(string airSource, int count){
        if(stockItems.ContainsKey(airSource)){
            stockItems[airSource].updateCount(count);
        }
        else{
            genStock(airSource, count);
        }
    }

    private void genStock(string airSource, int count){
        StockItem newStock = Instantiate(stockItem, this.transform).GetComponent<StockItem>();
        newStock.loadStock(GameState.PurchasedSources[airSource].image, airSource, count); //TODO fix this
        newStock.updateCount(count);
        stockItems.Add(airSource, newStock);
    }

    public bool hasStock(string airSource){
        return stockItems.ContainsKey(airSource) && stockItems[airSource].count > 0;
    }
}
