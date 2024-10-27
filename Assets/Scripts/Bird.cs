using Game;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Bird : MonoBehaviour
{
    [SerializeField] private AZone _triggerZone;
    [SerializeField] public SpriteRenderer BugSprite;
    public float Speed;
    public float RotationSpeed;
    public float RotationSlow = 0;
    public bool Comebacking = false;
    public int CountOfBugs = 0;

    private bool _BugInZone = false;

    public float HorizontalMove;
    public float VerticalMove;

    private float z = 0;

    public AudioSource bug_sound;
    public AudioSource delivery_sound;

    // wind trail
    public GameObject trail_left;
    public GameObject trail_right;

    public List<Sprite> BugSprites;
    public List<Transform> TeleportPoints;

    public Animator animator;

    public UnityEvent GetBug;
    public UnityEvent NeedBug;
    private void OnEnable()
    {
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
        Cloud cloud = arg0.gameObject.GetComponent<Cloud>();
        Teleport teleport = arg0.gameObject.GetComponent<Teleport>();
        if (bug != null)  _BugInZone = true;
        if (nest != null) 
            if (Comebacking)
            {
                NeedBug.Invoke();
                delivery_sound.Play();
                trail_left.SetActive(true);
                trail_right.SetActive(true);
            }
        if (cloud != null) Speed *= 0.3f;
        if (teleport != null) transform.position = TeleportPoints[Random.Range(0,TeleportPoints.Count)].position;

    }

    private void BindOnExit(Collider2D arg0)
    {
        Bug bug = arg0.gameObject.GetComponent<Bug>();
        if (bug != null)  _BugInZone = false; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) OnWPressed();
        if (Input.GetKey(KeyCode.S)) OnSPressed();
        
      
        transform.position += transform.right * VerticalMove * Speed * Time.deltaTime;
        
        HorizontalMove = Input.GetAxis("Horizontal");
        z += -HorizontalMove * (RotationSpeed - RotationSlow);
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

    private void OnWPressed()
    {
        VerticalMove += 0.2f;
        VerticalMove = Mathf.Clamp(VerticalMove, 0, 2 + 0.1f * CountOfBugs);
        RotationSlow = VerticalMove * 0.1f;
        RotationSlow = Mathf.Clamp(RotationSlow, 0, 0.9f * RotationSpeed);
        animator.SetBool("isFly", true);
    }
    private void OnSPressed()
    {
        VerticalMove -= 0.01f;
        VerticalMove = Mathf.Clamp(VerticalMove, 0, 2 + 0.1f * CountOfBugs);
        RotationSlow = VerticalMove * 0.1f;
        RotationSlow = Mathf.Clamp(RotationSlow, 0, 0.9f * RotationSpeed);
        animator.SetBool("isFly", false);
    }
}
