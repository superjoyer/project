using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.ViewModels
{
    class ReportViewModel : ViewModelBase
    {
        public ReportViewModel() {
            CurrentNavigation = Models.TypeForm.ReportForm;
        }

    }
}
