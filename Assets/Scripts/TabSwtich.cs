using UnityEngine;

public class TabSwtich : MonoBehaviour
{
    public GameObject activeSpaces;

    public void switchTab(int index){
        // Sets active space active, turns off all others
        // Loop ensures that if for some reason we have extra tabs the we don't access a null active space

        for(int i = 0; i < activeSpaces.transform.childCount; i++){
            if(index == i){
                activeSpaces.transform.GetChild(i).gameObject.SetActive(true);
            }
            else{
                activeSpaces.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void updateBackground(RectTransform background){
        background.SetAsLastSibling();
    }
}
