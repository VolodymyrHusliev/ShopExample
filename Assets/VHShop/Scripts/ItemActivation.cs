using System;
using UnityEngine;

public class ItemActivation : MonoBehaviour
{
    [SerializeField] private Renderer ballRenderer;
    [SerializeField] private Material[] materials;
    private void Update()
    {
        var activeSkin = PlayerPrefs.GetString("ActiveSkin");
        ballRenderer.material = activeSkin switch
        {
            "Index0" => materials[0],
            "Index1" => materials[1],
            "Index2" => materials[2],
            "Index3" => materials[3],
            "Index4" => materials[4],
            "Index5" => materials[5],
            "Index6" => materials[6],
            "Index7" => materials[7],
            "Index8" => materials[8],
            "Index9" => materials[9],
            "Index10" => materials[10],
            "Index11" => materials[11],
            _ => ballRenderer.material
        };
    }
}
