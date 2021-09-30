using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour
{


    public List<Sprite> clothes;
    List<WardrobeItem> items;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();

        items = new List<WardrobeItem>(FindObjectsOfType<WardrobeItem>());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetClothes()
    {
        
        foreach(WardrobeItem i in items)
        {
            i.Show();
        } 

        foreach (Sprite c in player.allClothes)
        {
            if (clothes.Contains(c))
            {
                //Disable Buy from these clothes 

                GameObject.Find(c.name + "_UI").GetComponent<WardrobeItem>().CancelBuy();
               
            }
        }
    }

    public void SetUiStuffOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void SetUiStuffOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

}
