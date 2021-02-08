using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpot : MonoBehaviour
{
    SphereCollider sphereCollider;
    SpriteRenderer spriteRenderer;

    int arrowStock = 10;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 45 * Time.deltaTime);
    }

    public int ArrowPicked()
    {
        HideArrowSpot();
        Invoke("ShowArrowSpot", 5);
        return arrowStock;
    }

    void ShowArrowSpot()
    {
        sphereCollider.enabled = true;
        spriteRenderer.enabled = true;
    }

    void HideArrowSpot()
    {
        sphereCollider.enabled = false;
        spriteRenderer.enabled = false;
    }

}
