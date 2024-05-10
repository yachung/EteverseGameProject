using UnityEngine;

namespace Demo
{
    public class ScreenRayCaster : MonoBehaviour
    {
        // 메인 카메라 참조 변수
        [SerializeField] private Camera mainCamera;

        // 마우스 클릭을 통해 얻은 이동하려는 위치
        [SerializeField] private Vector3 targetPosition;

        // 이동 속도
        [SerializeField] private float moveSpeed = 3f;
        // 회전 속도
        [SerializeField] private float rotationSpeed = 540f;

        private void Update()
        {
            // 마우스가 클릭되면, 화면을 기준으로 Ray를 방출.
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f))
                {
                    //// 위치 옮기기.
                    //Vector3 position = hit.point;
                    //position.y = transform.position.y;

                    //transform.position = position;

                    // 이동하려는 위치 저장
                    targetPosition = hit.point;
                    targetPosition.y = transform.position.y;
                }
            }

            // 이동.

            // 이동 방향 구하기
            // 벡터 뺄셈
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();

            // 이번에 이동할 위치 구하기.
            Vector3 moveAmount = direction * moveSpeed * Time.deltaTime;

            // 위치 업데이트.
            transform.position += moveAmount;

            // 회전

            // 예외처리
            if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
                return;

            //if (Input.GetKey(KeyCode.Space))
            {
                // 이동하는 방향을 바라보는 회전 값 (단위 : 4원수)
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // 현재 회전할 양 구하기
                Quaternion rotationAmount = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // 회전 값 더해주기
                transform.rotation = rotationAmount;
            }
        }
    }
}
