﻿namespace UseCases
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productId, double qtyToSell);
    }
}