import angelstone.money.grail.*
import grails.util.Environment

class BootStrap {

    def init = { servletContext ->
        switch (Environment.current) {
            case Environment.DEVELOPMENT:
                createSampleData()
            break;
            case Environment.PRODUCTION:
                createFangShiData()
            break;
            default:
            break;
        }
    }
    def destroy = {
    }
     
    void createSampleData() {
     	def fenlei = new Fenlei(name:"Fenlei1", updated:new Date()).save()
     	fenlei = new Fenlei(name:"Fenlei2", updated:new Date()).save()
     	fenlei = new Fenlei(name:"Fenlei3", updated:new Date()).save()
     	fenlei = new Fenlei(name:"Fenlei4", updated:new Date()).save()

        createFangShiData()
    }

    void createFangShiData() {
     	def fangshi = new Fangshi(name:"现金", updated:new Date()).save()
     	fangshi = new Fangshi(name:"老婆招行", updated:new Date()).save()
     	fangshi = new Fangshi(name:"老公招行", updated:new Date()).save()
     	fangshi = new Fangshi(name:"老公中信", updated:new Date()).save()
    }
} 