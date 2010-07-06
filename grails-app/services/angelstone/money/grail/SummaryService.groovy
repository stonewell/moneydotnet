package angelstone.money.grail

class SummaryService {

    static transactional = false

    def getTotalSummary(int year, int month, int day) {
        def summary = new TotalSummary()

        summary.YearSummary = getYearSummary(year)
        summary.FenleiYearSummary = getFenleiYearSummary(year)
        summary.MonthSummary = getMonthSummary(year, month)
        summary.FenleiMonthSummary = getFenleiMonthSummary(year, month)
        summary.TodaySummary = getTodaySummary(year, month, day)
        summary.FenleiTodaySummary = getFenleiTodaySummary(year, month, day)

        return summary
    }

    def getYearSummary(int year) {
        def summary = new Summary()

        summary.begin_label = "summary.year.begin.label"
        summary.begin_label_default = "Year Begin Amount:"
        summary.end_label = "summary.year.end.label"
        summary.end_label_default = "Year End Amount:"
        summary.expends_label = "summary.year.expends.label"
        summary.expends_label_default = "Year Expends:"
        summary.incoming_label = "summary.year.incoming.label"
        summary.incoming_label_default = "Year Incoming:"
        summary.title = "summary.year.title"
        summary.title_default="Year Summary"

        def beginDate = new Date(year,0,1,0,0,0)
        def endDate = new Date(year, 11, 31,23,59,59)
        
        summary.expends_amount = getAmount(beginDate, endDate, 0);
        summary.incoming_amount = getAmount(beginDate, endDate, 1);
        
        return summary
    }

    def getMonthSummary(int year, int month) {
        def summary = new Summary()

        summary.begin_label = "summary.month.begin.label"
        summary.begin_label_default = "Month Begin Amount:"
        summary.end_label = "summary.month.end.label"
        summary.end_label_default = "Month End Amount:"
        summary.expends_label = "summary.month.expends.label"
        summary.expends_label_default = "Month Expends:"
        summary.incoming_label = "summary.month.incoming.label"
        summary.incoming_label_default = "Month Incoming:"
        summary.title = "summary.month.title"
        summary.title_default="Month Summary"

        def beginDate = new Date(year,month,1,0,0,0)
        def endDate = new Date(year, month, 31,23,59,59)

        summary.expends_amount = getAmount(beginDate, endDate, 0);
        summary.incoming_amount = getAmount(beginDate, endDate, 1);

        return summary
    }
    
    def getTodaySummary(int year, int month, int day) {
        def summary = new Summary()

        summary.begin_label = "summary.today.begin.label"
        summary.begin_label_default = "Today Begin Amount:"
        summary.end_label = "summary.today.end.label"
        summary.end_label_default = "Today End Amount:"
        summary.expends_label = "summary.today.expends.label"
        summary.expends_label_default = "Today Expends:"
        summary.incoming_label = "summary.today.incoming.label"
        summary.incoming_label_default = "Today Incoming:"
        summary.title = "summary.today.title"
        summary.title_default="Today Summary"

        def beginDate = new Date(year,month,day,0,0,0)
        def endDate = new Date(year, month, day,23,59,59)

        summary.expends_amount = getAmount(beginDate, endDate, 0);
        summary.incoming_amount = getAmount(beginDate, endDate, 1);

        return summary
    }

    def getFenleiYearSummary(int year) {
        def summary = new FenleiSummary()
        summary.title = "summary.fenlei.year.title"
        summary.title_default="Fenlei Year Summary"

        def beginDate = new Date(year,0,1,0,0,0)
        def endDate = new Date(year, 11, 31,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate)

        return summary
    }

    def getFenleiMonthSummary(int year, int month) {
        def summary = new FenleiSummary()
        summary.title = "summary.fenlei.month.title"
        summary.title_default="Fenlei Month Summary"

        def beginDate = new Date(year, month, 1,0,0,0)
        def endDate = new Date(year, month , 31,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate)
        return summary
    }

    def getFenleiTodaySummary(int year, int month, int day) {
        def summary = new FenleiSummary()
        summary.title = "summary.fenlei.today.title"
        summary.title_default="Fenlei Today Summary"

        def beginDate = new Date(year, month, day,0,0,0)
        def endDate = new Date(year, month , day,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate)
        return summary
    }

    def getAmount(Date begin, Date end, int fangxiang) {
        def c = Richangjiaoyi.createCriteria()
        def sum = c.get {
            projections {
                sum "amount"
            }
            between("created", begin, end)
            eq("fangxiang", fangxiang)
        }

        if (sum == null) return 0
        
        return sum
    }
    
    def getFenleiAmountList(Date begin, Date end) {
        def sumIncome = Richangjiaoyi.withCriteria {
            projections {
                groupProperty("name")
                sum "amount"
            }
            between("created", begin, end)
            eq("fangxiang", 1)
        }

        def sumExpends = Richangjiaoyi.withCriteria {
            projections {
                groupProperty("name")
                sum("amount")
            }
            between("created", begin, end)
            eq("fangxiang", 0)
        }

        sumExpends.each { sum  ->
            sum[1] = -1 * sum[1]
        }

        if (sumIncome == null && sumExpends == null) return []

        if (sumIncome == null) return sumExpends

        if (sumExpends == null) return sumIncome

        def sum = [:]

        sumIncome.each{ income ->
            sum.put(income[0], income[1])
        }

        sumExpends.each { expends ->
            if (sum.containsKey(expends[0]) ) {
                sum.put(expends[0], sum.get(expends[0]) + expends[1])
            } else {
                sum.put(expends[0], expends[1])
            }
        }
        
        def sumList = []
        
        sum.each() { s ->
            sumList.add([s.key, s.value])
        }

        return sumList
    }
}
