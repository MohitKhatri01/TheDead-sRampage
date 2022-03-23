using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
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
        Vector2 newPos = new Vector2(mainHero.transform.position.x, mainHero.transform.position.y);

        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z); 
    }
}
