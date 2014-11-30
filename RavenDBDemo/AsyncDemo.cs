using System;
using System.Threading.Tasks;
using Raven.Client;

namespace RavenDBDemo
{
    public class AsyncDemo
    {
        private readonly IDocumentStore _documentStore;

        public AsyncDemo(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public async Task Execute()
        {
            using (IAsyncDocumentSession session = _documentStore.OpenAsyncSession())
            {
                await CreateCustomer(session);
                await ListCustomers(session);
            }
            Console.WriteLine();
        }

        private static async Task ListCustomers(IAsyncDocumentSession session)
        {
            Console.WriteLine("Listing all customers without blocking a thread");
            var customers = await session.Query<Customer>()
                .ToListAsync();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        private async Task CreateCustomer(IAsyncDocumentSession session)
        {
            var customer = new Customer
            {
                FullName = "Demo " + DateTime.Now.ToLongTimeString()
            };

            await session.StoreAsync(customer);
            await session.SaveChangesAsync();
            Console.WriteLine("Added a new customer: {0} without blocking a thread", customer);
        }
    }
}