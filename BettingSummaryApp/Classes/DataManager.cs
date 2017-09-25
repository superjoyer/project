using BettingSummaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.Classes
{
    class DataManager : IDataManager
    {

        #region fields
            
        private DataContextProvider db;

        private IEnumerable<Departament> departamentList;

        private IEnumerable<Shedule> sheduleList;

        private IEnumerable<Bettings> bettingList;

        private List<Position> positionList;

        private IEnumerable<Report> reportList;

        private IEnumerable<DateDependencyModel> listDates;

        #endregion


        #region properties

        public IEnumerable<DateDependencyModel> ListPropertyDependPosition
        {
            get
            {
                return listDates;
            }

            set
            {
                if (listDates != value)
                    listDates = value;
            }
        }

        public IEnumerable<Departament> DepartamentProperty
        {
            get
            {
                return departamentList;
            }

            set
            {
                if (departamentList != value)
                    departamentList =  value;
            }
        }

        public IEnumerable<Bettings> BettingProperty
        {
            get
            {
                return bettingList;
            }

            set
            {
                if(bettingList != value)
                   bettingList = value;
            }
        }

        public List<Position> PositionProperty
        {
            get
            {
                return positionList;
            }

            set
            {
                if (positionList != value)
                    positionList = value;
            }
        }

        public IEnumerable<Shedule> SheduleProperty
        {
            get
            {
                return sheduleList;
            }

            set
            {
                if (sheduleList != value)
                    sheduleList = value;
            }
        }

        public IEnumerable<Report> ReportProperty
        {
            get
            {
                return reportList;
            }

            set
            {
                if (reportList != value)
                    reportList = value;
            }
        }

        public event EventHandler changeList;

        #endregion


        #region constructor
        public DataManager() {

            departamentList = new List<Departament>();

            positionList = new List<Position>();

            bettingList = new List<Bettings>();

            sheduleList = new List<Shedule>();

            reportList = new List<Report>();

            listDates = new List<DateDependencyModel>();
        }

        #endregion


        #region private methods

        //Инициализируем тестовые записи по умолчанию в БД
        private void InitTables()
        {
            using (db = new DataContextProvider())
            {
                var p = new Position { IdPosition = 1, PositionName = "Инженер-конструктор" };
                var p2 = new Position { IdPosition = 2, PositionName = "Инженер-технолог" };

                db.PositionTable.Add(p);
                db.PositionTable.Add(p2);

                db.SaveChanges();

                var dep = new Departament { DepartId = 1, DepartamentName = "КБ" };
                var dep2 = new Departament { DepartId = 2, DepartamentName = "Технологический отдел" };

                db.DepartamentTable.Add(dep);
                db.DepartamentTable.Add(dep2);

                db.SaveChanges();
                
                db.BettingsTable.Add(new Bettings { BettingId = 1, position = "Инженер-конструктор", actionStartDate = DateTime.Parse("01/01/2015"), Salary = 10000 });
                db.BettingsTable.Add(new Bettings { BettingId = 2, position = "Инженер-технолог", actionStartDate = DateTime.Parse("01/06/2015"), Salary = 15000 });

                db.SaveChanges();

               

                db.SheduleTable.Add(new Shedule { SheduleId = 1,
                                                  departament = dep,
                                                  position = p,
                                                  actionStartDate = DateTime.Parse("01/01/2015"),
                                                  countPerson = 5 });

                    db.SheduleTable.Add(new Shedule
                    {
                        SheduleId = 2,
                        departament =  dep,
                        position = p,
                        actionStartDate = DateTime.Parse("01/06/2015"),
                        countPerson = 10
                    });

                db.SaveChanges();


                var templeteDate = db.BettingsTable.Select(n => n).ToList();

                var date = DateTime.Parse("1.6.2015");

                var res = db.SheduleTable.Select(n => n).
                               Join(
                                    db.BettingsTable.Select(n => n),
                                    t => t.SheduleId,
                                    h => h.BettingId,
                                    (t, h) =>
                                   new
                                   {
                                       departament = t.departament,
                                       countPerson = t.countPerson,
                                       Salary = h.Salary,
                                       StartDate = t.actionStartDate,
                                       EndDate = date,
                                       Result = t.countPerson * h.Salary
                                    }).ToList();

                db.ReportTable.Add(new Report
                {
                    departament = res[0].departament,
                    actionStartDate = res[0].StartDate,
                    actionEndDate = res[0].EndDate,
                    FOTdepartament = res[0].Result.Value
                });
         
                db.SaveChanges();
            }
        }

        #endregion




        #region public methods

        public void Load()
        {
           // InitTables();
            using (db = new DataContextProvider())
            {
                departamentList = db.DepartamentTable.Select(n => n).ToList();

                bettingList = db.BettingsTable.Select(n => n).ToList();

                positionList = db.PositionTable.Select(n => n).ToList();

                sheduleList = db.SheduleTable.Select(n => n).ToList();

                reportList = db.ReportTable.Select(n => n).ToList();

                listDates = bettingList.Where(n => n.position == positionList.FirstOrDefault().PositionName.ToString())
                        .Select(n => new DateDependencyModel { dateParam = (DateTime)n.actionStartDate }).ToList();
            }
        }

        //Метод внесения данных в таблицу Ставки
        public void InsertToBetting(object parameter)
        {
            if (parameter != null)
            {
                var item = parameter as Bettings;
                try
                {
                    using (db = new DataContextProvider())
                    {
                        db.BettingsTable.Add(item);
                        db.SaveChanges();
                        bettingList = db.BettingsTable.Select(n => n).ToList();
                    }
                }
                catch (Exception) { }
            }
        }

        //Метод внесения данных в таблицу Расписание 
        public void InsertToShedule(object parameter)
        {
            if (parameter != null)
            {
                var item = parameter as Shedule;
                try
                {
                    using (db = new DataContextProvider())
                    {
                        
                        db.SheduleTable.Add(item);
                        
                        db.SaveChanges();
                        sheduleList = db.SheduleTable.Select(n => n).ToList();

                    }
                }
                catch (InvalidOperationException) { }
            }
        }

       

        public void InsertToReports(object parameter)
        {
            if (parameter != null)
            {
                var ExternalObjectToReport = parameter as Shedule;

                using (db = new DataContextProvider())
                {

                    sheduleList = db.SheduleTable.Select(n => n).ToList();
                    bettingList = db.BettingsTable.Select(n => n).ToList();
                    string pos = ExternalObjectToReport.position.PositionName;
                    string depart = ExternalObjectToReport.departament.DepartamentName;

                    var pos_shedule_table = sheduleList
                        .Join(
                              db.PositionTable.Select(n => n),
                              t => t.position.IdPosition,
                              h => h.IdPosition,
                              (t, h) =>
                                new
                                {
                                    IdPosition = h.IdPosition,
                                    IdShedule = t.SheduleId,
                                    PositionName = t.position.PositionName,
                                    date = t.actionStartDate,
                                    count = t.countPerson,
                                }).ToList();

                    var dep_shedule_table = sheduleList
                         .Join(
                            db.DepartamentTable.Select(n => n),
                            sh => sh.departament.DepartId,
                            d => d.DepartId,
                            (sh, d) =>
                            new
                            {
                                IdShedule = sh.SheduleId,
                                IdDepart = d.DepartId,
                                DepartName = d.DepartamentName,

                            }).ToList();

                    var unionTableSource = pos_shedule_table
                          .Join(
                             dep_shedule_table,
                             p => p.IdShedule,
                             d => d.IdShedule,
                             (p, d) =>
                             new
                             {
                                 IdShedule = p.IdShedule,
                                 IdDepart = d.IdDepart,
                                 DepartName = d.DepartName,
                                 Count = p.count,
                                 Date = p.date,
                                 PositionName = p.PositionName
                             }).ToList();

                    //Все записи из 4-х таблиц

                    var selectAllTables = unionTableSource
                              .Join(
                                   db.BettingsTable.Select(n => n),
                                   t => t.PositionName,
                                   h => h.position,
                                   (t, h) =>
                                  new
                                  {
                                      IdShedule = t.IdShedule,
                                      IdDepart = t.IdDepart,
                                      DepartName = t.DepartName,
                                      Count = t.Count,
                                      Date = t.Date,
                                      PositionName = t.PositionName,
                                      Price = h.Salary,
                                      FOT = t.Count * h.Salary

                                  }).Distinct();

         
                                        var getCurrentItemDataBase = selectAllTables.Where(n => n.PositionName ==
                                                                    ExternalObjectToReport.position.PositionName && 
                                                                    n.DepartName == ExternalObjectToReport.departament.DepartamentName).FirstOrDefault();





                                            foreach (var curentReportItem in selectAllTables)
                                            {
                                                if (curentReportItem.DepartName == ExternalObjectToReport.departament.DepartamentName)
                                                {
                                                    if (ExternalObjectToReport.SheduleId == curentReportItem.IdShedule)
                                                    {
                                                        var dataToReportTable = new Report()
                                                        {
                                                            reportId = 1,
                                                            departament = new Departament { DepartId = 1, DepartamentName = 
                                                                                            ExternalObjectToReport.departament.DepartamentName},
                                                            actionStartDate = ExternalObjectToReport.actionStartDate,
                                                            actionEndDate = DateTime.Parse(ExternalObjectToReport.actionStartDate.
                                                                                            Value.Date.ToString()).AddDays(30),
                                                            FOTdepartament = getCurrentItemDataBase.FOT.Value
                                                         };

                                                        db.ReportTable.Add(dataToReportTable);
                                                        db.SaveChanges();
                                                        break;
                                                    }

                                                }

                                    }
                
                         }
                }
            }
        #endregion
    }
}
