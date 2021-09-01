using DevTest.DAL;
using System;

namespace DevTest.Tests.Utilities
{
    public class DatabaseTestHelper
    {
        public static void RunWithContext(Action<DevTestContext> action)
        {
            var testDataContext = new TestDataContext();

            try
            {
                testDataContext.Database.BeginTransaction();
                action(testDataContext);
                testDataContext.SaveChanges();
            }
            finally
            {
                testDataContext.Database.RollbackTransaction();
            }
        }
    }
}
