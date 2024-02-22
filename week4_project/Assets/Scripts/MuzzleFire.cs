using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFire : MonoBehaviour
{
    public GameObject muzzle;
    public LineRenderer laserLine;
    RaycastHit hit;
    public AudioSource ses;
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled = true;
        laserLine.startWidth = 0.1f; // Çizginin baþlangýç geniþliði
        laserLine.endWidth = 0.1f;   // Çizginin bitiþ geniþliði

        ses = GetComponent<AudioSource>();
        ses.Stop();
    }

    void Update()
    {
        UpdateLaser();
    }

    void UpdateLaser()
    {
        Vector3 startPosition = muzzle.transform.position;
        Vector3 endPosition = startPosition + muzzle.transform.forward * 1000f;

        laserLine.SetPosition(0, startPosition);
        if (Input.GetMouseButtonDown(0))
        {
            ses.Play();
            
        if (Physics.Raycast(startPosition, muzzle.transform.forward, out hit, 1000f))
        {
            endPosition = hit.point;
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        }
            

        laserLine.SetPosition(1, endPosition);
    }
}
