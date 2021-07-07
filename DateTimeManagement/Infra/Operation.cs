using DateTimeManagement.Core;

namespace DateTimeManagement.Infra
{
    public class Operation
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IANADateTime BilingDate { get; set; }

        public IANADateTime DueDate { get; set; }
    }
}
