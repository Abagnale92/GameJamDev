using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DepthUpdater : MonoBehaviour
{
    public List<Material> mats;
    void Update()
    {
        foreach(Material mat in mats)
        {
            mat.SetVector("_Position", transform.position);
            mat.SetVector("_Scale", transform.localScale / 2f);
        }
    }
}
