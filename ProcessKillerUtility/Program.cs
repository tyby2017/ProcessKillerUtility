using ProcessKillerUtility;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        ProcessKiller processKiller = new ProcessKiller();
        processKiller.Kill(args);
    }

   

}
