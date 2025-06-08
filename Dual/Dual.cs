using System;

namespace Dual
{
    
    public class Monster
    {
        public string name = "";
        public long hp = 0;
        private long atk = 0;
        private long def = 0;
        private string property = "";

        public Monster(string name, long hp, long atk, long def, string property)
        {
            /*
            - 생성자에서 받는 정보
                - 이름 (name)
                - 생명력 (hp)
                - 공격력 (atk)
                - 방어력 (def)
                - 속성 (property) 
                    - 불 : 불은 바람에게 강하나 물과 땅에는 약함
                    - 물 : 물은 불에게 강하나 바람에게는 약함
                    - 땅 : 땅은 불에 강하나 바람에게는 약함
                    - 바람 : 바람은 땅과 물에 강하나 불에게는 약함
                    
                    * 물, 땅 > 불 > 바람
                    * 바람 > 물 > 불
                    * 바람 > 땅 > 불
                    * 불 > 바람 > 물, 땅
                    => 바람 > 물, 땅 > 불 > 바람
            */
            this.name = name;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.property = property;
        }

        public void damage(long d)
        {
            hp -= d;
        }


        // 다른 몬스터를 공격하는 함수
        // - 인자로는 공격할 몬스터를 받습니다.
        public void attack(Monster monster)
        {
            // 데미지의 최소 값은 1입니다.
            long damage = 1;

            if ((atk - monster.def) > 0)
            {
                // 데미지 연산은 다음과 같습니다.
                // = 때리는애 공격력 - 쳐맞는애 방어력
                damage = atk - monster.def;


                string p1 = property;
                string p2 = monster.property;

                // 속성이 상성이라면 데미지를 1.5배, 역상성이면 0.5배, 무상성이라면 1배
                // 소수점은 무시합니다.
                if ((p1 == "fire" && p2 == "wind") || ((p1 == "water" || p1 == "land") && p2 == "fire") || (p1 == "wind" && (p2 == "land" || p2 == "water")))
                {
                    damage = (long)(damage * 1.5f);
                }
                else if ((p1 == "fire" && (p2 == "land" || p2 == "water")) || ((p1 == "water" || p1 == "land") && p2 == "wind") || (p1 == "wind" && p2 == "fire"))
                {
                    damage = (long)(damage * 0.5f);
                }
            }

            monster.damage(damage);

            Console.WriteLine($"{name}.atk = {atk}, {name}.property = {property} / {monster.name}.def = {monster.def}, {monster.name}.property = {monster.property}");
            Console.WriteLine($"데미지 : {damage} / {monster.name}.hp = {monster.hp}");
        }
    }

    public class Arena
    {
        List<Monster> monsterList = new List<Monster>();


        // 몬스터를 추가하는 함수가 있습니다.
        public void addMonster(Monster monster)
        {
            monsterList.Add(monster);
        }


        // 현재 몬스터들중 생명력이 가장 높은 몬스터를 출력하는 함수
        public string maxHP()
        {
            long max = 0;
            int idx = -1;

            if (monsterList.Count == 0)
            {
                return "아레나가 비어있습니다.";
            }
            for (int i = 0; i < monsterList.Count; i++)
            {
                // 생명력이 동률이면 맨 뒤에 추가된 몬스터를 출력합니다.
                if (monsterList[i].hp >= max)
                {
                    max = monsterList[i].hp;
                    idx = i;
                }
            }
            return monsterList[idx].name;
        }


        // 다음라운드진행 함수
        public void nextRound()
        {
            /*
            - 해당 함수를 호출하면 몬스터가 순서대로 한대씩 때립니다.
            - 순서는 아레나에 추가된 몬스터의 순서입니다.
                - Ex) 고블린 추가, 오크 추가, 슬라임 추가
                    - 고블린 -> 오크 -> 슬라임 -> 고블린
            */
            for (int i = 0; i < monsterList.Count - 1; i++)
            {
                monsterList[i].attack(monsterList[i + 1]);
            }

            monsterList[monsterList.Count - 1].attack(monsterList[0]);

            // 생명력이 0된 몬스터는 아레나에서 없어집니다.
            for (int i = monsterList.Count - 1; i >= 0; i--)
            {
                if (monsterList[i].hp <= 0)
                {
                    monsterList.RemoveAt(i);
                }
            }
        }


        // 현재 들어있는 몬스터 수를 가져오는 함수
        public int countMonster()
        {
            return monsterList.Count;
        }


        // 현재 아레나 상태를 가져오는 함수
        public void stateArena()
        {
            // 아직 몬스터가 여러마리라면 아레나가 진행중이라고 출력
            if (monsterList.Count > 1)
            {
                Console.WriteLine("아레나 진행 중..");
            }

            // 몬스터가 한마리 남아있다면 xxx몬스터 승리 라고 출력 
            else if (monsterList.Count == 1)
            {
                Console.WriteLine($"{monsterList[0].name} 몬스터 승리");
            }

            else
            {
                Console.WriteLine("아레나가 비어있습니다.");
            }
        }
    }
}