package angelstone.money.grail

class SummaryController {

    def summaryService

    def index = {
        def now = new Date()
        def year = now.year
        def month = now.month
        def day = now.date

        if (params.year != null) year = Integer.valueOf(params.year)
        if (params.month != null) month = Integer.valueOf(params.month)
        if (params.day != null) day = Integer.valueOf(params.day)

        def totalSummary = summaryService.getTotalSummary(year, month, day)

        render(view:"show", model:[summary:totalSummary])
    }
}
