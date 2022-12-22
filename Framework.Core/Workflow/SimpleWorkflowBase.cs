using System.Collections.Generic;

namespace Framework.Core.Workflow
{
    public abstract class SimpleWorkflowBase<TInput, TContext>
    {
        private readonly IEnumerable<WorkflowStepBase<TInput, TContext>> steps;

        protected SimpleWorkflowBase()
        {
            steps = DefineSteps();
        }

        protected abstract IEnumerable<WorkflowStepBase<TInput, TContext>> DefineSteps();

        public TContext Execute(TInput input, TContext context)
        {
            foreach (var step in steps)
            {
                step.Handle(input, context);

                if (step.IsAborted) { return context; }
            }

            return context;
        }
    }
}
