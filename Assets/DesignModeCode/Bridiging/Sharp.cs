using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sharp
{
    protected string name;

    public DrawEngine drawEngine;

    public virtual void Draw()
    {
        drawEngine.Draw(name);
    }

    protected  Sharp(string name, DrawEngine drawEngine)
    {
        this.name = name;
        this.drawEngine = drawEngine;
    }

}

public abstract class DrawEngine
{
    public string name;

    public virtual void Draw(string draw)
    {
        Debug.Log($"{name}引擎绘制出了{draw}");
    }

    protected DrawEngine(string name)
    {
        this.name = name;
    }
}

public class Circle:Sharp
{
    public Circle(string name, DrawEngine drawEngine) : base(name, drawEngine)
    {
    }
}

public class OpenGL:DrawEngine
{
    public OpenGL(string name) : base(name)
    {
    }
}

public class OpenGLPlus : DrawEngine
{

    public OpenGLPlus(string name) : base(name)
    {
    }
}