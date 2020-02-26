using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private GameObject smallEnemy, meduimEnemy, largeEnemy, mine;

    [SerializeField]
    private float delayMinTime, delayMaxTime;

    [SerializeField]
    private Transform randomZone;

    private float disposeTime;
    private float delayTime;
    private GameObject instantiatedObject;

    // Start is called before the first frame update
    void Start()
    {
        disposeTime = 0;
        delayTime = Random.Range(delayMinTime, delayMaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(disposeTime <= 0)
        {
            delayTime -= Time.deltaTime;
        }
        else
        {
            disposeTime -= Time.deltaTime;
        }
        
        if(delayTime <= 0)
        {
            Destroy(instantiatedObject);

            int instObject = Random.Range(1, 4);

            Vector3 randomPosition = randomZone.position + Random.insideUnitSphere * radius;

            switch(instObject)
            {
                case 1:
                    instantiatedObject = Instantiate(smallEnemy, randomPosition, randomZone.rotation);
                    break;
                case 2:
                    instantiatedObject = Instantiate(meduimEnemy, randomPosition, randomZone.rotation);
                    break;
                case 3:
                    instantiatedObject = Instantiate(largeEnemy, randomPosition, randomZone.rotation);
                    break;
                case 4:
                    instantiatedObject = Instantiate(mine, randomPosition, randomZone.rotation);
                    break;
            }

            disposeTime = 5;
            delayTime = Random.Range(delayMinTime, delayMaxTime);
        }
    }
}
