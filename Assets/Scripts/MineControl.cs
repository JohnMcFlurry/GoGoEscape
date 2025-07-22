using UnityEngine;

public class MineControl : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Mine says: I'm still colliding with the ground" + other.name);
        if (other.CompareTag("Player"))
            {
            Debug.Log("Mine says: YOU'RE DEAD " + other.name);
            Explode();
        }
    }
    private void Explode()
    {
        //Debug.Log("Mine says: I should've been exploded");
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
