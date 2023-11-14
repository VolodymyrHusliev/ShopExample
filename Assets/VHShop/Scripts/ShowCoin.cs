using TMPro;
using UnityEngine;

public class ShowCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private void Update()
    {
        coinText.text = PlayerPrefs.GetInt("coin").ToString();
    }
}
