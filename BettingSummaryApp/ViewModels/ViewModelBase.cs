using Microsoft.Practices.Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using BettingSummaryApp.Models;
using BettingSummaryApp.Classes;

namespace BettingSummaryApp.ViewModels
{
    class ViewModelBase: NotificationObject
    {
        #region fields

        private IDataManager dataManager;

        private string selectedPositionItem;

        private string selectedDepartItem;

        private DateTime dateStartProperty = DateTime.Parse("01.01.0001");

        private DateDependencyModel dateFromCurentBett;

        private TypeForm currentNavigation = TypeForm.BettingForm;

        #endregion




        #region Properties

        //Свойство для хранения выбранной должности
        public string SelectedPositionItem
        {
            get { return selectedPositionItem; }

            set
            {
                if (selectedPositionItem != value)
                    selectedPositionItem = value;

                if(CurrentNavigation == TypeForm.SheduleForm)
                    ChangeListDatesFromBettingSource();
                
                RaisePropertyChanged("SelectedPositionItem");

            }
        }

        //Свойство отвечающее за навигацию в какой форме происходит 
        // действие пользователя

        public TypeForm CurrentNavigation
        {
            get {
                return currentNavigation;
            }
            set {
                if (currentNavigation != value)
                    currentNavigation = value;
            }
        }



        //Свойство для хранения выбранного отдела
        public string SelectedDepartItem
        {
            get { return selectedDepartItem; }

            set
            {
                if (selectedDepartItem != value)
                    selectedDepartItem = value;
                    RaisePropertyChanged("SelectedDepartItem");

            }
        }

       
        //Свойство для хранения начальной даты
        public DateTime ActionStartDate
        {
            get { return dateStartProperty; }
           set
            {

                if (dateStartProperty != null)
                    dateStartProperty = value;
                    RaisePropertyChanged("ActionStartDate");
            }
        }


        //Свойство для выбора текущего элемента
        public DateDependencyModel SelectedDateItem
        {
            get { return dateFromCurentBett; }
            set
            {
                if (dateFromCurentBett != value)
                    dateFromCurentBett = value;

                RaisePropertyChanged("SelectedDateItem");
            }
        }


        public RelayCommand CloseCommand { get; set; } //Свойство закрытия окна










        //Коллекция для инициализации доступных дат для распсания
        public ObservableCollection<DateDependencyModel> DatesBettSource { get; set; }


        //Коллекция для отображения данных об имеющихся отделах
        public ObservableCollection<string> DepartamentSource { get; set; }


        //Коллекция для отображения ставок 
        public ObservableCollection<Bettings> BittingSource { get; set; }


        //Коллекция для отображения данных об должностях
        public ObservableCollection<string> PositionSource { get; set; }


        //Коллекция для отображения данных об расписаниях
        public ObservableCollection<Shedule> SheduleSource { get; set; }


        //Коллекция для отображения данных об отчете
        public ObservableCollection<Report> ReportSource { get; set; }


        #endregion


        #region Constructor
        public ViewModelBase() {

            // Подгружаем данные из базы данных

            dataManager = new DataManager();

            dataManager.Load();



            //Заполняем все таблицы и списки в UI            
            //Инициализируем коллекции со стороны View model -> view 

            DepartamentSource = new ObservableCollection<string> { "КБ","Технологический отдел"};

            PositionSource = new ObservableCollection<string> { "Инженер-технолог", "Инженер-конструктор" };

            BittingSource = new ObservableCollection<Bettings>(dataManager.BettingProperty);

            SheduleSource = new ObservableCollection<Shedule>(dataManager.SheduleProperty);

            ReportSource = new ObservableCollection<Report>(dataManager.ReportProperty);

            DatesBettSource = new ObservableCollection<DateDependencyModel>(dataManager.ListPropertyDependPosition);

           // CloseCommand = new RelayCommand(this.CloseWindow);
        }

        #endregion


        #region private methods
        private void ChangeListDatesFromBettingSource()
        {
            var list = dataManager.BettingProperty
                .Where(sc => sc.position == SelectedPositionItem)
                .Select(s => new Bettings {
                    actionStartDate = s.actionStartDate
                }).Select(n => new DateDependencyModel
                {
                    dateParam = (DateTime)n.actionStartDate
                }).ToList();

            DatesBettSource.Clear();
            DatesBettSource.AddRange(list);
            SelectedDateItem = DatesBettSource[0];
        }

        #endregion



        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null
                    ? true
                    : !CloseWindowFlag;
            }));
        }

    }
}
