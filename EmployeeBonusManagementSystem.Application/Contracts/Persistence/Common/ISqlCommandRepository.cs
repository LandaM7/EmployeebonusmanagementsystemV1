﻿using System.Data;

namespace EmployeeBonusManagementSystem.Application.Contracts.Persistence.Common;

public interface ISqlCommandRepository
{
    Task<int> SaveData<T>(
      string sql,
      T parameters,
      string connectionId = "Default",
      CommandType commandType = CommandType.StoredProcedure);
}
