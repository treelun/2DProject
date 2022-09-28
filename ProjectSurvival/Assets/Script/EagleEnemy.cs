using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : Enemy
{
    //방향 전환을 위한 벡터값
    public Vector2 direction;
    //독수리가 방향전환 지점을 체크하기위해서 LayerMask를 사용
    public LayerMask layerMask_wall;
    //어떤걸 기준으로 체크할것인가 에디터에서 넣어줌
    public Transform checkWall;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return null;

            //Physics2D.Raycast(checkWall.position은 ray의 기준점이라고 생각해야할듯,
            //방향,ray의 길이, 이 스크립트에서는 layermask를 사용하므로 해당하는 layer입력)
            if (Physics2D.Raycast(checkWall.position, direction, 0.1f, layerMask_wall))
            {
                //위조건에 따르면 checkwall==벽을 인식하기 위한 오브젝트가 direction 의 방향으로 , 0.1f의 길이만큼
                //ray를 발사함 발사한 ray가 leyerMask_wall(에디터에서 오브젝트넣어줌)에 닿으면
                //방향전환 메서드 실행
                EnemyFlip();
                //실행후 direction은 반대값을 가지게함 direction의 방향이 그대로라면
                //방향전환후 wall을 만났을때 인식하지 못할수있음
                direction = new Vector2(-direction.x, direction.y);
            }
            //Enemy클래스를 상속받으므로 Enemy클래스의 값인 movement(EmemyMove가 담겨있음..오타나있네)의 Move를 실행
            movement.Move(direction);


        }
    }

}
