using System;
using System.Threading.Tasks;

namespace Ritter.Infra.Crosscutting.Trying
{
    public static class TaskExtensions
    {
        public static async Task<TResult> Map<TInput, TResult>(this Task<TInput> task, Func<TInput, TResult> func)
        {
            return func(await task);
        }

        public static Task<TResult> Map<TInput, TResult>(this Task<TInput> task, Func<Exception, TResult> failure, Func<TInput, TResult> success)
        {
            return task.ContinueWith((Task<TInput> t) => (t.Status != TaskStatus.Faulted) ? success(t.Result) : failure(t.Exception));
        }

        public static async Task<TResult> Bind<TInput, TResult>(this Task<TInput> task, Func<TInput, Task<TResult>> func)
        {
            return await func(await task);
        }

        public static Task<T> OrElse<T>(this Task<T> task, Func<Task<T>> fallback)
        {
            return task.ContinueWith((Task<T> t) => (t.Status != TaskStatus.Faulted) ? Task.FromResult(t.Result) : fallback()).Unwrap();
        }
    }
}
