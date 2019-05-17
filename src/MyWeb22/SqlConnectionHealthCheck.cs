using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MyWeb22 {
    // Sample SQL Connection Health Check
    public class SqlConnectionHealthCheck : IHealthCheck {
        private static readonly string DefaultTestQuery = "Select 1";

        public string ConnectionString { get; }

        public string TestQuery { get; }

        public SqlConnectionHealthCheck(string connectionString)
            : this(connectionString, testQuery: DefaultTestQuery) {
        }

        public SqlConnectionHealthCheck(string connectionString, string testQuery) {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            TestQuery = testQuery;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken)) {
            return HealthCheckResult.Unhealthy("Can not connect to DB");
        }
    }
}
