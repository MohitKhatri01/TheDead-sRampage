using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    Transform mainCameraTransform;
    Vector3 lastCameraPosition;
    [SerializeField]
    Vector2 scrollingFactor;

    float textureUnitSizeX;
    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaValue = mainCameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaValue.x * scrollingFactor.x,
            deltaValue.y*scrollingFactor.y, deltaValue.z); 
        lastCameraPosition = mainCameraTransform.position;

        if(Mathf.Abs(mainCameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetX = (mainCameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(mainCameraTransform.position.x+offsetX,
                transform.position.y,transform.position.z);
        }
    }
}
