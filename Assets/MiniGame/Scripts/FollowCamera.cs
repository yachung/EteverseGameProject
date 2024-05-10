using UnityEngine;

namespace Game
{
    // �÷��̾�(��ǥ)�� ���� �Ÿ��� �ΰ� ����ٴϴ� ī�޶� ��ũ��Ʈ.
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
            // ��ǥ���� �Ÿ� ���� ���.
            distance = transform.position - target.position;
        }

        private void Update()
        {
            // ����ٴ�.
            //transform.position = target.position + distance;
            transform.position = Vector3.Lerp
                (transform.position, target.position + distance, damping * Time.deltaTime) ;
        }
    }
}