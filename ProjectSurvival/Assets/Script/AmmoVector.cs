using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoVector : MonoBehaviour
{
    //destination은 최종 위치, duration은 시작위치에서 destination까지 걸리는 시간

    public  IEnumerator FlyAmmo(Vector3 destination, float duration)
    {
        Vector3 startPosition = transform.position;

        float percentComplete = 0.0f;
        while (percentComplete < 1.0f)
        {
            //총알을 매끄럽게 움직이고 싶어서 사용
            //총알은 매 프레임마다 이동할 거리가 달라진다.
            //지난 프레임이후로 흐른시간(Time.deltaTime)과 총알을 움직이려는 시간(duration)으로 나누면
            //현재 프레임에서의 진행율을 구할수 있다고 한다.
            //percentComplete는 이전의 진행률에서 현재프레임의 진행률을 더한 총 진행율이 된다.
            //예를들어 time.deltaTime이 1이고 duration이 10이라면 1/10이된다 프레임이 진행될수록 deltatime은
            //값이 늘어날 것이고 2/10 , 3/10 등등 그러니까 0.1,0.2,0.3 이런값을들 계속 더하는게
            //percentComplete가 된다.
            percentComplete += Time.deltaTime / duration;

            //object가 매끄럽게 움직이는거처럼 보이게 하기위해선
            //Lerp 선형보간 이라는걸 사용한다고 한다.
            //Lerp()를 사용하기위해선 Lerp(시작지점, 종료지점,0~1 사이의 백분율)이렇게 사용해야한다.
            //Lerp()메서드에서 총 진행률을 사용한다는 말은 Object가 화면의 어디로 발사하든지 도달하는 시간이
            //같다고 한다.(공기저항이나 마찰력 등등 영향을 받지 않는다는 말인듯?)
            //Lerp()는 총 진행률을 바탕으로 시작지점과 종료지점사이의 위치를 반환 한다고 한다.
            //그 위치를 Object의 transform.position에 넣어주었다.
            transform.position = Vector3.Lerp(startPosition, destination, percentComplete);
            //다음 프레임까지 코루틴을 멈춤
            yield return null;
        }
        //목적지에 도달했다면 Object를 비활성화 해줌
        gameObject.SetActive(false);
    }
}
