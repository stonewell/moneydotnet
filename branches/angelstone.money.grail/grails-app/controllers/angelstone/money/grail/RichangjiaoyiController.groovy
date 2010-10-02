package angelstone.money.grail

import grails.converters.*

class RichangjiaoyiController {
	
    def scaffold = true
    def summaryService
	
    def index = {
        redirect(action:list)
    }

    def ajaxGetJiaoYiNames = {
        def all_jiaoyi_list
	
        def fenlei = -1;
        
        if (params.fenlei != null) {
            fenlei = Long.valueOf(params.fenlei)
        }
		
        def all_jiaoyi = summaryService.getJiaoYiNames(fenlei)
		
        render all_jiaoyi as JSON
    }
}
