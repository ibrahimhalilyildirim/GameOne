using UnityEngine;

public class GoldCollectible : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Gold collected!");
            GameManager.Instance.OnGoldCollected();
            Destroy(gameObject);
        }
    }
}
