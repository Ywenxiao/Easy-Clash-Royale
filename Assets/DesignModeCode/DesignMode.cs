using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignMode : MonoBehaviour
{
  
    void Start()
    {
        OpenGL openGL = new OpenGL("OpenGl");
        OpenGLPlus openPlus = new OpenGLPlus("OpenPlus");

        Circle circle = new Circle("Circle", openPlus);

        circle.Draw();
    }

  
 
}
