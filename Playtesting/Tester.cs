using System;

namespace Playtesting
{
    public record Tester(string Name, byte Age, string Version, float PlayTime, byte HwTier, byte PerformanceScore,
        byte GameplayScore, byte StoryScore, byte VisualsScore, byte MusicScore);
}