using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [Range(0,1500)]
    public float movementSpeed;

    private void Start()
    {
        
    }
    protected void Move(Vector3 direction)
    {
        rigidbody.velocity = direction * Time.deltaTime * movementSpeed;
    }
    
}
