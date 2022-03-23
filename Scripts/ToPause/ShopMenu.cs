using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    PlayerHealth playerHealth;
    KeysAndCollectableManagementScript keyAndCollectableManage;
    SpeciaAbilityManageScript specialAbilityManageScript;

    public void HandleBackButton()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Destroy(gameObject);
    }

    public void HandleHealthBuyButton()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        if (keyAndCollectableManage.GetTotalPearlsCount >= 10)
        {
            AudioManager.PlayAudio(AudioClipName.ClickSound);
            if (playerHealth.GetPlayerHealth>=100)
            {
                return;
            }
            AudioManager.PlayAudio(AudioClipName.ShopSound);
            playerHealth.IncreaseHealthPlayer(20);
            keyAndCollectableManage.SubtractToPearlsCount(10);
        }

    }
    public void HandleAbilityBuyButton()
    {
        
        if (keyAndCollectableManage.GetTotalPearlsCount >= 5)
        {
            AudioManager.PlayAudio(AudioClipName.ClickSound);
            AudioManager.PlayAudio(AudioClipName.ShopSound);
            specialAbilityManageScript.AddSpecialAbilityCount();
            keyAndCollectableManage.SubtractToPearlsCount(5);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        keyAndCollectableManage = FindObjectOfType<KeysAndCollectableManagementScript>();
        specialAbilityManageScript = FindObjectOfType<SpeciaAbilityManageScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
