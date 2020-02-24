using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    private Gun gun;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private Image handImage;
    
    // Start is called before the first frame update
    void Start()
    {
        handImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, interactDistance, layerMask))
        {
            if(!handImage.gameObject.activeSelf)
            {
                handImage.gameObject.SetActive(true);
            }

            GameObject gameObject = raycastHit.transform.gameObject;

            if(Input.GetKeyDown(KeyCode.F))
            {
                if(gameObject.tag == "AmmoBag")
                {
                    int ammoCount = gameObject.GetComponent<AmmoBag>().TakeAmmo();
                    gun.LoadAmmo(ammoCount);
                    Destroy(gameObject);

                    handImage.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if(handImage.gameObject.activeSelf)
            {
                handImage.gameObject.SetActive(false);
            }
        }
    }
}
