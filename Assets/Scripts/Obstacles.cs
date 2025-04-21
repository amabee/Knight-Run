using UnityEngine;
using UnityEngine.Rendering;

public class Obstacles : MonoBehaviour
{
    private float leftEndge;
    private void Start()
    {
        leftEndge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        if (transform.position.x < leftEndge)
        {
            Destroy(gameObject);
        }
    }
}
