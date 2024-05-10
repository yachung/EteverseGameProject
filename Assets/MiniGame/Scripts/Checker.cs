using TMPro;
using UnityEngine;

namespace Game
{
    public class Checker : MonoBehaviour
    {
        // �� ��ü�� ������ �±� ��.
        [SerializeField] private string wallTag = "Wall";

        // ���ӿ� ��ġ�� ���� ����.
        [SerializeField] private int targetCount = 0;

        // �÷��̾ �о ���� ����.
        [SerializeField] private int pushCount = 0;
        
        // ���� ���� �ð�(����: ��)
        [SerializeField] private float gameOverTime = 10f;

        [SerializeField] private float remainTime = 0f;

        [SerializeField] private bool isGameClear = false;

        [SerializeField] private TextMeshProUGUI timeText;

        private void Awake()
        {
            // ���� ���� ����
            targetCount = GameObject.FindGameObjectsWithTag(wallTag).Length;

            // ���� ���۵Ǹ� �ð� ä���.
            remainTime = gameOverTime;
        }

        private void Update()
        {
            if (isGameClear)
                return;

            // �ð� ī��Ʈ �ٿ�.
            if (remainTime <= 0f)
                remainTime = 0f;
            else
                remainTime -= Time.deltaTime;
            
            timeText.text = $"{remainTime}";
        }

        private void OnTriggerEnter(Collider other)
        {
            // tag Check
            if (other.CompareTag(wallTag))
            {
                ++pushCount;

                if (pushCount == targetCount)
                {
                    isGameClear = true;
                    Debug.Log("Game Clear!");
                }
            }
        }
    }
}
