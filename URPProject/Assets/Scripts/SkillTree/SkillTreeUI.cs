using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillTreeUI : MonoBehaviour
{
    public SkillTree skillTree;
    public GameObject skillNodePrefabs;
    public RectTransform skillTreePanel;
    public float NodeSpacing = 100f;
    public Text SkillPointText;
    public int totalSkillPoint = 10;

    private Dictionary<string, Button> skillButtons = new Dictionary<string, Button>();

    void Start()
    {
        //InitializeSkillTree();
        CreateSkillTreeUI();
        UpdateSkillPointsUI();
    }


    //void InitializeSkillTree()
    //{
    //    skillTree = new SkillTree();

    //    skillTree.AddNode(new SkillNode("fireball1", "Fireball 1",
    //        new Skill<ISKillTarget, DamageEffect>("Fireball1", new DamageEffect(20),
    //        new Vector2(0, 0), "Fireball", 1 , new List<string> { "Fireball1"}));

    //    skillTree.AddNode(new SkillNode("fireball1", "Fireball 1",
    //       new Skill<ISKillTarget, DamageEffect>("Fireball1", new DamageEffect(20),
    //       new Vector2(0, 0), "Fireball", 1, new List<string> { "Fireball1" }));

    //    skillTree.AddNode(new SkillNode("fireball1", "Fireball 1",
    //       new Skill<ISKillTarget, DamageEffect>("Fireball1", new DamageEffect(20),
    //       new Vector2(0, 0), "Fireball", 1, new List<string> { "Fireball1" }));

    //    skillTree.AddNode(new SkillNode("fireball1", "Fireball 1",
    //       new Skill<ISKillTarget, DamageEffect>("Fireball1", new DamageEffect(20),
    //       new Vector2(0, 0), "Fireball", 1, new List<string> { "Fireball1" }));
    //}


    void CreateSkillTreeUI()
    {
        foreach (var node in skillTree.Nodes)
        {
            CreateSKillNodeUI(node);
        }
    }


    void CreateSKillNodeUI(SkillNode node)
    {
        GameObject nodeObj = Instantiate(skillNodePrefabs, skillTreePanel);
        RectTransform rectTransform = nodeObj.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = node.Position * NodeSpacing;

        Button button = nodeObj.GetComponent<Button>();
        Text text = nodeObj.GetComponentInChildren<Text>();
        text.text = node.Name;

        button.onClick.AddListener(() => OnSkillNodeClicked(node.Id));
        skillButtons[node.Id] = button;
        UpdateNodeUI(node);
    }

    private void OnSkillNodeClicked(string skillId)
    {
        SkillNode node = skillTree.GetNode(skillId);

        if(node == null) return;

        if (node.isUnlocked)
        {
            if (skillTree.LockSkill(skillId))
            {
                totalSkillPoint++;
                UpdateSkillPointsUI();
                UpdateNodeUI(node);
                UpdateConnectedSkills(skillId);

            }
            else
            {
                Debug.Log("관련 연계 스킬이 있어서 해제가 안됩니다.");

                
            }
        }
        else if(totalSkillPoint > 0 && CanUnlockSkill(node))
        {
            if(skillTree.UnlockSkill(skillId))
            {
                totalSkillPoint--;
                UpdateSkillPointsUI();
                UpdateNodeUI(node);
                UpdateConnectedSkills(skillId);
            }
        }
    }


    private void UpdateNodeUI(SkillNode node)                   //동ㅈㅏㄱ이 일ㅇㅓㄴㅏㅆ을ㄸㅒ UI 업ㄷㅔㅇㅣㅌㅡ
    {
        if(skillButtons.TryGetValue(node.Id, out Button button))
        {
            bool canUnlock = !node.isUnlocked;
            button.interactable = (canUnlock && totalSkillPoint > 0) || node.isUnlocked;
            button.GetComponent<Image>().color = node.isUnlocked ? Color.green : (canUnlock ? Color.yellow : Color.red);
        }
    }


    private bool CanUnlockSkill(SkillNode node)
    {
        foreach(var requiredSkillId in node.RequiredSkills)
        {
            if(!skillTree.IsSkillUnlock(requiredSkillId))
            {
                return false;
            }
        }

        return true;
    }

    void UpdateSkillPointsUI()
    {
        SkillPointText.text = $"Skill Points: {totalSkillPoint}";
    }

    void UpdateConnectedSkills(string skillId)
    {
        foreach(var node in skillTree.Nodes)
        {
            if(node.RequiredSkills.Contains(skillId))
            {
                UpdateNodeUI(node);
            }
        }
    }    
}
