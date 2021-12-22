using System;

class Sample
{
    public string Name { get; set; } = "star";
    public string[] Names { get; set; } = new string[] { "A", "B", "C" };
}

class MistakeSample
{
    public void call()
    {
        var smp = new Sample();
        Console.WriteLine($"呼出前　{smp.Name} {smp.Names[1]}"); // 呼出前　star B
        Sample(smp);
        Console.WriteLine($"呼出後　{smp.Name} {smp.Names[1]}"); // 呼出後　moon BBB
    }

    private void Sample(Sample smp)
    {
        smp.Name = "moon";
        smp.Names[1] = "BBB";
    }
}