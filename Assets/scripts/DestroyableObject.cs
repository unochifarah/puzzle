using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public string collisionTag = "Beast";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag))
        {
            Destroy(gameObject);
        }
    }
}
