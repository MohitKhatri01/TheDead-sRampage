using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFollowPlayer : MonoBehaviour
{
    MainHero mainHero;
    // Start is called before the first frame update
    void Start()
    {
        mainHero = FindObjectOfType<MainHero>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(mainHero.transform.position.x,
           transform.position.y);
        transform.position = new Vector2(newPos.x, newPos.y); 
    }
}
