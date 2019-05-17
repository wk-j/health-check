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

        public bool Ok { set; get; }

        public SqlConnectionHealthCheck(string connectionString, bool ok)
            : this(connectionString, testQuery: DefaultTestQuery) {
            Ok = ok;
        }

        public SqlConnectionHealthCheck(string connectionString, string testQuery) {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            TestQuery = testQuery;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken)) {
            return Ok
                ? HealthCheckResult.Healthy("OK")
                : HealthCheckResult.Unhealthy("Error");
        }
    }
}
