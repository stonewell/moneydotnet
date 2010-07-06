package angelstone.money.grail

class FenleiController {

    def scaffold=true

    def index = { 
        redirect(action:list)
    }
}
