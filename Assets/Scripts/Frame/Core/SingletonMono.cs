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
                // ���ʵ��Ϊ null������ҵ�ǰ�����е�ʵ��
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    // ���������û��ʵ��������һ���µ�
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name);
                        _instance = singletonObject.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        // ȷ�������ڳ����л�ʱ��������
        protected virtual void Awake()
        {
            // �������ʵ���������ٵ�ǰʵ��
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this as T;
            DontDestroyOnLoad(gameObject); // ����ʵ���ڳ����л�ʱ��������
        }
    }
}
