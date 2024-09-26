using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//모든 아이템의 기본 인터페이스
//메소드 이벤트 인덱서 프로퍼티
//모든것이 무조건 Public으로 선언 된다.
//구현부가 없다.
public interface IItem
{
    string Name {  get; }
    
    int ID {  get; }

    void Use();
}
//구체적인 아이템 클래스(Weapon)
public class Weapon : IItem
{
    public string Name { get; private set; }

    public int ID { get; private set; }

    public int Damage { get; private set; }

    public Weapon(string name, int id, int damage)          //생성자 => 생성될떄의 형태
    {
        Name = name;
        ID = id;
        Damage = damage;
    }

    public void Use()
    {
        Debug.Log($"Using weapon {Name} with damage {Damage}");     //달러사인은 문자열 내에 변수를 쓸 수 있게 만든다.
    }                                                               //추가로 @표시는 Secape 문자를 무시하고 문자 그대로 인식한다.



}

//구체적인 아이템 클래스(HealthPotion)
public class HealthPotion : IItem
{
    public string Name { get; private set; }

    public int ID { get; private set; }

    public int HealAmount { get; private set; }

    public HealthPotion(string name, int id, int healAmount)          
    {
        Name = name;
        ID = id;
        HealAmount = healAmount;
    }

    public void Use()
    {
        Debug.Log($"Using weapon {Name} with damage {HealAmount}");
    }



}

//제네릭 인벤토리 클래스
public class Inventory<T> where T : IItem
{
    private List<T> items = new List<T>();              //리스트에서 타입으로 받기

    public void AddItem(T item)
    {
        items.Add(item);
        Debug.Log($"Add {item.Name} to inventory");
    }

    public void UseItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items[index].Use();
        }
        else
        {
            Debug.Log("Invalid item index");
        }
    }

    public void ListItems()
    {
        foreach(var item in items)
        {
            Debug.Log($"Item: {item.Name}, Id : {item.ID}");        //리스트 내의 아이템 목록을 콘솔에 출력
        }
    }
}

//인벤토리 Manager
public class InventoryManager : MonoBehaviour
{
    private Inventory<IItem> playerInventory;
    public int UseBagIndex;

    void Start()
    {
        playerInventory = new Inventory<IItem>();

        //아이템 추가
        playerInventory.AddItem(new Weapon("Sword", 1, 10));
        playerInventory.AddItem(new HealthPotion("Small Potion", 2, 10));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {           
            playerInventory.ListItems();                //인벤토리 내용 출력
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerInventory.UseItem(0);                 //첫번째 아이템 사용
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerInventory.AddItem(new Weapon("Sword", 1 , 10));                 //아이템 생성
        }
    }
}

