package angelstone.money.grail

import grails.converters.*

class RichangjiaoyiController {
	
    def scaffold = true
	
    def index = {
        redirect(action:list)
    }

    def ajaxGetJiaoYiNames = {
        def all_jiaoyi_list
		
        if (params.fenlei != null) {
            all_jiaoyi_list = Richangjiaoyi.withCriteria {
                eq("fenlei.id",Long.valueOf(params.fenlei))
                projections {
                    groupProperty("name")
                    count("id", "nameCount")
                }
                order ("nameCount","desc")
            }
        } else {
            all_jiaoyi_list = Richangjiaoyi.withCriteria {
                projections {
                    groupProperty("name")
                    count("id", "nameCount")
                }
                order("nameCount","desc")
            }
        }
		
        def all_jiaoyi = all_jiaoyi_list
		
        render all_jiaoyi as JSON
    }
}
