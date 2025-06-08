using System;
using Dual;

internal class Run_Dual {
    static void Main(string[] args)
    {
        Monster 고블린 = new Monster("고블린", 50, 100, 30, "fire");
        Monster 오크 = new Monster("오크", 20, 80, 100, "wind");
        Monster 슬라임 = new Monster("슬라임", 80, 20, 40, "water");


        Arena arena = new Arena();

        arena.addMonster(고블린);
        arena.addMonster(오크);
        arena.addMonster(슬라임);

        while (arena.countMonster() > 1)
        {
            Console.WriteLine($"생명력 가장 높은 몬스터 : {arena.maxHP()}");

            arena.nextRound();

            Console.WriteLine($"현재 몬스터 수 : {arena.countMonster()}");

            arena.stateArena();

            Console.WriteLine();
        }
    }
}


