using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    //싱글톤 패턴
    public static BattleSystem Instance { get; private set; }

    //캐릭터 배열
    public Character[] players = new Character[3];
    public Character[] enemyies = new Character[3];

    //UI요소
    public Button attackBtn;
    public TextMeshProUGUI turnText;
    public GameObject damageTextPrefab;
    public Canvas uiCanvas;

    //전투 관리 변수
    Queue<Character> turnQueue = new Queue<Character>();    //턴 순서 큐
    Character currentChar;
    bool selectingTarget;

    void Awake() => Instance = this;

    //현재 턴 캐릭터 반환
    public Character GetCurrentChar() => currentChar;
    //공격 버튼 클릭시 타겟 선택 모드 활성화
    void OnAttackClick() => selectingTarget = true;
   
        
    


    // Start is called before the first frame update
    void Start()
    {
        var orderedChars = players.Concat(enemyies).OrderByDescending(c => c.speed);

        foreach (var c in orderedChars)
        {
            turnQueue.Enqueue(c);
        }
        //공격 버튼에 이벤트 연결
        attackBtn.onClick.AddListener(OnAttackClick);
        //첫 턴 시작
        NextTurn();
    }

    // Update is called once per frame
    void Update()
    {
            //타겟 선택 모드에서 마우스 클릭 처리
        if(selectingTarget && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                Character target = hit.collider.GetComponent<Character>();
                if(target != null)
                {
                    currentChar.Attack(target);
                    ShowDamageText(target.transform.position, "20");
                    selectingTarget = false;
                    NextTurn();
                }
            }
        }
    }

    //다음 턴으로 진행
    void NextTurn()
    {
        //현재 턴 캐릭터 설정
        currentChar = turnQueue.Dequeue();
        turnQueue.Enqueue(currentChar);
        turnText.text = turnText.text = $"{currentChar.name} 의 턴 (Speed: {currentChar.speed})";

        //플레이어/적 턴 처리
        if(currentChar.isPlayer)
        {
            attackBtn.gameObject.SetActive(true);               //플레이어턴 : 공겨거튼 활성화
        }
        else
        {
            attackBtn.gameObject.SetActive(false);                  //적턴 공격버튼 비활성화
            Invoke("EnamyAttack", 1f);              //1초 후 적 공격
        }
    }

    //데미지 텍스트 생성 및 표시
    void ShowDamageText(Vector3 position, string damage)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        GameObject damageObj = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, uiCanvas.transform);
        damageObj.GetComponent<TextMeshProUGUI>().text = damage;
        Destroy(damageObj, 1f);
    }

    //AI의 적 공격 처리
    void EnemyAttack()
    {

        //생존한 플레이어 중 랜덤 타겟 설정
        var aliveTargets = players.Where(p => p.gameObject.activeSelf).ToArray();

        if(aliveTargets.Length > 0 ) return;

        var target = aliveTargets[Random.Range(0, aliveTargets.Length)];
        currentChar.Attack(target);
        ShowDamageText(target.transform.position, "20");
        NextTurn();
    }
}
