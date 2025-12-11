using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    [Header("Do przypisania")]
    public Camera photoCamera;
    public Renderer photoFrame;

    public KeyCode captureKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(captureKey))
        {
            photoFrame.enabled = false;
        }

        if (Input.GetKeyUp(captureKey))
        {
            CapturePhoto();

            photoFrame.enabled = true;

        }
    }

    void CapturePhoto()
    {
        RenderTexture newPhotoTexture = new RenderTexture(1024, 1024, 24);
        photoCamera.targetTexture = newPhotoTexture;
        photoCamera.Render();
        photoCamera.targetTexture = null;
        photoFrame.material.mainTexture = newPhotoTexture;

        Debug.Log("Zrobiono zdjêcie!");
    }
}
