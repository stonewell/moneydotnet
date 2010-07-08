package angelstone.money.grail

class SummaryService {

    static transactional = false

    def getTotalSummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new TotalSummary()

        summary.YearSummary = getYearSummary(year, fenlei, fangshi)
        summary.FenleiYearSummary = getFenleiYearSummary(year, fenlei, fangshi)
        summary.MonthSummary = getMonthSummary(year, month, fenlei, fangshi)
        summary.FenleiMonthSummary = getFenleiMonthSummary(year, month, fenlei, fangshi)
        summary.TodaySummary = getTodaySummary(year, month, day, fenlei, fangshi)
        summary.FenleiTodaySummary = getFenleiTodaySummary(year, month, day, fenlei, fangshi)

        return summary
    }

    def getYearSummary(int year, int fenlei, int fangshi) {
        def summary = new Summary()

        summary.type = 1
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
        
        summary.expends_amount = getAmount(beginDate, endDate, 0, fenlei, fangshi);
        summary.incoming_amount = getAmount(beginDate, endDate, 1, fenlei, fangshi);
        
        return summary
    }

    def getMonthSummary(int year, int month, int fenlei, int fangshi) {
        def summary = new Summary()

        summary.type = 2
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

        summary.expends_amount = getAmount(beginDate, endDate, 0, fenlei, fangshi);
        summary.incoming_amount = getAmount(beginDate, endDate, 1, fenlei, fangshi);

        return summary
    }
    
    def getTodaySummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new Summary()

        summary.type = 3
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

        summary.expends_amount = getAmount(beginDate, endDate, 0, fenlei, fangshi);
        summary.incoming_amount = getAmount(beginDate, endDate, 1, fenlei, fangshi);

        return summary
    }

    def getFenleiYearSummary(int year, int fenlei, int fangshi) {
        def summary = new FenleiSummary()
        summary.title = "summary.fenlei.year.title"
        summary.title_default="Fenlei Year Summary"
        summary.type = 1

        def beginDate = new Date(year,0,1,0,0,0)
        def endDate = new Date(year, 11, 31,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate, fenlei, fangshi)

        return summary
    }

    def getFenleiMonthSummary(int year, int month, int fenlei, int fangshi) {
        def summary = new FenleiSummary()
        summary.title = "summary.fenlei.month.title"
        summary.title_default="Fenlei Month Summary"
        summary.type = 2

        def beginDate = new Date(year, month, 1,0,0,0)
        def endDate = new Date(year, month , 31,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getFenleiTodaySummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new FenleiSummary()
        summary.title = "summary.fenlei.today.title"
        summary.title_default="Fenlei Today Summary"
        summary.type = 3

        def beginDate = new Date(year, month, day,0,0,0)
        def endDate = new Date(year, month , day,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getAmount(Date begin, Date end, int fangxiang, int fenlei, int fangshi) {
        def c = Richangjiaoyi.createCriteria()
        def sum_amount

            sum_amount = c.get {
                projections {
                    sum "amount", "samount"
                }
                between("created", begin, end)
                eq("fangxiang", fangxiang)

                if (fenlei >= 0) {
                    eq("fenlei.id", fenlei)
                }

                if (fangshi >= 0) {
                    eq("fangshi.id", fangshi)
                }

                order("samount", "desc")
            }

        if (sum_amount == null) return 0
        
        return sum_amount
    }
    
    def getFenleiAmountList(Date begin, Date end, int fenlei, int fangshi) {
        def sumIncome = Richangjiaoyi.withCriteria {
            projections {
                groupProperty("name")
                sum "amount",  "samount"
            }
            between("created", begin, end)
            eq("fangxiang", 1)
            
            if (fenlei >= 0) {
                eq("fenlei.id", (long)fenlei)
            }

            if (fangshi >= 0) {
                eq("fangshi.id", (long)fangshi)
            }

            order("samount", "desc")
        }

        def sumExpends = Richangjiaoyi.withCriteria {
            projections {
                groupProperty("name")
                sum("amount","samount")
            }
            between("created", begin, end)
            eq("fangxiang", 0)
            
            if (fenlei >= 0) {
                eq("fenlei.id",(long) fenlei)
            }

            if (fangshi >= 0) {
                eq("fangshi.id", (long)fangshi)
            }

            order("samount", "desc")
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

        sumList.sort{ it[1] }
        
        return sumList
    }
}
