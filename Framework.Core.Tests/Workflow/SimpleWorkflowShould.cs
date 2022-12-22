using Framework.Core.Workflow;
using NUnit.Framework;
using System.Collections.Generic;

namespace Framework.Core.Tests.Workflow
{
    public class SimpleWorkflowShould
    {
        [Test]
        public void PopulateFirstTwoCharsAndAbort()
        {
            var workflow = new SimpleWorkflow();

            var input = new SampleInput();

            var context = new SampleContext();

            var finalContext = workflow.Execute(input, context);

            Assert.IsTrue(finalContext.Chars.Count == 2);
            Assert.IsTrue(finalContext.Chars[0] == '1');
            Assert.IsTrue(finalContext.Chars[1] == '2');
        }

        public class SampleInput { }

        public class SampleContext { public List<char> Chars = new List<char>(); }

        public class SimpleWorkflow : SimpleWorkflowBase<SampleInput, SampleContext>
        {
            protected override IEnumerable<WorkflowStepBase<SampleInput, SampleContext>> DefineSteps()
            {
                return new WorkflowStepBase<SampleInput, SampleContext>[]
                {
                    new AddOne(),
                    new AddTwo(),
                    new AddThree()
                };
            }
        }

        public class AddOne : WorkflowStepBase<SampleInput, SampleContext>
        {
            public override void Handle(SampleInput input, SampleContext context)
            {
                context.Chars.Add('1');
            }
        }

        public class AddTwo : WorkflowStepBase<SampleInput, SampleContext>
        {
            public override void Handle(SampleInput input, SampleContext context)
            {
                context.Chars.Add('2');

                Abort();
            }
        }

        public class AddThree : WorkflowStepBase<SampleInput, SampleContext>
        {
            public override void Handle(SampleInput input, SampleContext context)
            {
                context.Chars.Add('3');
            }
        }
    }
}
