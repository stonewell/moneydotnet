package angelstone.money.grail

class SummaryService {

    static transactional = false

    def getTotalSummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new TotalSummary()

        summary.YearSummary = getYearSummary(year, fenlei, fangshi)
        summary.ItemYearSummary = getItemYearSummary(year, fenlei, fangshi)
        summary.FenleiYearSummary = getFenleiYearSummary(year, fenlei, fangshi)
        summary.FangshiYearSummary = getFangshiYearSummary(year, fenlei, fangshi)
        summary.MonthSummary = getMonthSummary(year, month, fenlei, fangshi)
        summary.ItemMonthSummary = getItemMonthSummary(year, month, fenlei, fangshi)
        summary.FenleiMonthSummary = getFenleiMonthSummary(year, month, fenlei, fangshi)
        summary.FangshiMonthSummary = getFangshiMonthSummary(year, month, fenlei, fangshi)
        summary.TodaySummary = getTodaySummary(year, month, day, fenlei, fangshi)
        summary.ItemTodaySummary = getItemTodaySummary(year, month, day, fenlei, fangshi)
        summary.FenleiTodaySummary = getFenleiTodaySummary(year, month, day, fenlei, fangshi)
        summary.FangshiTodaySummary = getFangshiTodaySummary(year, month, day, fenlei, fangshi)

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

    def getItemYearSummary(int year, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.item.year.title"
        summary.title_default="Item Year Summary"
        summary.type = 1

        def beginDate = new Date(year,0,1,0,0,0)
        def endDate = new Date(year, 11, 31,23,59,59)

        summary.fenleiList = getItemAmountList(beginDate, endDate, fenlei, fangshi)

        return summary
    }

    def getFenleiYearSummary(int year, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.fenlei.year.title"
        summary.title_default="Fenlei Year Summary"
        summary.type = 11

        def beginDate = new Date(year,0,1,0,0,0)
        def endDate = new Date(year, 11, 31,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate, fenlei, fangshi)

        return summary
    }

    def getFangshiYearSummary(int year, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.fangshi.year.title"
        summary.title_default="Fangshi Year Summary"
        summary.type = 11

        def beginDate = new Date(year,0,1,0,0,0)
        def endDate = new Date(year, 11, 31,23,59,59)

        summary.fenleiList = getFangshiAmountList(beginDate, endDate, fenlei, fangshi)

        return summary
    }

    def getItemMonthSummary(int year, int month, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.item.month.title"
        summary.title_default="Item Month Summary"
        summary.type = 2

        def beginDate = new Date(year, month, 1,0,0,0)
        def endDate = new Date(year, month , 31,23,59,59)

        summary.fenleiList = getItemAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getFenleiMonthSummary(int year, int month, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.fenlei.month.title"
        summary.title_default="Fenlei Month Summary"
        summary.type = 2

        def beginDate = new Date(year, month, 1,0,0,0)
        def endDate = new Date(year, month , 31,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getFangshiMonthSummary(int year, int month, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.fangshi.month.title"
        summary.title_default="Fangshi Month Summary"
        summary.type = 2

        def beginDate = new Date(year, month, 1,0,0,0)
        def endDate = new Date(year, month , 31,23,59,59)

        summary.fenleiList = getFangshiAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getItemTodaySummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.item.today.title"
        summary.title_default="Item Today Summary"
        summary.type = 3

        def beginDate = new Date(year, month, day,0,0,0)
        def endDate = new Date(year, month , day,23,59,59)

        summary.fenleiList = getItemAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getFenleiTodaySummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.fenlei.today.title"
        summary.title_default="Fenlei Today Summary"
        summary.type = 3

        def beginDate = new Date(year, month, day,0,0,0)
        def endDate = new Date(year, month , day,23,59,59)

        summary.fenleiList = getFenleiAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getFangshiTodaySummary(int year, int month, int day, int fenlei, int fangshi) {
        def summary = new NameAmountSummary()
        summary.title = "summary.fangshi.today.title"
        summary.title_default="Fangshi Today Summary"
        summary.type = 3

        def beginDate = new Date(year, month, day,0,0,0)
        def endDate = new Date(year, month , day,23,59,59)

        summary.fenleiList = getFangshiAmountList(beginDate, endDate, fenlei, fangshi)
        return summary
    }

    def getAmount(Date begin, Date end, int fangxiang, int fenlei, int fangshi) {
       def query = "select amount from Richangjiaoyi where created >= ?1 and created <= ?2 and fangxiang=?3"
       def next_index = 4
       
       if (fenlei >= 0) {
           query += " and fenlei_id = ?" + next_index
           next_index++
       }
       
       if (fangshi >= 0) {
       	   query += " and fangshi_id = ?" + next_index
       	   next_index++
       }
       
       def sum_amounts = Richangjiaoyi.executeQuery(query,[begin,end,fangxiang,fenlei,fangshi])
       
       if (sum_amounts == null) return 0
       
       def sum_amount = 0;
       
       sum_amounts.each {
          sum_amount += it
       }
       
       return sum_amount
       	
    }
    
    def getItemAmountList(Date begin, Date end, int fenlei, int fangshi) {
       def query = "select name, amount,fangxiang from Richangjiaoyi where created >= ?1 and created <= ?2"
       def next_index = 3
       
       if (fenlei >= 0) {
           query += " and fenlei_id = ?" + next_index
           next_index++
       }
       
       if (fangshi >= 0) {
       	   query += " and fangshi_id = ?" + next_index
       	   next_index++
       }
       
      
       def values = Richangjiaoyi.executeQuery(query,[begin,end,fenlei,fangshi])

       if (values == null) return [];
       
        def sum = [:]

        values.each{ value ->
            if (sum.containsKey(value[0]) ) {
                sum.put(value[0], sum.get(value[0]) + value[1] * (2 * value[2] - 1))
            } else {
            	sum.put(value[0],  value[1] * (2 * value[2] - 1))
            }
        }

        def sumList = []
        
        sum.each() { s ->
            sumList.add([s.key, s.value])
        }

        sumList.sort{ it[1] }
        
        return sumList
    }


    def getFenleiAmountList(Date begin, Date end, int fenlei, int fangshi) {
       def query = "select fenlei_id, r.amount,r.fangxiang from Richangjiaoyi r where r.created >= ?1 and r.created <= ?2"
       def next_index = 3
       
       if (fenlei >= 0) {
           query += " and r.fenlei_id = ?" + next_index
           next_index++
       }
       
       if (fangshi >= 0) {
       	   query += " and r.fangshi_id = ?" + next_index
       	   next_index++
       }
       
       def values = Richangjiaoyi.executeQuery(query,[begin,end,fenlei,fangshi])

       if (values == null) return [];
       
        def sum = [:]

        values.each{ value -> 
            def fenleiO = Fenlei.get(value[0])
            if (sum.containsKey(fenleiO.name) ) {
                sum.put(fenleiO.name, sum.get(fenleiO.name) + value[1] * (2 * value[2] - 1))
            } else {
            	sum.put(fenleiO.name,  value[1] * (2 * value[2] - 1))
            }
        }

        def sumList = []
        
        sum.each() { s ->
            sumList.add([s.key, s.value])
        }

        sumList.sort{ it[1] }
        
        return sumList
    }

    def getFangshiAmountList(Date begin, Date end, int fenlei, int fangshi) {
       def query = "select fangshi_id, r.amount,r.fangxiang from Richangjiaoyi r where r.created >= ?1 and r.created <= ?2"
       def next_index = 3
       
       if (fenlei >= 0) {
           query += " and r.fenlei_id = ?" + next_index
           next_index++
       }
       
       if (fangshi >= 0) {
       	   query += " and r.fangshi_id = ?" + next_index
       	   next_index++
       }
       
      
       def values = Richangjiaoyi.executeQuery(query,[begin,end,fenlei,fangshi])

       if (values == null) return [];
       
        def sum = [:]

        values.each{ value ->
            def fangshiO = Fangshi.get(value[0])
            if (sum.containsKey(fangshiO.name) ) {
                sum.put(fangshiO.name, sum.get(fangshiO.name) + value[1] * (2 * value[2] - 1))
            } else {
            	sum.put(fangshiO.name,  value[1] * (2 * value[2] - 1))
            }
        }

        def sumList = []
        
        sum.each() { s ->
            sumList.add([s.key, s.value])
        }

        sumList.sort{ it[1] }
        
        return sumList
    }
    
    def getJiaoYiNames(int fenlei) {
       def query = "select name from Richangjiaoyi where id>0"
       def next_index = 1
       
       if (fenlei >= 0) {
           query += " and fenlei_id = ?" + next_index
           next_index++
       }
       
       def values = Richangjiaoyi.executeQuery(query,[fenlei])

       if (values == null) return [];
       
        def sum = [:]

        values.each{ value ->
            if (sum.containsKey(value[0]) ) {
                sum.put(value[0], sum.get(value[0]) + 1)
            } else {
            	sum.put(value[0],  1)
            }
        }

        def sumList = []
        
        sum.each() { s ->
            sumList.add([s.key, s.value])
        }

	def mc= [
	compare: {a,b-> a[1].equals(b[1])? 0: Math.abs(a[1])<Math.abs(b[1])? -1: 1 }
	] as Comparator
	
	sumList.sort{ mc }
        
        return sumList
    }
}
