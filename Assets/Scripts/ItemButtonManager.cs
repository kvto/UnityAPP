using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButtonManager : MonoBehaviour
{
    GameObject textobj, textobj1;
    private TextMeshPro itemName;
    private TextMeshPro itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;
    private ARInteractionManager interactionManager;

    public string ItemName{
        set{
            itemName.text = value;
        }
    }

    public string ItemDescription { 
        set {
        itemDescription.text = value;
    }  }
    public Sprite ItemImage { 
        set{
        itemImage = value;
    }
      }
    public GameObject Item3DModel { 
        set{
        item3DModel = value; 
    } 
    }
    // Start is called before the first frame update
    void Start()
    {

        textobj = this.gameObject.transform.GetChild (0).gameObject;
        itemName = textobj.GetComponent<TextMeshPro>();
        //transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture;
        textobj1 = this.gameObject.transform.GetChild (2).gameObject;
        itemDescription = textobj.GetComponent<TextMeshPro>();
        //transform.GetChild(2).GetComponent<Text>().text = itemDescription;

        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);

        interactionManager = FindObjectOfType<ARInteractionManager>();
    }

    private void Create3DModel(){
        interactionManager.Item3DModel = Instantiate(item3DModel);
    }
    
}
