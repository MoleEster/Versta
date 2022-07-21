using Microsoft.Extensions.Options;
using VerstaTest.Options.Extensions;
using VerstaTest.Options.Options;

namespace VerstaTest.Options.Validation
{
    public class PostgresOptionsValidator : IValidateOptions<PostgresOptions>
    {
        public ValidateOptionsResult Validate(string name, PostgresOptions options)
        {

            if (options == null)
            {
                return ValidateOptionsResult.Fail("Postgres options are not set!");
            }
            if (string.IsNullOrEmpty(options.Password))
            {
                return ValidateOptionsResult.Fail("Password is not set!");
            }
            if (string.IsNullOrEmpty(options.Username))
            {
                return ValidateOptionsResult.Fail("Username is not set!");
            }
            if(string.IsNullOrEmpty(options.Database))
            {
                return ValidateOptionsResult.Fail("Database is not set!");
            }
            if (string.IsNullOrEmpty(options.Host) || !options.Host.IsIpAdress())
            {
                return ValidateOptionsResult.Fail("Host ip is incorrect or not set!");
            }
            if (options.Port <= 0)
            {
                return ValidateOptionsResult.Fail("Port cannot be less then 0!");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
