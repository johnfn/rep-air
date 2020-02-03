using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager instance = null;

    public AudioSource audioSource;
    public AudioClip success;
    public AudioClip death;
    public AudioClip select;

    public StockItemGroup stockItemGroup;

    public Transform harvesterSpawn;
    public GameObject harvesterObject;

    [SerializeField] private float normSecPerDay = 5f;
    private float realSecPerDay;
    [SerializeField] private float fastSecPerDay = 1f;
    [SerializeField] private float chancesToBuyPerDay = 8f;
    [SerializeField] private float randomEventChancePerDay = 2f;

    bool fastForward = false;


    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(this.gameObject);
        }
        //Want this to persist throughout the game
        DontDestroyOnLoad(gameObject);
    }

    public void AddHarvester(string airSource, float reduction){
        Harvester newHarvester = Instantiate(harvesterObject, harvesterSpawn).GetComponent<Harvester>();
        GameState.Harvesters.Add(newHarvester);
        newHarvester.setReduction(reduction);
        newHarvester.setairSource(airSource);
    }

    // Start is called before the first frame update
    void Start() {
        realSecPerDay = normSecPerDay;

        audioSource = GetComponent<AudioSource>();

        var playMusic = Manager.Instance.PlayMusic || Manager.Instance.ProductionBuild;

        if (!playMusic) {
            audioSource.Stop();
        }

        StartCoroutine("RandomCheck");
        StartCoroutine("BuyChance");
    }

    void FixedUpdate()
    {
        //Update harvesters
        for(int i = 0; i < GameState.Harvesters.Count; i++){
            Harvester harvester = GameState.Harvesters[i];
            harvester.days += Time.fixedDeltaTime * ( ((float) 1)/realSecPerDay);

            if(harvester.days < harvester.tripLength){
                harvester.updatePosition();
            }
            else{
                stockItemGroup.addToStock(harvester.airSource, harvester.harvestQuantity);
                GameState.Harvesters.RemoveAt(i);
                audioSource.PlayOneShot(success);
                Destroy(harvester.gameObject);
                i--;
            }
        }

    }

    public void switchSpeed(){
        if(fastForward){
            NormalSpeed();
        }
        else{
            FastForward();
        }
        fastForward = !fastForward;
    }


    private void FastForward(){
        audioSource.pitch = 2.5f;
        realSecPerDay = fastSecPerDay;
    }

    private void NormalSpeed(){
        audioSource.pitch = 1;
        realSecPerDay = normSecPerDay;
    }

    IEnumerator BuyChance(){
        while(true){
            foreach(KeyValuePair<string, ShopInfo> shop in GameState.PurchasedShops){
                float chance = shop.Value.triggerChance + 
                               (1 - shop.Value.triggerChance) * 
                               ((shop.Value.level - 1) * 
                               GameState.bonusPerShopLevel);
                if(shop.Value.bought && Random.value <= chance){
                    //Take a stock
                    int stockChosen = Random.Range(0, shop.Value.acceptedSources.Length - 1);
                    string airSource = shop.Value.acceptedSources[stockChosen];
                    if(stockItemGroup.hasStock(airSource)){
                        stockItemGroup.addToStock(airSource, -1);
                        GameState.Coins += GameState.PurchasedSources[airSource].value;
                    }
                }
            }
            yield return new WaitForSeconds(realSecPerDay / chancesToBuyPerDay);
        }
    }

    IEnumerator RandomCheck(){
        while(true){
            for(int i = 0; i < GameState.Harvesters.Count; i++){
                Harvester harvester = GameState.Harvesters[i];
                float chance = (1 - harvester.reduction) * GameState.PurchasedSources[harvester.airSource].danger;
                Debug.Log(harvester.reduction);
                Debug.Log(GameState.PurchasedSources[harvester.airSource].danger);
                if(Random.value <= chance){
                    //dead kid
                    GameState.casulties++;
                    audioSource.PlayOneShot(death);
                    GameState.Harvesters.RemoveAt(i);
                    Destroy(harvester.gameObject);
                    i--;
                }
            }
            yield return new WaitForSeconds(realSecPerDay / randomEventChancePerDay);
        }
    }

    public void PlaySelect(){
        audioSource.PlayOneShot(select);
    }


}
