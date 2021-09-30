using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour
{


    public List<Sprite> clothes;
    public List<GameObject> clothesObjs;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetClothes()
    {
        Button b;
                
        

        foreach (Sprite c in player.allClothes)
        {
            if (clothes.Contains(c))
            {
                //Disable Buy from these clothes 
                clothesObjs = new List<GameObject>(clothes.Count);
                clothesObjs.Add(GameObject.Find(c.name + "_UI").gameObject);
                foreach(GameObject o in clothesObjs)
                {
                    print(o.name);
                    b = o.GetComponent<Button>();
                    b.interactable = false;
                }
            }
        }
    }


    public void Clear()
    {
        clothesObjs.Clear();
    }

}
