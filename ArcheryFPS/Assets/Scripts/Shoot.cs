using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // ----- GameObjects -----
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
        MainPanel.UpdateNbArrowText(numberOfArrows);
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
            arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
            arrow.transform.parent = transform;
        }
    }

    public void AddArrows(int nbArrow)
    {
        numberOfArrows += nbArrow;
        MainPanel.UpdateNbArrowText(numberOfArrows);
    }

    void ShootArrow()
    {
        // If player is holding left click and the bow isn't fully bended
        if (Input.GetMouseButton(0) && pullAmount < 100)
        {
            pullAmount += Time.deltaTime * pullSpeed;
            Mathf.Clamp(pullAmount, 0, 100);

            // Set BlendShape value of bow and arrow to the new "pullAmount" value
            bow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, pullAmount); ;
            arrow.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, pullAmount);
        }
        // If player isn't holding left click anymore, shoot the arrow
        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            ProjectileAddForce _arrowProjectile = arrow.transform.GetComponent<ProjectileAddForce>();

            _arrowRigidB.isKinematic = false;
            arrow.transform.parent = null;
            _arrowProjectile.shootForce *= ((pullAmount / 100) + 0.05f);

            _arrowProjectile.enabled = true;
            arrow.AddComponent<EmbedBehavior>();

            arrowSlotted = false;
            numberOfArrows -= 1;
            pullAmount = 0;

            Invoke("SpawnArrow", 0.5f);

            MainPanel.UpdateNbArrowText(numberOfArrows);
        }
    }
}
