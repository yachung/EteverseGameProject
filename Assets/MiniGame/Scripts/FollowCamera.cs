using UnityEngine;

namespace Game
{
    // 플레이어(목표)를 일정 거리를 두고 따라다니는 카메라 스크립트.
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private Vector3 distance;

        [SerializeField]
        private float damping = 5f;

        private void Awake()
        {
            // 목표와의 거리 벡터 계산.
            distance = transform.position - target.position;
        }

        private void Update()
        {
            // 따라다님.
            //transform.position = target.position + distance;
            transform.position = Vector3.Lerp
                (transform.position, target.position + distance, damping * Time.deltaTime) ;
        }
    }
}