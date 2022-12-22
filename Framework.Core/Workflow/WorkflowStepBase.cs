namespace Framework.Core.Workflow
{
    public abstract class WorkflowStepBase<TInput, TContext>
    {
        public bool IsAborted { get; private set; }

        public abstract void Handle(TInput input, TContext context);

        public void Abort()
        {
            IsAborted = true;
        }
    }
}
