using UnityEngine;

public class BulletMoveAndCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * 10 * Time.deltaTime);
    }
}
