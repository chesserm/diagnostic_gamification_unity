using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class getxray : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Sprite targetSprite;
    private string url = "https://homepages.cae.wisc.edu/~ece533/images/cat.png";

    private void Start()
    {
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
                    var rect = new Rect(0, 0, 490f, 733f);
                    var sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
                    callback(sprite);
                }
            }
        }
    }
}
