using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class characterControl : MonoBehaviour
{
    private float speed = 5f;
    private Animator animator;
    private bool isJumping = false;
    private bool isRunning = false;
    private Rigidbody rb;
    private bool isGameContinious = true;
    public TextMeshProUGUI health, cheese,finalMessage;
    int can = 3;
    int peynir = 0;
    public GameObject panel;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        


        if(isGameContinious) { 
            
            float ileri = Input.GetAxis("Horizontal");
            //float sagSol = Input.GetAxis("Vertical");
            Vector3 move = new Vector3(ileri,0,1);
            if (Input.GetKey(KeyCode.Escape))
            {
                panel.SetActive(true);
                isGameContinious=false;
            }
            transform.Translate(move*speed*Time.deltaTime);
            if (!isRunning)
            {
                running();
            }
            isRunning = false;
        

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                jump();
            
                //animator.SetTrigger("RunTrigger");
                isJumping = false;
            }

        }
        else
        {
            Vector3 move = Vector3.zero;
            isRunning = true;
            isJumping = true;
        }



        
        
        
        

        
    }
    private void jump()
    {
        animator.SetTrigger("JumpTrigger");
        isJumping = true;

        rb.AddForce(Vector3.up * 4f, ForceMode.Impulse);
        
    }
    private void running()
    {
        animator.SetTrigger("RunTrigger");
        isRunning = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;

        if (name.Equals("finish"))
        {
            print("you won");
            animator.SetTrigger("exit");
            isGameContinious = false;
            panel.SetActive(true);
            finalMessage.text = "YOu win. total cheese: "+peynir;

        }
        else if (collision.gameObject.CompareTag("peynir"))
        {
            Destroy(collision.gameObject);
            peynir++;
            cheese.text = "chesee: "+peynir.ToString();
        }else if (collision.gameObject.CompareTag("Engel"))
        {
            print("GameOver");
            can--;
            health.text = "health: " + can.ToString();
            if (can == 0)
            {
                animator.SetTrigger("exit");
                isGameContinious = false;
                panel.SetActive(true);
                finalMessage.text = "YOu lost! try again.";
                
                
            }
            
        }

    }
    public void resume()
    {
        panel.SetActive(false);

        isGameContinious = true;
    }




}

