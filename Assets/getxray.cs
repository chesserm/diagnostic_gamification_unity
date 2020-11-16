using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using HelperNamespace;

public class getxray : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Sprite targetSprite;
    private string url;

    private void Start()
    {
        
        // Get the x-ray link stored in the PatientData object in the CaseInformation static class
        // Change the url intialization to declaration only
        url = CaseInformation.patient.CXRLink;
         

        StartCoroutine(GetTextureRequest(url, (response) => {
            targetSprite = response;
            spriteRenderer.sprite = targetSprite;
        }));
    }

    IEnumerator GetTextureRequest(string url, System.Action<Sprite> callback)
    {
        using (var www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var texture = DownloadHandlerTexture.GetContent(www);
                    var rect = new Rect(0, 0, 1560f, 1281f);
                    var sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
                    callback(sprite);
                }
            }
        }
    }
}
