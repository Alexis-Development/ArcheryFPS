using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // ----- GameObjects -----
    [SerializeField]
    private GameObject bow;
    [SerializeField]
    private GameObject arrowPrefab;
    // Instance of arrowPrefab
    [SerializeField]
    private GameObject arrow;

    private SkinnedMeshRenderer bowMeshRenderer;
    private SkinnedMeshRenderer arrowMeshRenderer;

    private float pullSpeed = 150f;
    private float pullAmount = 0;

    private int numberOfArrows = 3;
    private bool arrowSlotted = false;

    // Start is called before the first frame update
    void Start()
    {
        bowMeshRenderer = bow.GetComponent<SkinnedMeshRenderer>();
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
            arrowMeshRenderer = arrow.GetComponent<SkinnedMeshRenderer>();
        }
    }

    public void AddArrow(int nbArrow)
    {
        numberOfArrows += nbArrow;
        if (!arrowSlotted)
        {
            SpawnArrow();
        }
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
            bowMeshRenderer.SetBlendShapeWeight(0, pullAmount);
            arrowMeshRenderer.SetBlendShapeWeight(0, pullAmount);
        }
        // If player isn't holding left click anymore, shoot the arrow
        if (Input.GetMouseButtonUp(0))
        {
            Rigidbody _arrowRigidB = arrow.transform.GetComponent<Rigidbody>();
            Arrow _arrowProjectile = arrow.transform.GetComponent<Arrow>();

            _arrowRigidB.isKinematic = false;
            arrow.transform.parent = null;
            _arrowProjectile.SetShootForce(pullAmount / 100);

            _arrowProjectile.enabled = true;
            arrow.AddComponent<ArrowEmbed>();

            arrowSlotted = false;
            numberOfArrows -= 1;
            pullAmount = 0;

            bowMeshRenderer.SetBlendShapeWeight(0, pullAmount);

            Invoke("SpawnArrow", 0.5f);

            MainPanel.UpdateNbArrowText(numberOfArrows);
        }
    }
}
