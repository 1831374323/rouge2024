using UnityEngine;

namespace SyTool
{
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                // 如果实例为 null，则查找当前场景中的实例
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    // 如果场景中没有实例，创建一个新的
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name);
                        _instance = singletonObject.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        // 确保单例在场景切换时不被销毁
        protected virtual void Awake()
        {
            // 如果已有实例，则销毁当前实例
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this as T;
            DontDestroyOnLoad(gameObject); // 保持实例在场景切换时不被销毁
        }
    }
}
