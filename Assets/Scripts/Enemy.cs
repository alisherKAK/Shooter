using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyTypes type;

    private float healthPoint;

    // Start is called before the first frame update
    private void Start()
    {
        healthPoint = (float)type;
    }

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
    }

    public bool IsAlive()
    {
        if(healthPoint > 0)
        {
            return true;
        }

        return false;
    }

    public EnemyTypes GetEnemyType()
    {
        return type;
    }
}
