using UnityEngine;

public class AmmoBag : MonoBehaviour
{
    [SerializeField]
    private int ammoCount;

    // Start is called before the first frame update
    private void Start()
    {
        ammoCount = Random.Range(1, 30);
    }

    public int TakeAmmo()
    {
        return ammoCount;
    }
}
