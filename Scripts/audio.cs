using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource run;
    public AudioSource jump;
    public AudioSource engel;
    public AudioSource lose;
    public AudioSource Win;
    public AudioSource peynir;
    private bool isGameCont = true;
    private int carpma = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
       
        

       
        if (!isGameCont)
        {
            run.Stop();
           
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.Play();
            
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        if (collision.gameObject.CompareTag("peynir"))
        {
            peynir.Play();
        }
        if (name.Equals("ground"))
        {
            run.Play();
        } 
        if (collision.gameObject.CompareTag("Engel"))
        {
            engel.Play();
            carpma--;
            if(carpma == 0)
            {
                isGameCont=false;
                lose.Play();
            }
            
        }
        if (name.Equals("finish"))
        {
            Win.Play();
            run.Stop();
            

        }
       
        
    }
}
