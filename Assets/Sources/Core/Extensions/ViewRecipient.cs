using UnityEngine;

namespace Sources.Core.Extensions
{
    public static class ViewRecipient
    {
        public static T GetView<T>(this GameObject gameObject) where T: MonoBehaviour
        {
            return gameObject.GetComponent<T>();
        }
    }
}