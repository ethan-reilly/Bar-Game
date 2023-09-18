using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    [SerializeField]
    private Color color = Color.white;

    private List<Material> materials;

    // Gets all the materials from each renderer
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            // A single child-object might have multiple materials on it

            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
       if (val)
       { 
            foreach (var material in materials) 
             {
               // We need to enable the Emission
               material.EnableKeyword("_EMISSION");
               // before we can set the color
               material.SetColor("_EmissionColor", color);
             }
       }
          
        else
        {
          foreach (var material in materials)
          {
               // We can just disable the Emission
               // if we don't use emission color anywhere else
               material.DisableKeyword("_EMISSION");
          }
        }
    }

    
    
}


