namespace NoteClient.Extension
{

    public delegate void SendOrPostCallback<T>(T state);
    public delegate void SendOrPostCallback();

    public static class ContextExtension
    {

        public static void Post<T>(this SynchronizationContext context, SendOrPostCallback<T> callback, T t)
        {
            if (context == null)
                throw new ArgumentNullException("SynchronizationContext cannot be null");

            context.Post((o) =>
            {
                T obj = (T)Convert.ChangeType(o, typeof(T));
                callback(obj);
            }, t);
        }
        public static void Post(this SynchronizationContext context, SendOrPostCallback callback)
        {
            if (context == null)
                throw new ArgumentNullException("SynchronizationContext cannot be null");

            context.Post((o) =>
            {
                callback();
            }, null);
        }


        
    }
}
