using System;
using System.Linq;
using Raven.Client;

namespace RavenDBDemo
{
    public class SyncDemo
    {
        private readonly IDocumentStore _documentStore;

        public SyncDemo(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Execute()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                CreateCustomer(session);
                ListCustomers(session);
            }
            Console.WriteLine();
        }

        private static void ListCustomers(IDocumentSession session)
        {
            Console.WriteLine("Listing all customers");
            var customers = session.Query<Customer>()
                .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        private static void CreateCustomer(IDocumentSession session)
        {
            var customer = new Customer
            {
                FullName = "Demo " + DateTime.Now.ToLongTimeString()
            };

            session.Store(customer);
            session.SaveChanges();
            Console.WriteLine("Added a new customer: {0}", customer);
        }
    }
}