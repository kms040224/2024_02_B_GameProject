using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    //�̱��� ����
    public static BattleSystem Instance { get; private set; }

    //ĳ���� �迭
    public Character[] players = new Character[3];
    public Character[] enemyies = new Character[3];

    //UI���
    public Button attackBtn;
    public TextMeshProUGUI turnText;
    public GameObject damageTextPrefab;
    public Canvas uiCanvas;

    //���� ���� ����
    Queue<Character> turnQueue = new Queue<Character>();    //�� ���� ť
    Character currentChar;
    bool selectingTarget;

    void Awake() => Instance = this;

    //���� �� ĳ���� ��ȯ
    public Character GetCurrentChar() => currentChar;
    //���� ��ư Ŭ���� Ÿ�� ���� ��� Ȱ��ȭ
    void OnAttackClick() => selectingTarget = true;
   
        
    


    // Start is called before the first frame update
    void Start()
    {
        var orderedChars = players.Concat(enemyies).OrderByDescending(c => c.speed);

        foreach (var c in orderedChars)
        {
            turnQueue.Enqueue(c);
        }
        //���� ��ư�� �̺�Ʈ ����
        attackBtn.onClick.AddListener(OnAttackClick);
        //ù �� ����
        NextTurn();
    }

    // Update is called once per frame
    void Update()
    {
            //Ÿ�� ���� ��忡�� ���콺 Ŭ�� ó��
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

    //���� ������ ����
    void NextTurn()
    {
        //���� �� ĳ���� ����
        currentChar = turnQueue.Dequeue();
        turnQueue.Enqueue(currentChar);
        turnText.text = turnText.text = $"{currentChar.name} �� �� (Speed: {currentChar.speed})";

        //�÷��̾�/�� �� ó��
        if(currentChar.isPlayer)
        {
            attackBtn.gameObject.SetActive(true);               //�÷��̾��� : ���ܰ�ư Ȱ��ȭ
        }
        else
        {
            attackBtn.gameObject.SetActive(false);                  //���� ���ݹ�ư ��Ȱ��ȭ
            Invoke("EnamyAttack", 1f);              //1�� �� �� ����
        }
    }

    //������ �ؽ�Ʈ ���� �� ǥ��
    void ShowDamageText(Vector3 position, string damage)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        GameObject damageObj = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, uiCanvas.transform);
        damageObj.GetComponent<TextMeshProUGUI>().text = damage;
        Destroy(damageObj, 1f);
    }

    //AI�� �� ���� ó��
    void EnemyAttack()
    {

        //������ �÷��̾� �� ���� Ÿ�� ����
        var aliveTargets = players.Where(p => p.gameObject.activeSelf).ToArray();

        if(aliveTargets.Length > 0 ) return;

        var target = aliveTargets[Random.Range(0, aliveTargets.Length)];
        currentChar.Attack(target);
        ShowDamageText(target.transform.position, "20");
        NextTurn();
    }
}
