﻿// See https://aka.ms/new-console-template for more information
using Algo4;
using System.Diagnostics;
using static Algo4.Klotski;


State start = new((int[][])[[6,14,15,13],[4,11,1,5],[10,7,2,9],[12,3,8,0]]);

(int x, int y)[] endPos = new (int, int)[start.N * start.N];// 最终状态的位置

Klotski t = new(start, F);
State rightState = t.rightState;
// 生成末状态的位置：
for (int i = 0; i < start.N; i++) {
    for (int j = 0; j < start.N; j++) {
        endPos[rightState[i, j]] = (i, j);
    }
}


Stopwatch sw = Stopwatch.StartNew();
var path = t.Search();
sw.Stop();
Console.WriteLine($"Done! 用时{sw.Elapsed}，以下是还原步骤：");
foreach (var item in path) {
    Console.WriteLine(item);
    Console.WriteLine("---");
}
Console.WriteLine($"步骤数：{path.Count}");

int F(State state) {
    // 0--8
    // 0: 空缺位置

    //h(x):
    int dis = 0;
    for (int i = 0; i < state.N; i++) {
        for (int j = 0; j < state.N; j++) {
            if (state[i, j] == 0) {
                continue;
            }
            // g:
            dis += Math.Abs(i - endPos[state[i, j]].x) + Math.Abs(j - endPos[state[i, j]].y);

        }
    }

    return dis;
}
