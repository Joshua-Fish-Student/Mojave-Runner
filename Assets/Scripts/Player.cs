using UnityEngine;

// TODO: Script should require a Rigidbody2D component
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public Rigidbody2D thing;
    // TODO: Reference to Rigidbody2D component should have class scope.

    // TODO: A float variable to control how high to jump / how much upwards
    // force to add.
    public float jumpHeight = 1f;
    public bool isFalling = true;
    // Start is called before the first frame update
    void Start()
    {
        thing = GetComponent<Rigidbody2D>();
        // TODO: Use GetComponent to get a reference to attached Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isFalling){
            thing.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }
        // TODO: On the frame the player presses down the space bar, add an instant upwards
        // force to the rigidbody.
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isFalling = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isFalling = true;
        }
        
    }
}