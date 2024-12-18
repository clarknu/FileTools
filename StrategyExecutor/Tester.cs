using FileStorageClient;

namespace StrategyExecutor;

public class Tester
{
    public static void Test()
    {
        var client = new MinioClient("localhost", 9000, false, "clarknu", "qwer4321!@#$REWQ");
        var roots = client.ListRoots();
        foreach (var root in roots)
        {
            Console.WriteLine(root);
            client.ListFiles(root, "/");
        }
    }
}
