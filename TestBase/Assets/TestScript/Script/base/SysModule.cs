using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class SysModule : MonoBehaviour
{
    public virtual bool Initialize() { return true; }
    public virtual void Dispose() { }
    public virtual void Run(object userData) { }
    public virtual void OnUpdate() { }
    public virtual void OnGUIUpdate() { } // To show engine gui.
}