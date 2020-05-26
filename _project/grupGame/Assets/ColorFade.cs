using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFade : MonoBehaviour
{

    Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        // Color treeColor = m_Renderer.material.color;
        // m_Renderer.material.color *= 5f;
        // Debug.Log(treeColor);
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        m_Renderer.material.color = Color.grey;
    }

    //Change the Material's Color back to white when the mouse exits the GameObject
    void OnMouseExit()
    {
        m_Renderer.material.color = Color.white;
    }
}
