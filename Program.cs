using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ConsoleApp4
{
    internal class Item
    {
        public string Name;
        public int Price;
        public int AttackPlus;
        public int DependPlus;
        public string Information;
        public bool IsEquipped;
    }
internal class Character
    {
        public int level = 1;
        public string name = "";
        public string job = "";
        public int attack = 10;
        public int defense = 5;
        public int Hp = 100;
        public int gold = 1500;
        public List<Item> itemList = new List<Item>();
    }
    internal class Program
    {



        static void Main(string[] args)
        {
            Character Player = new Character();

            bool isCharacterCreated = false;
            while (!isCharacterCreated)

            {
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");

                Console.WriteLine("원하시는 이름을 입력해주세요.\n");
                Player.name = Console.ReadLine();

                if (!string.IsNullOrEmpty(Player.name))
                {
                    Console.WriteLine($"\n입력하신 이름은 {Player.name} 입니다.");
                    Console.WriteLine("1.저장\n2.취소");
                    Console.WriteLine("\n원하시는 행동을 입력해주세요.");

                    string inputName = Console.ReadLine();

                    while (true)
                        if (inputName == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                            Console.WriteLine("원하시는 직업을 선택해주세요");
                            Console.WriteLine("1.전사\n2.도적");
                            Console.WriteLine();
                            Console.WriteLine("원하시는 행동을 입력해주세요.");
                            string inputJob = Console.ReadLine();


                            if (inputJob == "1")
                            {
                                Player.job = "전사";
                                isCharacterCreated = true;
                                break;
                            }
                            else if (inputJob == "2")
                            {
                                Player.job = "도적";
                                isCharacterCreated = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("다시 입력해주세요.");
                                Console.ReadKey();
                                continue;
                            }


                        }
                        else if (inputName == "2")
                        {
                            Console.Clear();
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("다시 입력해주세요");
                            Console.Clear();
                            Console.ReadKey();
                            break;
                        }
                }
            }

            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 돌아가기전 활동을 할 수 있습니다.");




            List<Item> shopItems = new List<Item>()
            {
                new Item { Name = "수련자 갑옷", DependPlus = 5, Information = "수련에 도움을 주는 갑옷입니다.", Price = 1000 },
                new Item { Name = "무쇠갑옷", DependPlus = 9, Information = "무쇠로 만들어져 튼튼한 갑옷입니다.", Price = 1200 },
                new Item { Name = "스파르타의 갑옷", DependPlus = 15, Information = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", Price = 3500 },
                new Item { Name = "낡은 검", AttackPlus = 2, Information = "쉽게 볼 수 있는 낡은 검 입니다.", Price = 600 },
                new Item { Name = "청동 도끼", AttackPlus = 5, Information = "어디선가 사용됐던거 같은 도끼입니다.", Price = 1500 },
                new Item { Name = "스파르타의 창", AttackPlus = 7, Information = "스파르타의 전사들이 사용했다는 전설의 창입니다.", Price = 2000 }
            };

            while (true)
            {

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    ShowStatus(Player);
                }
                else if (input == "2")
                {
                    ShowInventory(Player);
                }
                else if (input == "3")
                {
                    ShowShop(Player, shopItems);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
        static void ShowInventory(Character targetPlayer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                Console.WriteLine("[아이템 목록]");
                //아이템이 없다면 아무것도 나오지 않는다
                if (targetPlayer.itemList.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. 장착 관리\n0. 나가기");
                }
                else
                {

                    foreach (var item in targetPlayer.itemList)
                    {
                        string equipped = item.IsEquipped ? "[E]" : "";
                        string stat = "";
                        if (item.AttackPlus>0)
                        {
                            stat = $"공격력 + {item.AttackPlus}";
                        }
                        else if (item.DependPlus > 0)
                        {
                            stat = $"방어력 + {item.DependPlus}";
                        }
                        Console.WriteLine($"-{equipped}{item.Name,-15} | {stat,-10} | {item.Information}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("2. 나가기");
                      
                }
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                string input = Console.ReadLine();

                if (targetPlayer.itemList.Count == 0)
                {
                    if (input == "0")
                    {
                        Console.Clear ();
                        break;
                    }
                    else if (input == "1")
                    {
                        Console.WriteLine("장착관리기능구현");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    if (input == "2")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (input == "1")
                    {
                        Console.WriteLine("장착관리 기능구현");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                    }
                }

                //아이템이 있다면 아이템 목록이 나온다
                Console.WriteLine("1.장착 관리");
                Console.WriteLine("0.나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string input1 = Console.ReadLine();
                

                if (input1 == "0")
                {
                    Console.Clear();
                    break;
                }
                else if (input1 == "1")
                {
                    //장착관리를 누르면 아이템 목록앞에 숫자가 나온다

                    //숫자를 누르면 아이템이 장착이 해제되거나 장착된다
                    //일치하는 숫자가 아니라면 잘못된 입력입니다 출력
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }


            }

        }


        static void ShowStatus(Character targetPlayer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine($"Lv. {targetPlayer.level}");
                Console.WriteLine($"{targetPlayer.name} ({targetPlayer.job})");
                Console.WriteLine($"공격력 : {targetPlayer.attack}");
                Console.WriteLine($"방어력 : {targetPlayer.defense}");
                Console.WriteLine($"체 력 : {targetPlayer.Hp}");
                Console.WriteLine($"Gold : {targetPlayer.gold} G");
                Console.WriteLine("\n0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }


            }
        }
        static void ShowShop(Character targetPlayer, List<Item> shopItems)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine($"[보유골드]\n{targetPlayer.gold} G\n");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.Clear();
                    break;
                }

            }

        }
    }
}


        

       





