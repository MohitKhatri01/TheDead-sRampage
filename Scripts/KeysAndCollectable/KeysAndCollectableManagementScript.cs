using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeysAndCollectableManagementScript : MonoBehaviour
{
    int keysCount = 0;
    int pearlsCount = 0;
    [SerializeField]
    TextMeshProUGUI keysCountText;
    [SerializeField]
    TextMeshProUGUI pearlsCountText;
    // Start is called before the first frame update
    void Start()
    {
        

        UpdateCountDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCountDisplay()
    {
        keysCountText.text = keysCount.ToString() + "/4";
        pearlsCountText.text = "x" + pearlsCount.ToString();
    }

    public void AddToKeysCount(int count)
    {
        keysCount+= count;
        UpdateCountDisplay();
    }

    public void AddToPearlsCount()
    {
        pearlsCount +=1;
        UpdateCountDisplay();
    }
    public void SubtractToPearlsCount(int count)
    {
        pearlsCount -= count; 
        UpdateCountDisplay();
    }

    public int GetTotalKeysCount
    {
        get { return keysCount; }
    }
    public int GetTotalPearlsCount
    {
        get { return pearlsCount; }
    }
}
