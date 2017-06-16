using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOAT_CQRS.UI
{
    public abstract class ViewModelBase
    {
        private static Mutex mutex = new Mutex();

        /// <summary>
        /// Créé une nouvelle tache pour éxécuter un traitement
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="processToExecute"></param>
        /// <param name="completedCallback"></param>
        /// <param name="failedCallback"></param>
        public void NewTask<TResult>(Func<TResult> processToExecute, Action<TResult> completedCallback, Action<Exception> failedCallback)           
        {                       
            var task = Task.Factory.StartNew<TResult>(processToExecute).ContinueWith(t =>
            {                
                if (t.IsFaulted)
                {
                    failedCallback(t.Exception.GetBaseException());
                }
                else
                {
                    completedCallback?.Invoke(t.Result);
                }
            },
            TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
