using RRTest.Controllers.Decks;
using RRTest.Data.Items;
using RRTest.UI.ItemsVisualizators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameStartController : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] GameObject cardPrefab;
    [SerializeField] Transform canvasTransform;

    public string url = "https://picsum.photos/200/200.jpg";

    IEnumerator Start()
    {
        for (var i = 0; i < 6; i++)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(request.error);
                i--;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                var card = Instantiate(cardPrefab, canvasTransform).GetComponent<CardItemVisualizator>();
                card.UpdateItem(new CardItem(
                    i.ToString(), 
                    (6 - i).ToString(), 
                    Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f),
                    Random.Range(5, 9),
                    Random.Range(5, 9),
                    Random.Range(5, 9)));

                playerDeck.InsertCard(card);
                yield return new WaitForSeconds(1.1f);
            }
            
        }
    }
}
