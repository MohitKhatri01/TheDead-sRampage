using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeciaAbilityManageScript : MonoBehaviour
{
    int specialAbilityCount = 3;
    TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
        UpdateCountDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCountDisplay()
    {
        countText.text = "x" + specialAbilityCount.ToString();
    }

    public void SubtractSpecialAbilityCount()
    {
        specialAbilityCount -= 1;
        UpdateCountDisplay();
    }

    public void AddSpecialAbilityCount()
    {
        specialAbilityCount += 1;
        UpdateCountDisplay();
    }

    public bool IsEnoughAbilities()
    {
        if(specialAbilityCount>0)
        {
            return true;
        }
        else { return false; }
    }
}
