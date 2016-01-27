using Bridge;
using System.Collections.Generic;

namespace System.Threading.Tasks
{
    [External]
    [Name("Bridge.Task")]
    public class Task : IDisposable, IBridgeClass
    {
        public Task(Action action)
        {
        }

        public Task(Action<object> action, object state)
        {
        }

        [FieldProperty]
        public extern AggregateException Exception { get; }

        public bool IsCanceled
        {
            [Name("isCanceled")]
            get
            {
                return false;
            }
        }

        public bool IsCompleted
        {
            [Name("isCompleted")]
            get
            {
                return false;
            }
        }

        public bool IsFaulted
        {
            [Name("isFaulted")]
            get
            {
                return false;
            }
        }

        [FieldProperty]
        public extern TaskStatus Status
        {
            get;
        }

        public extern Task ContinueWith(Action<Task> continuationAction);

        public extern Task<TResult> ContinueWith<TResult>(Func<Task, TResult> continuationFunction);

        public extern void Start();

        public extern TaskAwaiter GetAwaiter();

        public extern void Dispose();

        public extern void SetCanceled();

        public extern void SetError(IEnumerable<Exception> exceptions);

        public extern void SetError(Exception exception);

        public extern void Complete(object result = null);

        public static extern Task Delay(int millisecondDelay);

        public static extern Task<TResult> FromResult<TResult>(TResult result);

        public static extern Task Run(Action action);

        public static extern Task<TResult> Run<TResult>(Func<TResult> function);

        public static extern Task WhenAll(params Task[] tasks);

        public static extern Task WhenAll(IEnumerable<Task> tasks);

        public static extern Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks);

        public static extern Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks);

        public static extern Task<Task> WhenAny(params Task[] tasks);

        public static extern Task<Task> WhenAny(IEnumerable<Task> tasks);

        public static extern Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks);

        public static extern Task<Task<TResult>> WhenAny<TResult>(IEnumerable<Task<TResult>> tasks);

        public static extern Task FromCallback(object target, string method, params object[] otherArguments);

        public static extern Task FromCallbackResult(object target, string method, Delegate resultHandler, params object[] otherArguments);

        public static extern Task<TResult> FromCallback<TResult>(object target, string method, params object[] otherArguments);

        public static extern Task<TResult> FromCallbackResult<TResult>(object target, string method, Delegate resultHandler, params object[] otherArguments);

        public static extern Task<object[]> FromPromise(IPromise promise);

        public static extern Task<TResult> FromPromise<TResult>(IPromise promise, Delegate resultHandler);

        public static extern Task<TResult> FromPromise<TResult>(IPromise promise, Delegate resultHandler, Delegate errorHandler);
    }

    [External]
    [IgnoreGeneric]
    [Name("Bridge.Task")]
    public class Task<TResult> : Task
    {
        public Task(Func<TResult> function)
            : base(() =>
            {
            })
        {
        }

        public Task(Func<object, TResult> function, object state)
            : base(() =>
            {
            })
        {
        }

        public TResult Result
        {
            [Name("getResult")]
            get
            {
                return default(TResult);
            }
        }

        public extern Task ContinueWith(Action<Task<TResult>> continuationAction);

        public extern Task<TNewResult> ContinueWith<TNewResult>(Func<Task<TResult>, TNewResult> continuationFunction);

        public new extern TaskAwaiter<TResult> GetAwaiter();

        public extern void SetResult(TResult result);
    }
}
