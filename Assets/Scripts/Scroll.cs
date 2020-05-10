using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //This script scrolls the shader on the line that is drawn
    //for where the enemies walk. The shader just allows a texture to be scrolled infinitely
    //in a direction by increasing or decreasing the _ScrollPosition property there is also a
    //color property that can be changed in the inspector
    Renderer rend;
    float scrollPosition = 0;
    public float speed = 0.001f;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollPosition -= speed * Time.deltaTime;
        rend.material.SetFloat("_ScrollPosition", scrollPosition);
    }
}
