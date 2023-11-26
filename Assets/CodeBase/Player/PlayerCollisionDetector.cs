using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetector : MonoBehaviour
{
    public event UnityAction GroundTouched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 9)                    
            GroundTouched?.Invoke();        

        if(collision.gameObject.layer == 11)
            Destroy(collision.gameObject);
    }
}