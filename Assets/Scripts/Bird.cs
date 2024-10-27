using Game;
using UnityEngine;
using UnityEngine.Events;


public class Bird : MonoBehaviour
{
    [SerializeField] private AZone _triggerZone;
    public float Speed;
    public float RotationSpeed;
    public bool Comebacking = false;
    public int Health;
    private bool _BugInZone = false;
    public UnityEvent GetBug;
    public UnityEvent NeedBug;

    public float HorizontalMove;
    public float VerticalMove;

    private Rigidbody2D rb;
    private Vector2 MoveForvard;
    private Quaternion Rotation;

    private float z = 0;

    public AudioSource bug_sound;
    public AudioSource delivery_sound;

    // wind trail
    public GameObject trail_left;
    public GameObject trail_right;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        _triggerZone.OnEnter.AddListener(BindOnEnter);
        _triggerZone.OnExit.AddListener(BindOnExit);
    }


    private void OnDisable()
    {
        _triggerZone.OnEnter.RemoveListener(BindOnEnter);
        _triggerZone.OnExit.RemoveListener(BindOnExit);
    }

    private void BindOnEnter(Collider2D arg0)
    {
        Bug bug = arg0.gameObject.GetComponent<Bug>();
        Nest nest = arg0.gameObject.GetComponent<Nest>();
        if (bug != null)  _BugInZone = true;
        if (nest != null) 
            if (Comebacking)
            {
                NeedBug.Invoke();
                delivery_sound.Play();
                trail_left.SetActive(true);
                trail_right.SetActive(true);
            }
    }

    private void BindOnExit(Collider2D arg0)
    {
        Bug bug = arg0.gameObject.GetComponent<Bug>();
        if (bug != null)  _BugInZone = false; 
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) VerticalMove += 0.05f;
        if (Input.GetKey(KeyCode.S)) VerticalMove -= 0.05f;
        

        VerticalMove = Mathf.Clamp(VerticalMove, 0, 2);
      
        transform.position += transform.right * VerticalMove * Speed * Time.deltaTime;
        
        HorizontalMove = Input.GetAxis("Horizontal");
        z += -HorizontalMove * RotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, z);

        if (Input.GetButtonDown("e"))
        {
            if (_BugInZone) {
                GetBug.Invoke();
                bug_sound.Play();
                trail_left.SetActive(false);
                trail_right.SetActive(false);
            }
           
        }
    }
}
