using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Core
{
    public class BaseUIObject : MonoBehaviour
    {

        [SerializeField]
        private GameObject context;

        public void Show()
        {
            context.SetActive(true);
        }

        public void Hide()
        {
            context.SetActive(false);
        }

    }
}