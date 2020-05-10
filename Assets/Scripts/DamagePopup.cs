using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    //public Camera cameraToLookAt;
    private TextMeshPro textMesh;
    [SerializeField] float speed = 2f;
    private float elapsed = 0.0f;
   
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
    }
    void Update()
    {
        Vector3 v = Camera.main.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(Camera.main.transform.position - v);
        transform.Rotate(0, 180, 0);

        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        elapsed += Time.deltaTime;
        if (elapsed > .2)
        {
            textMesh.alpha -= 1 * Time.deltaTime;
        }
        if(textMesh.alpha < 0)
        {
            Destroy(gameObject);
            
        }
    }
}

