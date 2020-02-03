using UnityEngine;
using System.Linq;

public class TabLoader : MonoBehaviour {
    public GameObject kidItem;
    public GameObject sourceItem;
    public GameObject shopItem;
    public Transform kidItemGroup;
    public Transform sourceItemGroup;
    public Transform shopItemGroup;

    // Start is called before the first frame update
    void Start() {
        loadKids();
        loadSources();
        loadShops();

        Destroy(this.gameObject);
    }

    private void loadKids() {
        var kids = Resources.LoadAll("Kids", typeof(Kid)).Cast<Kid>().ToArray();

        foreach (var kid in kids) {
            GameState.PurchasedKids[kid.title] = new KidInfo {
                amountBought = 0,
                price        = kid.price,
                reduction    = kid.reductionPercent
            };

            var newKid = Instantiate(kidItem, kidItemGroup).GetComponent<KidItem>();
            newKid.loadKid(kid);
        }
    }

    private void loadSources() {
        var sources = Resources.LoadAll("Sources", typeof(Source)).Cast<Source>().ToArray();

        foreach (var source in sources) {
            bool unlocked = source.unlockPrice == 0;
            GameState.PurchasedSources[source.title] = new SourceInfo {
                image  = source.icon,
                bought = unlocked,
                price  = source.unlockPrice,
                kidsGoingHere = 0,
                value = source.value,
                danger = source.dangerPercent
            };

            var newSource = Instantiate(sourceItem, sourceItemGroup).GetComponent<SourceItem>();
            newSource.loadSource(source, unlocked);
        }
    }

    private void loadShops() {
        var shops = Resources.LoadAll("Shops", typeof(Shop)).Cast<Shop>().ToArray();

        foreach (var shop in shops) {
            bool unlocked = shop.unlockPrice == 0;

            string[] sources = new string[shop.acceptedSources.Length];
            for(int i = 0; i < sources.Length; i++){
                sources[i] = shop.acceptedSources[i].title;
            }

            GameState.PurchasedShops[shop.title] = new ShopInfo {
                bought = unlocked,
                level  = unlocked ? 1 : 0,
                price  = new int[] {shop.unlockPrice, shop.twoStarPrice, shop.threeStarPrice },
                acceptedSources = sources,
                triggerChance = shop.triggerChance
            };

            var newShop = Instantiate(shopItem, shopItemGroup).GetComponent<ShopItem>();
            newShop.loadShop(shop, unlocked);
        }
    }
}
