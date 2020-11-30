using System;
using System.Threading;
using System.Threading.Tasks;

namespace PriceBot
{
    /// <summary>
    ///     Task which runs in a scheduled manner (asynchronous).
    /// </summary>
    public class PeriodicTask
    {
        private bool firstRun = true;

        /// <summary>
        ///     ctor
        /// </summary>
        public PeriodicTask()
        {

        }

        /// <summary>
        ///     Runs the given action in a given time period.
        /// </summary>
        /// <param name="action">Action, which will be executed</param>
        /// <param name="period">Period of the exectution as a timeSpan.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns></returns>
        public async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!firstRun)
                {
                    await Task.Delay(period, cancellationToken);

                }

                if (!cancellationToken.IsCancellationRequested)
                {
                    action();
                    firstRun = false;
                }
            }
        }

        /// <summary>
        ///     Runs the given action in a given time period.
        /// </summary>
        /// <param name="action">Action, which will be executed</param>
        /// <param name="period">Period of the exectution as a timeSpan.</param>
        /// <returns></returns>
        public Task Run(Action action, TimeSpan period)
        {
            return Run(action, period, CancellationToken.None);
        }
    }
}
