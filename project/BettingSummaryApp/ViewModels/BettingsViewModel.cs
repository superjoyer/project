using BettingSummaryApp.Classes;
using BettingSummaryApp.Models;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BettingSummaryApp.ViewModels
{
    class BettingsViewModel : ViewModelBase
    {
        #region fields 
 
        private IDataContract contract;

        private int bettingNumber = 0;

        private TextBox textBox1;

        private TextBox textBoxDate;


        #endregion

        #region Properties

      

        public RelayCommand OpenSheduleCommand { get; set; } //Свойство открытия окна расписания

        public RelayCommand OpenReportCommand { get; set; } //Свойство открытия окна отчета

        public ICommand InsertParametersToTableBetting { get; set; }

        public int BettingNumber {

            get { return bettingNumber; }
            set
            {
                bettingNumber = value;

                RaisePropertyChanged("BettingNumber");
            }
        }
        #endregion

        #region Constructors
        public BettingsViewModel()
        {
            CurrentNavigation = TypeForm.BettingForm;

            textBox1 = new TextBox();

            textBoxDate = new TextBox();

            contract = new DataContract();

            InsertParametersToTableBetting = new RelayCommand(AddValueToBettingTable);

            OpenSheduleCommand = new RelayCommand(OpenShedule);

            OpenReportCommand = new RelayCommand(OpenReport);

        }

       
        #endregion

        #region Methods

        //Открыть форму с отчетом
        private void OpenReport(object parameter)
        {
            var win = new ReportWindow();
            win.Show();
           // CloseWindow();
        }

        //Открыть форму с расписанием
        private void OpenShedule(object parameter)
        {
            var win = new SheduleWindow();
            win.Show();
            //CloseWindow();
        }

        //Сформировать объект с полей для ввода и отправить его в БД



        private void AddValueToBettingTable(object parameter)
        {
            //Проверяем поле ввода даты

            if (Validation.GetHasError(textBoxDate) || 
                ActionStartDate <= DateTime.Parse("01.01.0001") || 
                ActionStartDate == null)
            {
                MessageBox.Show("Неверный формат даты", "Предупреждение",
                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //Проверяем поле ввода ставки

            if (Validation.GetHasError(textBox1) || BettingNumber == 0) {
                MessageBox.Show("Поле не может быть пустым или равно нулю", "Предупреждение",
                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (!Validation.GetHasError(textBox1) && !Validation.GetHasError(textBoxDate))
            {
                //Вытаскиваем самую последнюю дату по текущей должности

                var selectMinDateBittingTable = BittingSource.Where(sh => sh.BettingId > 0 && sh.position == SelectedPositionItem).
                    Max(lastDate => lastDate.actionStartDate);

                if (ActionStartDate<= selectMinDateBittingTable)
                {
                    MessageBox.Show("Введенная дата не может быть раньше установленной даты!", "Предупреждение", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var newValueBetting = new Bettings()
                    {
                        BettingId = 0,
                        position = SelectedPositionItem.ToString(),
                        actionStartDate = ActionStartDate,
                        Salary = BettingNumber
                    };

                //Вносим объект в базу данных и одновременно обновляем запись со стороны  View

                BittingSource.Add(newValueBetting);
                contract.SetInsertValue(newValueBetting);

                // contract.ChangeEventList += Contract_ChangeEventList;

                    ActionStartDate = DateTime.Parse("01/01/0001");
                    BettingNumber = 0;
                    SelectedPositionItem  = PositionSource[0];

                    MessageBox.Show("Данные успешно внесены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);  
            }
        }
        

        #endregion


    }
}
