using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Keys
{
    
    public string keyNames;
    public string keyUIID;
    public bool keyCollected;

    public Keys(string n, string id, bool b)
    {

        this.keyNames = n;
        this.keyUIID = id;
        this.keyCollected = b;

    }

} 



public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed;
    public float jumpForce;
    float jumpMuti = 0;
    public float jumpMutiMax = 2f;
    bool isGrounded;
    
    [Header("Keys")]
    public Keys redKey;
    public Keys blueKey;
    public Keys greenKey;
    public Keys yellowKey;


    [Header("Physics")]
    Rigidbody2D RB;
    Animator anim;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public Vector3 COM2;
    public string sceneName;

    [Header("Dialogue")]
    private DialogueUI DialogueUI;
    public DialogueUI DUI => DialogueUI;
    public IInteractable interact {get; set;}
    [Header("Audio")]
    public AudioSource sfxTrigger;
    public AudioClip[] sound;

    // Start is called before the first frame update
   private void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        DialogueUI =  GameObject.FindGameObjectWithTag("DUI").GetComponent<DialogueUI>();
        RB.centerOfMass = COM2;
    }

    // Update is called once per frame
    private void Update()
    {
        movementCheck();
        interactCheck();
        rotationFix();
        var currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }


    void movementCheck()
    {
        if(DUI.IsOpen) return;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
        if(isGrounded)
            anim.SetBool("IsJumping", false);
        var movement = Input.GetAxisRaw("Horizontal");
        Debug.Log(movement);
        if (movement == 0f)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
            if(movement > 0.5f)
            {
                anim.SetBool("LeftOrRight", true);
            }
            else if(movement < -0.5f)
            {
                anim.SetBool("LeftOrRight", false);
            }
        }
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * movementSpeed;

        
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton1))
        {
            if(jumpMuti < jumpMutiMax)
            {
                jumpMuti += 0.5f * Time.deltaTime;
                sfxTrigger.PlayOneShot(sound[0], 0.5f);
            }
            else
            {
                Debug.Log("Max Charge!");

            }
        }
        else if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            if(isGrounded == true)
            {
            if(jumpMuti < 0.6f)
            {
                jumpMuti = 1f;
            }
            RB.AddForce(new Vector2(0,jumpForce * jumpMuti),ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
            anim.SetTrigger("Jump");
            jumpMuti = 0f;
            isGrounded = false;
            }
        }

    }

    void interactCheck()
    {

        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton0))
        {
                sfxTrigger.PlayOneShot(sound[1], 0.5f);
                interact?.Interact(this);
        }

    }

    void rotationFix()
    {

    if(transform.rotation.z > 50f)
    {

        gameObject.transform.Rotate(new Vector3(0, 0, 50), Space.Self);

    }
    else if(transform.rotation.z < -50f)
    {

        gameObject.transform.Rotate(new Vector3(0, 0, -50), Space.Self);

    }

    }

    public void collectKey(int keyToCollect)
    {
    GameObject keyUI;
    switch(keyToCollect) 
    {
        case 0:
        redKey.keyCollected = true;
        keyUI = GameObject.Find(redKey.keyUIID);
        keyUI.GetComponent<Image>().color = new Color(1, 0, 0, 1);
        keyUI.GetComponent<Tooltip>().isUnlocked = true;
        break;
        case 1:
        blueKey.keyCollected = true;
        keyUI = GameObject.Find(blueKey.keyUIID);
        keyUI.GetComponent<Image>().color = new Color(0, 0, 1, 1);
        keyUI.GetComponent<Tooltip>().isUnlocked = true;
        break;
        case 2:
        greenKey.keyCollected = true;
        keyUI = GameObject.Find(greenKey.keyUIID);
        keyUI.GetComponent<Image>().color = new Color(0, 1, 0, 1);
        keyUI.GetComponent<Tooltip>().isUnlocked = true;
        break;
        case 3:
        yellowKey.keyCollected = true;
        keyUI = GameObject.Find(yellowKey.keyUIID);
        keyUI.GetComponent<Image>().color = new Color(1, 1, 0, 1);
        keyUI.GetComponent<Tooltip>().isUnlocked = true;
        break;
        default:
        Debug.Log("No Key Selected!");
        break;
    }
    }

    public bool checkKey(int keyToCollect)
    {
    
        
    switch(keyToCollect) 
    {
        case 0:
        if(redKey.keyCollected == true)
        {
            return true;
        }
        else
        {
            return false;
        }
        case 1:
        if(blueKey.keyCollected == true)
        {
            return true;
        }
        else
        {
            return false;
        }
        case 2:
        if(yellowKey.keyCollected == true)
        {
            return true;
        }
        else
        {
            return false;
        }
        case 3:
        if(greenKey.keyCollected == true)
        {
            return true;
        }
        else
        {
            return false;
        }
        default:
        Debug.Log("No Key Selected!");
        return false;
    }
    }

}
