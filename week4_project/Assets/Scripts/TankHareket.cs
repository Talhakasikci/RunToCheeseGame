using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHareket : MonoBehaviour
{
    public float hiz = 5f;
    public float donmehizi = 1f;
    public Material track1;
    public Material track2;
    public AudioSource EngineAudio;
    public AudioSource NormalEngineAudio;
    private void Start()
    {
        EngineAudio = GetComponent<AudioSource>();
        NormalEngineAudio = GetComponent<AudioSource>();    
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical =   Input.GetAxis("Vertical");

        Vector3 input =  new Vector3(horizontal, 0f, vertical );
        Vector3 move = input*Time.deltaTime*hiz;

        transform.Translate(move);

        float donmeMiktari = donmehizi*horizontal*Time.smoothDeltaTime;
        transform.Rotate(Vector3.up,(donmeMiktari));
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )
        {
            
           // EngineAudio = GetComponent<AudioSource>();
           if(!EngineAudio.isPlaying)
            {NormalEngineAudio.Stop();
                
                EngineAudio.Play();
            }
           
        TrackScrolling(track1, 5f);
        TrackScrolling(track2, 5f);
        }
        else
        {
            if (!NormalEngineAudio.isPlaying)
            {
                NormalEngineAudio.Play();
            }
            EngineAudio.Stop();
        }

        
    }

    float leftTrackYOffsetPos = 0f;
    void TrackScrolling(Material track, float speed)
    {
        leftTrackYOffsetPos = (leftTrackYOffsetPos + (speed * Time.deltaTime)) %0.5f;
        track.mainTextureOffset = new Vector2(0, leftTrackYOffsetPos);
    }

}
