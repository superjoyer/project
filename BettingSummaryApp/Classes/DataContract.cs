using BettingSummaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.Classes
{
    class DataContract : IDataContract
    {
        private DataManager manager;

        public DataContract()
        {
            manager = new DataManager();
        }

        //Получаем все записи из таблицы отделы
        IEnumerable<Departament> IDataContract.GetListDepartments()
        {
            manager.Load();
            return manager.DepartamentProperty;
        }

        //Получаем все записи из таблицы должности 
        IEnumerable<Position> IDataContract.GetListPositions()
        {
            manager.Load();
            return manager.PositionProperty;
        }

        // Отправляем данные в БД через контракт
        public void SetInsertValue(object param)
        {
            if (param != null) {
                try
                {
                    Type property = param.GetType();

                    if (property.Name == "Bettings")
                    {
                        manager.InsertToBetting(param);
                    }
                    else
                    {
                        manager.InsertToShedule(param);
                        manager.InsertToReports(param);
                    }

                } catch (InvalidCastException){
                    throw new InvalidCastException("Невозможно выполнить запись в БД!");
                    return;
                }
            }
        }


    }
}
