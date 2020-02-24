using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private float delayInSecond;

    private bool startDelayDecrease;
    private bool canBlow;

    private void Start() 
    {
        startDelayDecrease = false;
        canBlow = false;    
    }

    private void Update()
    {
        if(startDelayDecrease)
        {
            delayInSecond -= Time.deltaTime;

            if(delayInSecond <= 0)
            {
                canBlow = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            startDelayDecrease = true;
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player")
        {
            if(canBlow)
            {
                other.gameObject.GetComponent<Player>().Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
