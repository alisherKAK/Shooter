using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int healthPoint;

    [SerializeField]
    private Text healthPointText;

    private void Start() 
    {
        ShowHealthPoint();    
    }

    public void Damage(int damage)
    {
        healthPoint -= damage;
        Debug.Log(damage);
        ShowHealthPoint();
    }

    private void ShowHealthPoint()
    {
        healthPointText.text = "HP: " + healthPoint;
    }
}
