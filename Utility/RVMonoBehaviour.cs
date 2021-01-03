using UnityEngine;

namespace RV
{
    /// <summary>
    /// 拡張版MonoBehaviour
    /// </summary>
    public class RVMonoBehaviour : MonoBehaviour
    {
        public static T InstantiateNonClone<T>(T original, Vector3 position, Quaternion rotation) where T : Object
        {
            T obj = Instantiate(original, position, rotation);
            obj.name = RemoveAtLast(obj.name, "(Clone)");
            return obj;
        }

        private static string RemoveAtLast(string self, string value)
        {
            return self.Remove(self.LastIndexOf(value), value.Length);
        }
    }
}