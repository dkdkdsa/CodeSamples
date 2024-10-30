using System.Collections.Generic;
using UnityEngine;

namespace CodeSamples.Samples.Support
{
    public static class Support
    {

        /// <summary>
        /// GameObject에 모든 자식을 가져오는 함수
        /// </summary>
        /// <param name="gameObject">타겟 Gameobject</param>
        /// <returns>모든 자식들</returns>
        public static IReadOnlyList<Transform> GetChilds(this GameObject gameObject)
        {
            //Transform으로 찾아오기
            return GetChilds(gameObject.transform);
        }

        /// <summary>
        /// Transfrom에 모든 자식을 가져오는 함수
        /// </summary>
        /// <param name="trm">타겟 Transform</param>
        /// <returns>모든 자식들</returns>
        public static IReadOnlyList<Transform> GetChilds(this Transform trm)
        {

            //새로운 리스트 생성
            List<Transform> children = new();

            //자식 개수 가져오기
            int cnt = trm.childCount;

            for (int i = 0; i < cnt; i++)
            {
                //자식을 찾아서 리스트에 넣어주기
                children.Add(trm.GetChild(i));
            }

            //자식 데이터를 실수로 수정하면 안되기 때문에 IReadOnlyList로 반환
            return children;

        }

    }
}
