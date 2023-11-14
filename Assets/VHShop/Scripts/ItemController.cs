using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Shop
{
    public class ItemController : MonoBehaviour
    {
        [Header("COIN")] 
        [SerializeField] private int coin;
        [Header("ITEM PARAMETERS")]
        [SerializeField] private ItemDescription itemDescription;
        [SerializeField] private ItemIndex itemIndex;
        [SerializeField] private ItemType itemType;
        [SerializeField] private int itemPrice;
        [Header("OTHER")]
        [SerializeField] private Image imageButton;
        [SerializeField] private Color itemActive;
        [SerializeField] private Color itemNActive;
        [SerializeField] private TextMeshProUGUI buyButtonText;
        
        private void Start()
        {
            
            itemActive = new Color(200f / 255f,200f / 255f,200 / 255f,255f / 255f);
            itemNActive = new Color(0f / 255f,175f / 255f,255f / 255f,255f/ 255f);
            
            imageButton = GetComponent<Image>();
            
            if (itemType == ItemType.Buy)
            {
                buyButtonText.text = itemPrice.ToString();
            }

            if (!PlayerPrefs.HasKey("coin"))
            {
                PlayerPrefs.SetInt("coin", 1500);
            }
        }

        private void Update()
        {
            coin = PlayerPrefs.GetInt("coin");
            
            switch (itemType)
            {
                case ItemType.Buy:
                    CheckOfBuy(itemDescription, itemIndex, itemType);
                    break;
                case ItemType.Set:
                    var activeItem = PlayerPrefs.GetString("Active" + itemDescription.ToString());
                    imageButton.color = itemIndex.ToString() == activeItem ? itemActive : itemNActive;
                    break;
            }
        }

        private enum ItemDescription
        {
            Skin,Anim,Money,
        }

        private enum ItemIndex
        {
            Index0,Index1,Index2,Index3,Index4,Index5,Index6,Index7,Index8,Index9,Index10,Index11
        }
    
        private enum ItemType
        {
            Buy,Set
        }
    
        private void CheckOfBuy(ItemDescription description, ItemIndex index, ItemType type)
        {
            var item = PlayerPrefs.GetInt(description.ToString() + index.ToString() + type.ToString());
            if (item == 1)
            {
                Destroy(this.gameObject);
            }
        }
        public void Buy()
        {
            if (coin >= itemPrice)
            {
                PlayerPrefs.SetInt("coin", coin -= itemPrice);
                PlayerPrefs.SetInt(itemDescription.ToString() + itemIndex.ToString() + itemType.ToString(), 1);
            }
        }
    
        public void Set()
        {
            PlayerPrefs.SetString("Active" + itemDescription, itemIndex.ToString());
        }
    }
}
