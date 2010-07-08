package angelstone.money.grail

import grails.converters.*

class SummaryController {

    def summaryService

    def index = {
        def now = new Date()
        def year = now.year
        def month = now.month
        def day = now.date
        def fangshi = -1
        def fenlei = -1

        if (params.year != null) year = Integer.valueOf(params.year)
        if (params.month != null) month = Integer.valueOf(params.month)
        if (params.day != null) day = Integer.valueOf(params.day)
        if (params.fangshi != null) fangshi = Integer.valueOf(params.fangshi)
        if (params.fenlei != null) fenlei = Integer.valueOf(params.fenlei)

        def totalSummary = summaryService.getTotalSummary(year, month, day, fenlei, fangshi)

        render(view:"show", model:[summary:totalSummary])
    }

    def ajaxGetItemSummary = {

        def now = new Date()
        def year = now.year
        def month = now.month
        def day = now.date
        def fangshi = -1
        def fenlei = -1
        def type = 1;

        if (params.year != null) year = Integer.valueOf(params.year)
        if (params.month != null) month = Integer.valueOf(params.month)
        if (params.day != null) day = Integer.valueOf(params.day)
        if (params.fangshi != null) fangshi = Integer.valueOf(params.fangshi)
        if (params.fenlei != null) fenlei = Integer.valueOf(params.fenlei)
        if (params.type != null) type = Integer.valueOf(params.type)

        def summary;

        switch(type) {
            case 1:
                summary = summaryService.getItemYearSummary(year, fenlei, fangshi)
                break
            case 2:
                summary = summaryService.getItemMonthSummary(year, month, fenlei, fangshi)
                break
            case 3:
                summary = summaryService.getItemTodaySummary(year, month, day, fenlei, fangshi)
                break
            default:
            break
        }

        render(template:"rangeItemSummaryBodyTemplate", model:[summary:summary])
    }

}