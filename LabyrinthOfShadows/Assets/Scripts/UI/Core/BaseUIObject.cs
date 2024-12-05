using UnityEngine;

namespace UI.Core
{
    public class BaseUIObject: MonoBehaviour
    { 
        public  void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
    }
}