namespace UseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productId, double qty);
        void OnMinusButton(string cashierName, int productId);
        void OnPlusButton(string cashierName, int productId);
    }
}