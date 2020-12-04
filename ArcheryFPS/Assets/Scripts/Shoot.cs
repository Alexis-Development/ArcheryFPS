using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bow;
    [SerializeField]
    GameObject arrowPrefab;
    // Instance of arrowPrefab
    [SerializeField]
    GameObject arrow;

    [SerializeField]
    float pullSpeed = 150f;
    float pullAmount = 0;

    [SerializeField]
    int numberOfArrows = 50;
    bool arrowSlotted = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnArrow();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowSlotted)
            ShootArrow();
    }

    void SpawnArrow()
    {
        if (numberOfArrows > 0)
        {
            arrowSlotted = true;
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as GameObject;
            arrow.transform.parent = transform;
        }
    }

    void ShootArrow()
    {
        if (numberOfArrows > 0)
        {
            SkinnedMeshRenderer _bowSkin = bow.GetComponent<SkinnedMeshRenderer>();
            SkinnedMeshRenderer _arrowSkin = arrow.GetComponent<SkinnedMeshRenderer>();
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            ProjectileAddForce _arrowProjectile = arrow.transform.GetComponent<ProjectileAddForce>();

            if (Input.GetMouseButton(0) && pullAmount < 100)
            {
                pullAmount += Time.deltaTime * pullSpeed;
                Mathf.Clamp(pullAmount, 0, 100);
            }
            if (Input.GetMouseButtonUp(0))
            {
                arrowSlotted = false;
                _arrowRigidB.isKinematic = false;
                arrow.transform.parent = null;
                _arrowProjectile.shootForce *= ((pullAmount / 100) + 0.05f);
                
                numberOfArrows -= 1;
                pullAmount = 0;

                _arrowProjectile.enabled = true;
                arrow.AddComponent<EmbedBehavior>();

                Invoke("SpawnArrow", 0.5f);
            }
            _bowSkin.SetBlendShapeWeight(0, pullAmount);
            _arrowSkin.SetBlendShapeWeight(0, pullAmount);
        }
    }
}
