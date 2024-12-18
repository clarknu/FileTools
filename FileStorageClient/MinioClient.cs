using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minio;
using Minio.ApiEndpoints;
using Minio.DataModel.Args;

namespace FileStorageClient;
public class MinioClient : IFileStorageClient
{
    private Minio.IMinioClient internalClient;

    public MinioClient(string endpoint, int port, bool useSSL, string accessKey, string secretKey)
    {
        this.internalClient = new Minio.MinioClient()
            .WithEndpoint(endpoint, port)
            .WithCredentials(accessKey, secretKey)
            .WithSSL(useSSL)
            .Build();
    }

    public string[] ListRoots()
    {
        return this.internalClient.ListBucketsAsync().Result.Buckets.Select(b => b.Name).ToArray();
    }

    public async void ListFiles(string root, string path)
    {
        var args = new ListObjectsArgs()
            .WithBucket(root)
            .WithPrefix(null)
            .WithRecursive(true);
        var observable = this.internalClient.ListObjectsEnumAsync(args).ConfigureAwait(false);
        await foreach (var item in observable)
        {
            Console.WriteLine(item.Key);
        }
    }
}
