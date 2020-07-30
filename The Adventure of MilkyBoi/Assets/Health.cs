using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float currentHealth;
    public RectTransform healthf;
    public float health;
    private Vector3 scaleChange;
    //partical
    public GameObject destroy;

    void Start()
    {
        currentHealth = 100;
    }

    private void Update()
    {
        healthf.localScale= new Vector3(-currentHealth/100,1,1);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroy, transform.position, Quaternion.identity);
        }
    }

    public void damage(float damageValue)
    {
        currentHealth -= damageValue;
    }
}
