using TMPro;
using UnityEngine;

namespace Game
{
    public class Checker : MonoBehaviour
    {
        // 벽 물체에 설정할 태그 값.
        [SerializeField] private string wallTag = "Wall";

        // 게임에 배치된 벽의 개수.
        [SerializeField] private int targetCount = 0;

        // 플레이어가 밀어낸 벽의 개수.
        [SerializeField] private int pushCount = 0;
        
        // 게임 오버 시간(단위: 초)
        [SerializeField] private float gameOverTime = 10f;

        [SerializeField] private float remainTime = 0f;

        [SerializeField] private bool isGameClear = false;

        [SerializeField] private TextMeshProUGUI timeText;

        private void Awake()
        {
            // 벽의 개수 세기
            targetCount = GameObject.FindGameObjectsWithTag(wallTag).Length;

            // 게임 시작되면 시간 채우기.
            remainTime = gameOverTime;
        }

        private void Update()
        {
            if (isGameClear)
                return;

            // 시간 카운트 다운.
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
