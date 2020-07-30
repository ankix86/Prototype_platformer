using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public bool playerInRange;

    private void Start()
    {
        playerInRange = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("IN RANGE");
            gameObject.GetComponent<Animator>().SetBool("playerInRange", true);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;

            gameObject.GetComponent<Animator>().SetBool("playerInRange", false);
        }
    }
}
