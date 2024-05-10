using UnityEngine;

namespace Demo
{
    public class ScreenRayCaster : MonoBehaviour
    {
        // ���� ī�޶� ���� ����
        [SerializeField] private Camera mainCamera;

        // ���콺 Ŭ���� ���� ���� �̵��Ϸ��� ��ġ
        [SerializeField] private Vector3 targetPosition;

        // �̵� �ӵ�
        [SerializeField] private float moveSpeed = 3f;
        // ȸ�� �ӵ�
        [SerializeField] private float rotationSpeed = 540f;

        private void Update()
        {
            // ���콺�� Ŭ���Ǹ�, ȭ���� �������� Ray�� ����.
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                {
                    //// ��ġ �ű��.
                    //Vector3 position = hit.point;
                    //position.y = transform.position.y;

                    //transform.position = position;

                    // �̵��Ϸ��� ��ġ ����
                    targetPosition = hit.point;
                    targetPosition.y = transform.position.y;
                }
            }

            // �̵�.

            // �̵� ���� ���ϱ�
            // ���� ����
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();

            // �̹��� �̵��� ��ġ ���ϱ�.
            Vector3 moveAmount = direction * moveSpeed * Time.deltaTime;

            // ��ġ ������Ʈ.
            transform.position += moveAmount;

            // ȸ��

            // ����ó��
            if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
                return;

            //if (Input.GetKey(KeyCode.Space))
            {
                // �̵��ϴ� ������ �ٶ󺸴� ȸ�� �� (���� : 4����)
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // ���� ȸ���� �� ���ϱ�
                Quaternion rotationAmount = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // ȸ�� �� �����ֱ�
                transform.rotation = rotationAmount;
            }
        }
    }
}
