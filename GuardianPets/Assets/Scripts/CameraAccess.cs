using UnityEngine;
using System.Collections;

public class CameraAccess : MonoBehaviour 
{
    WebCamTexture cam;

    public Renderer rend;

	void Start ()
    {
        cam = new WebCamTexture();
        rend.material.mainTexture = cam;
        cam.Play();
	}
}