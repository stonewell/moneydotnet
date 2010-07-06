package angelstone.money.grail

class FangshiController {

    def scaffold = true
    def index = { 
        redirect(action:list)
    }
}
