package angelstone.money.grail

class Richangjiaoyi {
    int fangxiang
    String name
    Fenlei fenlei
    Fangshi fangshi
    Date created = new Date()
    Date updated = new Date()
    double amount
    String description
	
    static constraints = {
        fangxiang(blank:false,
            validator: { fx ->
                return fx==0 || fx==1
            })
        name(maxSize:50, blank:false)
        amount(blank:false,
            validator:{ amt ->
                return amt > 0
            })
        fenlei(blank:false)
        fangshi(blank:false)
        description(maxSize:255, nullable:true)
    }

    static mapping = {
        fenlei lazy:false
        fangshi lazy:false
    }
}
