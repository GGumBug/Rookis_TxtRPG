using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rooki_Charp
{

    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        struct Player
        {
            public int hp;
            public int atk;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Monster
        {
            public int hp;
            public int atk;
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기 사");
            Console.WriteLine("[2] 궁 수");
            Console.WriteLine("[3] 법 사");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return ClassType.Knight;
                case "2":
                    return ClassType.Archer;
                case "3":
                    return ClassType.Mage;
            }

            return ClassType.None;
        }

        static void CreatePlayer(ClassType classType, out Player player)
        {
            switch (classType)
            {
                case ClassType.Knight:
                    player.hp   = 100;
                    player.atk  = 10;
                    break;
                case ClassType.Archer:
                    player.hp   = 75;
                    player.atk  = 12;
                    break;
                case ClassType.Mage:
                    player.hp   = 50;
                    player.atk  = 15;
                    break;
                default:
                    player.hp = 0;
                    player.atk = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random ran = new Random();
            int choiseMonster = ran.Next(1, 4);

            switch (choiseMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("앗! 야생의 슬라임(이)다!");
                    monster.hp = 20;
                    monster.atk = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("앗! 야생의 오 꾸(이)다!");
                    monster.hp = 40;
                    monster.atk = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("앗! 야생의 주우재(이)다! (스켈레톤임)");
                    monster.hp = 30;
                    monster.atk = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.atk = 0;
                    break;
            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                monster.hp -= player.atk;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다!");
                    Console.WriteLine($"남은 체력 : {player.hp}");
                    break;
                }


                player.hp -= monster.hp;
                if (player.hp <= 0)
                {
                    Console.WriteLine("패배했습니다.");
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("필드에 접속했습니다!");

                Monster monster;
                CreateRandomMonster(out monster);

                Console.WriteLine("[1] 전투한다!");
                Console.WriteLine("[2] 일정확률로 마을로 도망..");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if (input == "2")
                {
                    Random random = new Random();
                    int percent = random.Next(0, 101);
                    if (percent <= 33)
                    {
                        Console.WriteLine("성공적으로 도망쳤습니다.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치는데 실패했습니다. 전투를 시작합니다.");
                        Fight(ref player, ref monster);
                    }
                    
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다!");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    break;
                }
            }
            
        }

        static void Main(string[] args)
        {
            ClassType choice = ClassType.None;

            while (true)
            {
                choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;

                    // 캐릭터 생성
                    Player player;
                    CreatePlayer(choice, out player);
                    Console.WriteLine($"HP : {player.hp} ATK : {player.atk}");

                    // 필드로 가서 몬스터와 싸운다.
                    EnterGame(ref player);
            }
        }
    }
}
  