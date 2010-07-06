package angelstone.money.grail

class Fenlei {
    String name
    Date updated = new Date()

    static constraints = {
        name(blank:false, unique:true)
    }

    String toString() {
        "${name}"
    }
}
