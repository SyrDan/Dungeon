using UnityEngine.UI;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    private Text coinsText, hitpointText;

    public void UpdateMenu()
    {
        hitpointText.text = GameManager.Instance.player.hitPoint.ToString();
        coinsText.text = GameManager.Instance.coins.ToString();
    }
}
