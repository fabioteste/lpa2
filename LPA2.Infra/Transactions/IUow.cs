﻿namespace LPA2.Infra.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
