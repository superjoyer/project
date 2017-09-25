using BettingSummaryApp.Classes;
using BettingSummaryApp.Models;
using Microsoft.Practices.Prism;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BettingSummaryApp.ViewModels
{
    class SheduleViewModel : ViewModelBase
    {
        #region private fields 

        private IDataContract contract;

        private int peopleCount = 0;

        private TextBox textBoxCountPerson;

        private TextBox textBoxDate;

        private IDataManager importList;

        #endregion


        #region Properties

        //Свойство для выбранного элемента должности
        public ICommand InsertParametersToTableShedule { get; set; }

        //Свойство для хранения количества людей
        public int PeopleCount
        {
            get { return peopleCount; }
            set
            {
                if(peopleCount != value)
                peopleCount = value;
                RaisePropertyChanged("PeopleCount");
            }
        }

        #endregion



        #region Constructors
        public SheduleViewModel()
        {
            CurrentNavigation = TypeForm.SheduleForm;

            textBoxCountPerson = new TextBox();

            textBoxDate = new TextBox();

            contract = new DataContract();

            InsertParametersToTableShedule = new RelayCommand(AddValueToSheduleTable);
        }

  
        #endregion

        #region Methods

        //Сформировать объект с полей для ввода и отправить его в БД

        private void AddValueToSheduleTable(object parameter)
        {
            if (!Validation.GetHasError(textBoxCountPerson))
            {
                var existItemInTable = SheduleSource.Where(sh => sh.position.PositionName == SelectedPositionItem
                                        && sh.departament.DepartamentName == SelectedDepartItem
                                        && sh.actionStartDate == SelectedDateItem.dateParam).FirstOrDefault();

                if (existItemInTable == null)
                {


                    //Получаем список отделов
                    var getDeparts = contract.GetListDepartments()
                        .Where(n => n.DepartamentName == SelectedDepartItem).FirstOrDefault();

                    //Получаем список должностей
                    var getPositions = contract.GetListPositions()
                        .Where(n => n.PositionName == SelectedPositionItem).FirstOrDefault();

                  
                        var propertiesToInsert = new Shedule
                        {
                            SheduleId = 1,
                            departament = getDeparts,
                            position = getPositions,
                            actionStartDate = SelectedDateItem.dateParam,
                            countPerson = PeopleCount
                        };

                        //Добавляем в коллекцию со стороны viewmodel -> view

                        SheduleSource.Add(propertiesToInsert);

                        //Отправляем данные в БД
                        contract.SetInsertValue(propertiesToInsert);


                        //Сбрасываем настройки по умолчанию

                        SelectedPositionItem = PositionSource[0];
                        SelectedDepartItem = DepartamentSource[0];

                        MessageBox.Show("Данные успешно внесены.",
                            "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    } else {

                        MessageBox.Show("Ошибка! Текуущая запись уже существует.",
                                    "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            
        }


        #endregion
    }
}
