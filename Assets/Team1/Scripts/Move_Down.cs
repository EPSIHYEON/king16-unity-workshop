using UnityEngine;

namespace Team1
{
    public class Move_Down : MonoBehaviour
    {
        public GameObject block;      // 내려갈 블록 (인스펙터에서 할당)
        public float speed;           // 내려가는 속도
        private bool isFalling = false;

        // 2D 환경에서는 OnCollisionEnter2D를 사용합니다.
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // [중요] collision이 아니라 collision.gameObject의 태그를 확인해야 합니다.
            if (collision.gameObject.CompareTag("Player"))
            {
                isFalling = true;
            }
        }

        void Update()
        {
            if (isFalling && block != null)
            {
                // 프레임 속도에 맞춰 아래로 이동
                block.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
}