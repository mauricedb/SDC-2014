using System;
using Raven.Client.Embedded;

namespace RavenDBDemo
{
    internal class Program
    {
        private static void Main()
        {
            var documentStore = new EmbeddableDocumentStore
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();

            var syncDemo = new SyncDemo(documentStore);
            syncDemo.Execute();

            var asyncDemo = new AsyncDemo(documentStore);
            asyncDemo.Execute().Wait();

            Console.WriteLine("All done.");
            Console.ReadLine();
        }
    }
}