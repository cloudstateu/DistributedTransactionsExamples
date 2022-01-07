namespace Saga.BusinessLogic
{
    public class DTO
    {
        public DTO(bool shouldFail = false)
        {
            ShouldFail = shouldFail;
        }

        public bool ShouldFail { get; }
    }
}
