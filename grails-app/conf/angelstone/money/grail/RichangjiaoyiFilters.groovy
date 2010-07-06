package angelstone.money.grail

class RichangjiaoyiFilters {

    def filters = {
        all(controller:'richangjiaoyi', action:'save|update') {
            before = {
                params.updated = new Date()
            }
            after = {
                
            }
            afterView = {
                
            }
        }
    }
    
}
