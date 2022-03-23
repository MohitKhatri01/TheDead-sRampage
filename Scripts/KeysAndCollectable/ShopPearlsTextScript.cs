using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPearlsTextScript : MonoBehaviour
{
    TextMeshProUGUI pearlsText;
    KeysAndCollectableManagementScript keysAndCollectables;
    // Start is called before the first frame update
    void Start()
    {
       keysAndCollectables = FindObjectOfType
            <KeysAndCollectableManagementScript>();
        pearlsText = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePearlsText();
    }
    void UpdatePearlsText()
    {
        pearlsText.text = "x" + keysAndCollectables.GetTotalPearlsCount.ToString(); ;
    }
}
