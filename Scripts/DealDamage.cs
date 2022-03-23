using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]
    int arrowHitPoints = 5;

    public void KillArrow()
    {
        Destroy(gameObject);
    }

    public int GetArrowHitPoints
    {
        get { return arrowHitPoints; }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
